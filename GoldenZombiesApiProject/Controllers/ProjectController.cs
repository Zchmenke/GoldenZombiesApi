using GoldenZombiesApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectRepository<Project> _repo;
        public ProjectController(IProjectRepository<Project> repo)
        {
            _repo = repo;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetEmployees(int id)
        {
            var response = await _repo.GetAllEmployees(id);
            try
            {
                if (response != null)
                {
                    return Ok(response);
                }
                return BadRequest("FEL");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error");

            }
        }

    }
}
