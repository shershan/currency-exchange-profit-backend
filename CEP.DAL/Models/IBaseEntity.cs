using System;

namespace CEP.DAL.Models
{
    public interface IBaseEntity
    {
        Guid Id
        {
            get;
            set;
        }
    }
}
