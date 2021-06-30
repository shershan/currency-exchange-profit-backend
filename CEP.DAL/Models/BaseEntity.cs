using System;

namespace CEP.DAL.Models
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id
        {
            get;
            set;
        }
    }
}
