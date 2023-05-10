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
        public async Task<Project> Add(Project project)
        {
            var projecttoAdd = await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return projecttoAdd.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var projecttoDelete = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if(projecttoDelete != null)
            {
                _context.Projects.Remove(projecttoDelete);
                await _context.SaveChangesAsync();
            }
            return projecttoDelete;
        }

        public Task<Project> Get(int id)
        {
            return _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> Update(Project project)
        {
            var projecttoUpdate = await _context.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if(projecttoUpdate != null)
            {
                projecttoUpdate.ProjectName = project.ProjectName;
                projecttoUpdate.ProjectStart = project.ProjectStart;
                projecttoUpdate.ProjectEnd = project.ProjectEnd;
                projecttoUpdate.IsActive = project.IsActive;

                await _context.SaveChangesAsync();
            }
            return projecttoUpdate;
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
