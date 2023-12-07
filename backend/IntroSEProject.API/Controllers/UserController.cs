using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroSEProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly ITokenManager tokenManager;

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

                return Ok(new Token
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    AccessTokenExpiryDate = accessTokenExpiresAt,
                    RefreshTokenExpiryDate = refreshTokenExpiresAt
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("/refresh-token")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromBody] RefreshTokenModel refreshTokenModel)
        {
            return Ok(tokenManager.ValidateRefreshToken(refreshTokenModel.RefreshToken));
        }
    }
}
