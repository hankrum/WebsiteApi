using Api.Data.Model;
using Api.Data.Repository;
using Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlDbContext context;
        private readonly IEfRepository<WebSite> webSites;
        private readonly IEfRepository<Category> categories;

        public UnitOfWork(
            MsSqlDbContext context, 
            IEfRepository<WebSite> webSites,
            IEfRepository<Category> categories
            )
        {
            Validated.NotNull(context, nameof(context));
            Validated.NotNull(webSites, nameof(webSites));
            Validated.NotNull(categories, nameof(categories));
            this.context = context;
            this.webSites = webSites;
            this.categories = categories;
        }

        public IEfRepository<WebSite> WebSites
        {
            get
            {
                return this.webSites;
            }
        }

        public IEfRepository<Category> Categories
        {
            get
            {
                return this.categories;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
