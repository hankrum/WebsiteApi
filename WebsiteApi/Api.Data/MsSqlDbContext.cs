using Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public class MsSqlDbContext : DbContext, IMsSqlDbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebSite> WebSites { get; set; }

        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
