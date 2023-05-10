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
        public async Task<IEnumerable<object>> GetAllEmployees(int id) // ändrade till object så vi kan ta emot vilket object som helst.
        {
            

            var employeeProjects = await (from project in _context.Projects 
                                         join timeReport in _context.TimeReports on project.Id equals timeReport.ProjectId
                                         join employee in _context.Employees on timeReport.EmployeeId equals employee.Id // Joins är desamma.

                                         where project.Id == id   // ändrade från employeeId till project.id eftersom vi ska kolla vilka som jobbar med det "ProjectId:et"
                                         select employee).ToListAsync(); // gjorde en lista av employees istället för project.
            return employeeProjects; // returnerar nu en lista av employees, tidigare var det en lista av projekt.

        }
    }
}
