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
            UpdateSoftDelete();
            UpdateCreateAndModify();
            return base.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WebSite>().Property<bool>("isDeleted");
            builder.Entity<WebSite>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);
            builder.Entity<WebSite>().HasIndex(w => w.Url).IsUnique();
            builder.Entity<WebSite>().HasIndex(w => w.Name).IsUnique();

            builder.Entity<Category>().Property<bool>("isDeleted");
            builder.Entity<Category>().HasQueryFilter(c => EF.Property<bool>(c, "isDeleted") == false);
            builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        }

        private void UpdateSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = (IDeletable)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.IsDeleted = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entity.IsDeleted = true;
                        entity.DeletedOn = DateTime.Now;
                        break;
                }
            }
        }

        private void UpdateCreateAndModify()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = (IAuditable)entry.Entity;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }
        }
    }
}
