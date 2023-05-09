using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Services
{
    public class ProjectRepository : IProjectRepository<Project>
    {
        private Context _context;
        public ProjectRepository(Context _context)
        {
            this._context = _context;
        }
        public Task<Project> Add(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Project> Update(Project project)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Project>> GetAllEmployees(int id) // Eventuellt fel på Join syntax
        {
            

            var employeeProjects = await (from project in _context.Projects
                                         join timeReport in _context.TimeReports on project.Id equals timeReport.ProjectId
                                         join employee in _context.Employees on timeReport.EmployeeId equals employee.Id
                                         where project.Id == id
                                         select project).ToListAsync();
            return employeeProjects;

        }
    }
}
