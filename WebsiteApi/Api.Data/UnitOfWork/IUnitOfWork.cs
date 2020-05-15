using Api.Data.Model;
using Api.Data.Repository;
using System.Threading.Tasks;

namespace Api.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEfRepository<WebSite> WebSites { get; }

        IEfRepository<Category> Categories { get; }

        Task<int> SaveChanges();
    }
}
