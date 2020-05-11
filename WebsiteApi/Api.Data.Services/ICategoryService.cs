using Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> All();

        bool IsEmpty();

        Task<Category> GetById(long id);

        Task<Category> Create(Category category);

        Task<Category> Delete(long id);

        Task<Category> Update(Category model);
    }
}
