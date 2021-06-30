using CEP.Models.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;

namespace CEP.DAL.Models
{
    public class User : IdentityUser<Guid>, IUser, IBaseEntity
    {

    }
}
