using Api.Data.UnitOfWork;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = Api.Data.Services.DtoModels;

namespace Api.Data.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IUnitOfWork unitOfWork;
//        private readonly ICategoryService categoryService;

        public WebsiteService(IUnitOfWork unitOfWork)
        {
            Validated.NotNull(unitOfWork, nameof(unitOfWork));
//            Validated.NotNull(categoryService, nameof(categoryService));
            this.unitOfWork = unitOfWork;
//            this.categoryService = categoryService;
        }

        public async Task<IEnumerable<Dto.WebSite>> All()
        {
            // TODO: fix pagination and sorting
            var websites = await this.unitOfWork.WebSites.All(0, null).ToListAsync();

            return websites.Map();
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

        public async Task<Dto.WebSite> Create(Dto.WebSite website)
        {
            Validated.NotNull(website, nameof(website));

            Dto.WebSite addedWebsite = this.unitOfWork.WebSites.Add(website.Map()).Map();

            await this.unitOfWork.SaveChanges();

            return addedWebsite;
        }

        public async Task<Dto.WebSite> Delete(long id)
        {
            var model = await this.unitOfWork.WebSites.GetById(id);
            Dto.WebSite deletedWebsite = this.unitOfWork.WebSites.Delete(model).Map();

            await this.unitOfWork.SaveChanges();

            return deletedWebsite;
        }

        public async Task<Dto.WebSite> Update(Dto.WebSite website)
        {
            Validated.NotNull(website, nameof(website));

            Dto.WebSite updatedWebsite = this.unitOfWork.WebSites.Update(website.Map()).Map();

            await this.unitOfWork.SaveChanges();

            return updatedWebsite;
        }
    }
}
