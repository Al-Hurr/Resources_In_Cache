using Microsoft.AspNetCore.Mvc;
using Resources_In_Cache.Models;
using Resources_In_Cache.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources_In_Cache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : Controller
    {
        private ResourceService _service;

        public ResourceController(ResourceService service)
        {
            _service = service;
        }

        [BindProperty]
        public ResourceCreateModel ResourceCreateModel { get; set; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> GetAll()
        {
            return await Task.Run(() => _service.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> Get(Guid id)
        {
            return await Task.Run(() => _service.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            await Task.Run(() => _service.Create(ResourceCreateModel));
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            await Task.Run(() => _service.Update(id));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Task.Run(() => _service.Remove(id));

            return NoContent();
        }
    }
}
