//using Api.Data.Model;
//using Api.Data.UnitOfWork;
//using Api.Infrastructure;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Api.Data.Services
//{
//    public class CategoryService : ICategoryService
//    {
//        private readonly IUnitOfWork unitOfWork;

//        public CategoryService(IUnitOfWork unitOfWork)
//        {
//            Validated.NotNull(unitOfWork, nameof(unitOfWork));
//            this.unitOfWork = unitOfWork;
//        }

//        public async Task<IEnumerable<Category>> All()
//        {
//            IEnumerable<Category> categories = await this.unitOfWork.Categories.All.ToListAsync();
//            return categories;
//        }

//        public async Task<Category> GetById(long id)
//        {
//            return await this.unitOfWork.Categories.GetById(id);
//        }

//        public bool IsEmpty()
//        {
//            return !this.unitOfWork.Categories.All.Any();
//        }

//        public async Task<Category> Create(Category category)
//        {
//            Validated.NotNull(category, nameof(category));

//            Category addedCategory = this.unitOfWork.Categories.Add(category);

//            await this.unitOfWork.SaveChanges();

//            return addedCategory;
//        }

//        public async Task<Category> Delete(long id)
//        {
//            var model = await this.unitOfWork.Categories.GetById(id);
//            Category deletedCategory = this.unitOfWork.Categories.Delete(model);

//            await this.unitOfWork.SaveChanges();

//            return deletedCategory;
//        }

//        public async Task<Category> Update(Category category)
//        {
//            Validated.NotNull(category, nameof(category));

//            Category updatedCategory = this.unitOfWork.Categories.Update(category);

//            await this.unitOfWork.SaveChanges();

//            return updatedCategory;
//        }
//    }
//}
