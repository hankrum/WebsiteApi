using Api.Data.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Services
{
    public interface IWebsiteService
    {
        Task<IEnumerable<WebSite>> All();

        Task<bool> Exists(long id);

        Task<WebSite> GetById(long id);

        Task<WebSite> GetByUrl(string url);
        
        Task<WebSite> Create(WebSite category);

        Task<WebSite> Delete(long id);

        Task<WebSite> Update(WebSite model);
    }
}
