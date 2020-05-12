using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Services.DtoModels;
using Api.Data.Services;
using Api.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebSiteController : ControllerBase
    {
        private IWebsiteService websiteService;

        public WebSiteController(IWebsiteService websiteService)
        {
            Validated.NotNull(websiteService, nameof(websiteService));
            this.websiteService = websiteService;
        }

        // GET: api/WebSite
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // TODO: pagination and sorting
            var result = await this.websiteService.All();

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        //// GET: api/WebSite/5
        //[HttpGet("{id}", Name = "Get")]
        //public Task<IActionResult> Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/WebSite
        [HttpPost]
        public async Task<WebSite> Post([FromBody] WebSite webSite)
        {
            var result = await this.websiteService.Create(webSite);

            return result;
        }

        // PUT: api/WebSite/5
        [HttpPut("{id}")]
        public async Task<WebSite> Put(long id, [FromBody] WebSite webSite)
        {
            var result = await this.websiteService.Update(webSite);

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
