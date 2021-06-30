using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CEP.DAL.Maps
{
    internal abstract class BaseMap<TType>
        where TType : class
    {
        protected internal virtual string TableName
        {
            get => typeof(TType).Name;
        }

        protected internal virtual string SchemaName
        {
            get => string.Empty;
        }

        public virtual void Build(EntityTypeBuilder<TType> entityBuilder)
        {
            entityBuilder.ToTable(this.TableName, this.SchemaName);
            this.Configure(entityBuilder);
        }

        protected abstract void Configure(EntityTypeBuilder<TType> entityBuilder);
    }
}
