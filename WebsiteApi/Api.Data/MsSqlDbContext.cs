using Api.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Data
{
    public class MsSqlDbContext : DbContext, IMsSqlDbContext
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebSite> WebSites { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.UpdateSoftDelete();
            this.UpdateCreateAndModify();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WebSite>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);

            builder.Entity<Category>().HasQueryFilter(c => EF.Property<bool>(c, "IsDeleted") == false);
        }

        private void UpdateSoftDelete()
        {
            foreach (var entry in this.ChangeTracker.Entries())
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
