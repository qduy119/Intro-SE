using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace IntroSEProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private AppDbContext context;
        private IMapper mapper;
        private ITokenManager tokenManager;

        public UserController(AppDbContext context, IMapper mapper, ITokenManager tokenManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenManager = tokenManager;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);
                registerModel.Password = passwordHash;
                User user = mapper.Map<User>(registerModel);
                await context.AddAsync(user);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Credential credential)
        {
            // Verify the credential
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == credential.Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(credential.Password, user.Password))
            {
                (string accessToken, DateTime accessTokenExpiresAt) = tokenManager.CreateAccessToken(user);
                (string refreshToken, DateTime refreshTokenExpiresAt) = tokenManager.CreateRefreshToken(user);
                SetAccessTokenCookie(accessToken, accessTokenExpiresAt);
                SetRefreshTokenCookie(refreshToken, refreshTokenExpiresAt);
                return Ok();
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("/refresh-token")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromBody] RefreshTokenModel refreshTokenModel)
        {
            (string accessToken, DateTime accessTokenExpiresAt) = 
                tokenManager.ValidateRefreshToken(refreshTokenModel.RefreshToken);

            if (string.IsNullOrEmpty(accessToken))
            {
                return BadRequest();
            }
            SetAccessTokenCookie(accessToken, accessTokenExpiresAt);
            return Ok();
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            Response.Cookies.Delete("refresh_token");
            return Ok();    
        }

        private void SetAccessTokenCookie(string token, DateTime expiresAt)
        {
            Response.Cookies.Append("access_token", token, 
                new CookieOptions
            {
                HttpOnly = true,
                Expires = expiresAt,
            });
            
        }
        private void SetRefreshTokenCookie(string token, DateTime expiresAt)
        {
            Response.Cookies.Append("refresh_token", token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Expires = expiresAt,
                });

        }
    }
}
