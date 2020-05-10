using Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public interface IMsSqlDbContext : IDisposable
    {
        DbSet<WebSite> WebSites { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
