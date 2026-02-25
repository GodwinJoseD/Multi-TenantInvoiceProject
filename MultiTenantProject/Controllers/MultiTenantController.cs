using Microsoft.AspNetCore.Mvc;
using MultiTenantProject.BLL;

namespace MultiTenantProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MultiTenantController:ControllerBase
    {
        private readonly IMultiTenantService _service;

        public MultiTenantController(IMultiTenantService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] string name)
        {
            return Ok(_service.Create(name));
        }
    }
}
