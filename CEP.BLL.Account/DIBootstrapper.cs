using CEP.BLL.AccountServices.Abstractions;
using CEP.BLL.AccountServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CEP.BLL.Account
{
    public static class DIBootstrapper
    {
        public static void InitAccountService(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
