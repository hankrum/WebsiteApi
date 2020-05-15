using Api.Host.Controllers;
using System;
using Xunit;

namespace Api.Tests.Api.Host.Controllers.WebSiteControllerTests
{
    public class Constructor_Should
    {
        [Fact]
        public void Throw_When_WebsiteServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new WebSiteController(null));
        }
    }
}
