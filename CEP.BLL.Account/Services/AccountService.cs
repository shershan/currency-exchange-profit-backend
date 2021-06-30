using CEP.BLL.AccountServices.Abstractions;
using CEP.BLL.BaseDbService;
using CEP.DAL.Models;
using CEP.Models.Abstractions;
using System;
using System.Linq;

namespace CEP.BLL.AccountServices.Services
{
    internal class AccountService : BaseDbServices, IAccountService
    {
        public AccountService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public IUser GetUserInfo(string email)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                return uow.Repository<User>().Get(x => x.Email == email)?.FirstOrDefault();
            });
        }

        public IUser CreateUserIfNotExist(string email)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var user = uow.Repository<User>().Get(x => x.Email == email)?.FirstOrDefault();
                if (user == null)
                {
                    user = new User()
                    {
                        Email = email
                    };

                    uow.Repository<User>().Add(user);
                    uow.Save();
                }

                return user;
            });
        }
    }
}
