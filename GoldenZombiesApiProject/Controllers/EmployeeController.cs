using GoldenZombiesApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using System.Linq.Expressions;

namespace GoldenZombiesApiProject.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository<Employee> _repo;
        public EmployeeController(IEmployeeRepository<Employee> repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetAllEmployees()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Employee>>> EmployeeHours(int id,int weekNumber)
        {
            var response = await _repo.GetEmployeeHours(id,weekNumber);
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
        [HttpGet("{id:int}/projects")]
        public async Task<ActionResult<Employee>> EmployeeProjects(int id)
        {
            var response = await _repo.Get(id);
            try
            {
                if (response != null)
                {
                    return response;
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
