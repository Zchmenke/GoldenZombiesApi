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
        [HttpGet("/EmployeeandReports{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeandReports(int id)
        {
            var response = await _repo.GetEmployeeandReports(id);
            try
            {
                if(response != null)
                {
                    return Ok(response);
                }
                return BadRequest("Fel");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error");
            }
        }
        [HttpPost("/AddEmployee")]
        public async Task<ActionResult<Employee>> Add(Employee newemployee)
        {
            try
            {
                var response = await _repo.Add(newemployee);
                if(response != null)
                {
                    return Ok(response);
                }
                return null;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error");
            }
        }

        [HttpDelete("/DeleteEmployee")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var response = await _repo.Get(id);
                if(response != null)
                {
                   return await _repo.Delete(id);
                }

                return NotFound("Employee with ID does not exsist");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error");
            }
        }

        [HttpPut("/UpdateEmployee")]

        public async Task<ActionResult<Employee>> Update(int id, Employee employee)
        {
            try
            {
                if( id != employee.Id)
                {
                    return BadRequest("User ID dose not exsist");
                }

                var response = await _repo.Update(employee);
                return await _repo.Update(employee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error");
            }
        }

        


    }
}
