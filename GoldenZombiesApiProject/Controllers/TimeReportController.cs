using GoldenZombiesApiProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {

        private ITimeReportRepository<TimeReport> _repo;
        public TimeReportController(ITimeReportRepository<TimeReport> repo)
        {
            _repo = repo;
        }

        [HttpGet("/ GetAllReports")]
        public async Task<ActionResult<TimeReport>> GetAll()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while retrieving from database");
            }
        }

        [HttpGet("{id:int}/GetSingleReport")]
        public async Task<ActionResult<TimeReport>> Get(int id)
        {
            try
            {
                return Ok(await _repo.Get(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error while retrieving from database");
            }
        }
        [HttpPost("/AddNewReport")]
        public async Task<ActionResult<TimeReport>> Add(TimeReport report)
        {
            try
            {
                var CreateReport = await _repo.Add(report);
                if (CreateReport != null)
                {
                    return Ok(CreateReport);
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error while adding to the database");
            }
        }
        [HttpDelete("/DeleteReport")]
        public async Task<ActionResult<TimeReport>> Delete(int id)
        {
            try
            {
                var reportToDelete = await _repo.Get(id);
                if (reportToDelete != null)
                {
                    return await _repo.Delete(id);
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error while deleting from the database");
            }
        }
        [HttpPut("/UpdateReport")]
        public async Task<ActionResult<TimeReport>> Update(int id, TimeReport timeReport)
        {
            try
            {
                if (id != timeReport.Id)
                {
                    return BadRequest($"Requested ID {id} Does not match ");
                }
                var reportToUpdate = await _repo.Get(id);
                return await _repo.Update(timeReport);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Was not able to update choosen Report");
            }

        }
    }
}
