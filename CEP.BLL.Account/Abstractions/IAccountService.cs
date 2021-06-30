using CEP.Models.Abstractions;

namespace CEP.BLL.AccountServices.Abstractions
{
    public interface IAccountService
    {
        IUser GetUserInfo(string email);

        IUser CreateUserIfNotExist(string email);
    }
}
