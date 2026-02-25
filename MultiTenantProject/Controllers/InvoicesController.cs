using Microsoft.AspNetCore.Mvc;
using MultiTenantProject.BLL;
using MultiTenantProject.ViewModel;

namespace MultiTenantProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoicesController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvoiceDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged(int page = 1, int pageSize = 10)
        {
            var result = await _service.GetPagedAsync(page, pageSize);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.SoftDeleteAsync(id);
            return Ok();
        }
    }
}
