using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using CEP.WebAPI.Models;
using CEP.Models.Configuration;
using Microsoft.Extensions.Configuration;
using CEP.Constants;
using CEP.Helpers.Tokens;
using CEP.BLL.AccountServices.Abstractions;

namespace CEP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceProvider serviceProvider;

        public AuthenticationController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [HttpGet("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            return this.Ok(true);
        }

        [HttpPost("google")]
        [AllowAnonymous]
        public IActionResult GoogleSignIn([FromBody] TokenIdModel tokenIdModel)
        {
            if (tokenIdModel != null && !string.IsNullOrEmpty(tokenIdModel.TokenId))
            {
                try
                {
                    var payload = GoogleJsonWebSignature.ValidateAsync(tokenIdModel.TokenId, new GoogleJsonWebSignature.ValidationSettings()).Result;
                    var authService = this.serviceProvider.GetService<IAccountService>();
                    authService.CreateUserIfNotExist(payload.Email);

                    var jwtSettings = new JwtSettings();
                    var configuration = this.serviceProvider.GetService<IConfiguration>();
                    configuration.GetSection(ConfigurationConstants.JwtSectionName).Bind(jwtSettings);

                    var token = TokenHelper.CreateToken(jwtSettings.SigningKey, jwtSettings.Issuer, jwtSettings.Audience, payload.Email);

                    return this.Ok(new AccessTokenModel(token));
                }
                catch (Exception e)
                {
                    return this.BadRequest();
                }
            }

            return this.BadRequest();
        }
    }
}
