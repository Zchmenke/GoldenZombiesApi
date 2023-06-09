﻿using GoldenZombiesApiProject.Services;
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

        [HttpGet("{id:int}/GetAllProjectEmployees")]
        public async Task<ActionResult<Project>> GetEmployees(int id)
        {
            var response = await _repo.GetAllEmployees(id);
            try
            {
                if (response != null)
                {
                    return Ok(response);
                }
                return BadRequest($"Project with ID:{id} does not exist");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while fetching from database");

            }
        }

        [HttpGet("/GetAllProjects")]

        public async Task<ActionResult<Project>> GetAll()
        {
            try
            {
                return Ok(await _repo.GetAll());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while fetching from database");
            }
        }

        [HttpGet("/GetSingelProject")]

        public async Task<ActionResult<Project>> Get(int id)
        {
            try
            {
                return Ok(await _repo.Get(id));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while fetching from database");
            }
        }

        [HttpPost("/CreateNewProject")]

        public async Task<ActionResult<Project>> Add(Project newProject)
        {
            try
            {
                var CreateProject = await _repo.Add(newProject);

                if(CreateProject != null)
                {
                    return Ok(CreateProject);
                }
                return null;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while adding to database");
            }
        }

        [HttpDelete("/DeleteProject")]

        public async Task<ActionResult<Project>> Delete(int id)
        {
            try
            {
                var deleteProject = await _repo.Get(id);

                if(deleteProject != null)
                {
                    return await _repo.Delete(id);
                }
                return null;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while deleting from database");
            }
        }

        [HttpPut("/UpdateProject")]

        public async Task<ActionResult<Project>> Update(int id, Project project)
        {
            try
            {
                if(id != project.Id)
                {
                    return BadRequest($"Project ID:{id} do not exist");
                }

                var ProjectUpdate = await _repo.Get(id);

                return await _repo.Update(project);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error while updating database");
            }
        }


    }
}
