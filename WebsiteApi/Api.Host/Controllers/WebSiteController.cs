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
        public async Task<ActionResult<IEnumerable<WebSite>>> Get()
        {
            // TODO: pagination and sorting
            var result = await this.websiteService.All();

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET: api/WebSite/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<WebSite>> Get(int id)
        {
            var website = await this.websiteService.GetById(id);

            if (website == null)
            {
                return NotFound();
            }

            return Ok(website);
        }

        // POST: api/WebSite
        [HttpPost]
        public async Task<ActionResult<WebSite>> Post([FromBody] WebSite webSite)
        {
            var result = await this.websiteService.Create(webSite);

            return CreatedAtAction(
                nameof(this.Post),
                new {id = webSite.Id }, 
                result
            );
        }

        // PUT: api/WebSite/5
        [HttpPut("{id}")]
        public async Task<ActionResult<WebSite>> Put(long id, [FromBody] WebSite webSite)
        {
            if (id != webSite.Id)
            {
                return BadRequest();
            }

            if (!await this.websiteService.Exists(id))
            {
                return NotFound();
            }

            var result = await this.websiteService.Update(webSite);

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebSite>> Delete(int id)
        {
            if (!await this.websiteService.Exists(id))
            {
                return NotFound();
            }

            var result = await this.websiteService.Delete(id);

            return result;
        }
    }
}
