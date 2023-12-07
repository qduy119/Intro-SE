
using IntroSEProject.API.Configs;
using IntroSEProject.API.Services;
using IntroSEProject.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IntroSEProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddLogging();
            builder.Services.AddControllers();      
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
            builder.Services.AddScoped<ITokenManager, TokenManager>();
            var secretKey = builder.Configuration.GetValue<string>("AuthToken:SecretKey") ?? "";
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("AuthToken:Issuer"),
                    ValidAudience = builder.Configuration.GetValue<string>("AuthToken:Audience"),
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        //var tokenManager = context.HttpContext.RequestServices.GetRequiredService<ITokenManager>();
                        //return tokenManager.ValidateAccessToken(context);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}