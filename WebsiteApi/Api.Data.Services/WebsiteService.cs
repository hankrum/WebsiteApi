using Api.Data.Model;
using Api.Data.UnitOfWork;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dbo = Api.Data.Model;
using Dto = Api.Data.Services.DtoModels;

namespace Api.Data.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryService categoryService;

        public WebsiteService(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            Validated.NotNull(unitOfWork, nameof(unitOfWork));
            Validated.NotNull(categoryService, nameof(categoryService));
            this.unitOfWork = unitOfWork;
            this.categoryService = categoryService;
        }

        public async Task<IEnumerable<Dto.WebSite>> All()
        {
            // TODO: fix pagination - skip/take and sorting
            var websites = this.unitOfWork.WebSites.All();
            var categories = this.unitOfWork.Categories.All();

            var joined = websites.Join(
                categories,
                webSite => webSite.CategoryId,
                category => category.Id,
                (website, category) => new WebSite
                {
                    Id = website.Id,
                    Name = website.Name,
                    Url = website.Url,
                    SnapshotUrl = website.SnapshotUrl,
                    Category = category,
                    LoginEmail = website.LoginEmail,
                    LoginPassword = website.LoginPassword
                }
            );
            var result = await joined.ToListAsync();

            return result.Map();
        }

        public async Task<bool> Exists(long id)
        {
            var website = await this.unitOfWork.WebSites.GetById(id);
            return website.Id == id;
        }

        public async Task<Dto.WebSite> GetById(long id)
        {
            var website = await this.unitOfWork.WebSites.GetById(id);
            return website.Map();
        }

        public async Task<Dto.WebSite> GetByUrl(string url)
        {
            var website = await this.unitOfWork.WebSites.All().Where(w => w.Url == url).ToListAsync();

            return website.FirstOrDefault().Map();
        }

        public async Task<Dto.WebSite> Create(Dto.WebSite website)
        {
            Validated.NotNull(website, nameof(website));

            Dbo.Category category = await this.categoryService.GetByName(website.Category.Name);

            if (category == null)
            {
                category = await this.categoryService.Create(website.Category.Map());
            }

            website.Category.Id = category.Id;

            Dbo.WebSite addedWebsite = this.unitOfWork.WebSites.Add(website.Map());

            await this.unitOfWork.SaveChanges();

            return addedWebsite.Map();
        }

        public async Task<Dto.WebSite> Delete(long id)
        {
            var model = await this.unitOfWork.WebSites.GetById(id);
            Dbo.WebSite deletedWebsite = this.unitOfWork.WebSites.Delete(model);

            await this.unitOfWork.SaveChanges();

            return deletedWebsite.Map();
        }

        public async Task<Dto.WebSite> Update(Dto.WebSite website)
        {
            Validated.NotNull(website, nameof(website));

            Dbo.Category category = await this.categoryService.GetByName(website.Category.Name);

            if (category == null)
            {
                category = await this.categoryService.Create(website.Category.Map());
            }

            website.Category.Id = category.Id;

            Dbo.WebSite updatedWebsite = this.unitOfWork.WebSites.Update(website.Map());

            await this.unitOfWork.SaveChanges();

            return updatedWebsite.Map();
        }
    }
}
