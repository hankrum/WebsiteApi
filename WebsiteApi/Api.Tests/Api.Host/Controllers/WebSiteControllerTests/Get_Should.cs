using Api.Data.Services;
using Api.Host.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Api.Host.Controllers.WebSiteControllerTests
{
    public class Get_Should { 
        private readonly Mock<IWebsiteService> webSiteServiceMock;

        public Get_Should()
        {
            webSiteServiceMock = new Mock<IWebsiteService>();
        }
    
        [Fact]
        public async Task ReturnNull_When_WebSiteServiceReturnsNull()
        {
            webSiteServiceMock.Setup(service => service.All()).ReturnsAsync(() => null);

            var controller = new WebSiteController(webSiteServiceMock.Object);

            var sut = await controller.Get();
            
            Assert.NotNull(sut.Result as NoContentResult);
        }
    }
}
