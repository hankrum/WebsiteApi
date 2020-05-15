using Api.Data.Model;
using Api.Data.Repository;
using Api.Data.Services;
using Api.Data.UnitOfWork;
using Moq;
using Xunit;

namespace Api.Tests.Api.Data.Services.CategoryServiceTests
{
    public class All_Should 
    { 
        Mock<IUnitOfWork> unitOfWorkMock;

        public All_Should()
        {
            this.unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void CallUnitOfWorkAllAndReturnCategories()
        {
            var categoriesMock = new Mock<IEfRepository<Category>>();
            categoriesMock.Setup(cat => cat.All());
            unitOfWorkMock.Setup(unit => unit.Categories).Returns(categoriesMock.Object);

            var service = new CategoryService(unitOfWorkMock.Object);
            var sut = service.All();

            categoriesMock.Verify(cat => cat.All(), Times.Once());
        }
    }
}
