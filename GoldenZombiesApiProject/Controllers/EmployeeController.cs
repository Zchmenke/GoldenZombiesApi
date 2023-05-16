using AutoMapper;
using GoldenZombiesApiProject.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;
using ModelLibrary.DTO_s;
using System.Linq.Expressions;

namespace GoldenZombiesApiProject.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository<Employee> _repo;
        private readonly IMapper _map;
        public EmployeeController(IEmployeeRepository<Employee> repo,IMapper map)
        {
            this._repo = repo;
            _map = map;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetAllEmployees()
        {
            try
            {
                var employees = await _repo.GetAll();
                var dto = _map.Map<List<EmployeeDTO>>(employees); // Added DTO's for testing
                return Ok(dto);
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
                var dto = _map.Map<EmployeeDTO>(response); // Added DTO's for testing
                if (response != null)
                {
                    return Ok(dto);
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
