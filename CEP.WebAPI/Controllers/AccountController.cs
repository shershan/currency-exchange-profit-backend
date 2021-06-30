using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using CEP.BLL.AccountServices.Abstractions;

namespace CEP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private IServiceProvider serviceProvider;

        public AccountController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [HttpGet("accountInfo")]
        public IActionResult GetAccountInfo()
        {
            var userEmail = this.User.Identity?.Name;
            if (!string.IsNullOrEmpty(userEmail))
            {
                var accountService = this.serviceProvider.GetService<IAccountService>();
                return this.Ok(accountService.GetUserInfo(userEmail));
            }

            return this.BadRequest();
        }
    }
}
