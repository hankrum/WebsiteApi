using Api.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> All();

        bool IsEmpty();

        Task<Category> GetById(long id);

        Task<Category> GetByName(string name);

        Task<Category> Create(Category category);

        Task<Category> Delete(long id);

        Task<Category> Update(Category model);
    }
}
