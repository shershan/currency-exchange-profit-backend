using CEP.DAL.Maps;
using CEP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CEP.DAL
{
    public class CEPContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CEPContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap().Build(modelBuilder.Entity<User>());
        }
    }
}
