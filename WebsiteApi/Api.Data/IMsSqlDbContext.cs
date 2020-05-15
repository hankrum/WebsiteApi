using Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Data
{
    public interface IMsSqlDbContext : IDisposable
    {
        DbSet<WebSite> WebSites { get; set; }

        DbSet<Category> Categorys { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
