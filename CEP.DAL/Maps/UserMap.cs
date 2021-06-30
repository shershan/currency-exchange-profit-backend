using CEP.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEP.DAL.Maps
{
    internal class UserMap : BaseMap<User>
    {
        protected internal override string SchemaName
        {
            get => "auth";
        }

        protected override void Configure(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.AddBase();
        }
    }
}
