using AutoMapper;
using IntroSEProject.API.Models;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;

namespace IntroSEProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private AppDbContext context;
        private IMapper mapper;
        private ITokenManager tokenManager;
        private readonly IEmailSender emailService;

        public UserController(AppDbContext context, 
            IMapper mapper, 
            ITokenManager tokenManager,
            IEmailSender emailService)
        {
            this.context = context;
            this.mapper = mapper;
            this.tokenManager = tokenManager;
            this.emailService = emailService;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var u = await context.Users.FirstOrDefaultAsync(x => x.Email == registerModel.Email);
            if (u != null) return BadRequest(new { error = "The user has existed" });
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerModel.Password);
                registerModel.Password = passwordHash;
                User user = mapper.Map<User>(registerModel);

                //var token = Guid.NewGuid().ToString();
                //user.EmailConfirmToken = token;

                
                //var apiBaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
                //var pageUrl = $"{registerModel.EmailConfirmSuccessPage}";
                //var link = $"{apiBaseUrl}/confirm-email?emailConfirm={token}&pageUrl={pageUrl}";
                //var response = await emailService.SendEmailAsync(user.Email, "Email Confirm", link);

                //if (!response.IsSuccessStatusCode)
                //{
                //    return Forbid();
                //}

                await context.AddAsync(user);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string emailConfirm, string pageUrl)
        {
            var user = await context.Users.Where(x => x.EmailConfirmToken == emailConfirm)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return BadRequest(new {error = "Email Confirmation Failed"});
            }
            user.EmailConfirmed = true;
            user.EmailConfirmToken = string.Empty;
            await context.SaveChangesAsync();
            return Redirect(pageUrl);
        }

        [HttpPost]
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Credential credential)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == credential.Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(credential.Password, user.Password))
            {
                //if  (user.EmailConfirmed == false)
                //{
                //    return Ok(new { message = "The email hasn't been confirmed" });
                //}
                (string accessToken, DateTime accessTokenExpiresAt) = tokenManager.CreateAccessToken(user);
                (string refreshToken, DateTime refreshTokenExpiresAt) = tokenManager.CreateRefreshToken(user);
                //SetAccessTokenCookie(accessToken, accessTokenExpiresAt);
                SetRefreshTokenCookie(refreshToken, refreshTokenExpiresAt);
                return Ok(new {
                    user = mapper.Map<LoginModel>(user),
                    accessToken
                });
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
            return Ok(new
            {
                accessToken
            });
        }

        [HttpGet("/logout")]
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
                SameSite = SameSiteMode.None,
                Secure = true
                });
            
        }
        private void SetRefreshTokenCookie(string token, DateTime expiresAt)
        {
            Response.Cookies.Append("refresh_token", token,
                new CookieOptions
                {
                    HttpOnly = true,
                    Expires = expiresAt,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
        }
    }
}
