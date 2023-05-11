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
                    "Error while fetching data");
            }
        }
        [HttpGet("{id:int}/GetHoursForEmployee")]
        public async Task<ActionResult<IEnumerable<Employee>>> EmployeeHours(int id,int weekNumber)
        {
            var response = await _repo.GetEmployeeHours(id,weekNumber);
            try
            {
                if (response != null)
                {
                    return Ok(response); 
                }
                return BadRequest("ID or week number does not exists in the database");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while fetching from database");

            }
        }
        [HttpGet("{id:int}/EmployeeandReports")]
        public async Task<ActionResult<Employee>> GetEmployeeandReports(int id)
        {
            var response = await _repo.GetEmployeeandReports(id);
            try
            {
                if(response != null)
                {
                    return Ok(response);
                }
                return BadRequest($"Employee with ID:{id} does not exist");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while fetching from database");
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
                   "Error while adding employee to database");
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

                return NotFound($"Employee with ID{id} does not exist");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while deleting from database");
            }
        }

        [HttpPut("/UpdateEmployee")]

        public async Task<ActionResult<Employee>> Update(int id, Employee employee)
        {
            try
            {
                if( id != employee.Id)
                {
                    return BadRequest($"User with ID {id} does not exist");
                }

                var response = await _repo.Update(employee);
                return await _repo.Update(employee);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while updating database");
            }
        }

        


    }
}
