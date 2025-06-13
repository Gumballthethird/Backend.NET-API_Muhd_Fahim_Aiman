using Microsoft.AspNetCore.Mvc;
using FreelancerApp.Application.DTOs;
using FreelancerApp.Application.Interfaces;

namespace FreelancerApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreelancersController : ControllerBase
    {
        private readonly IFreelancerService _service;

        public FreelancersController(IFreelancerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search = null)
        {
            var freelancers = await _service.GetAllAsync(search);
            return Ok(freelancers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var freelancer = await _service.GetByIdAsync(id);
            if (freelancer == null)
                return NotFound();

            return Ok(freelancer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FreelancerDto freelancerDto)
        {
            await _service.CreateAsync(freelancerDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FreelancerDto freelancerDto)
        {
            await _service.UpdateAsync(id, freelancerDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        } 

        [HttpPut("{id}/archive")]
        public async Task<IActionResult> Archive(Guid id)
        {
            await _service.ArchiveAsync(id);
            return NoContent();
        }


        [HttpPatch("{id}/unarchive")]
        public async Task<IActionResult> Unarchive(Guid id)
        {
            await _service.UnarchiveAsync(id);
            return NoContent();
        }
    }
}
