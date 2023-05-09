using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Services
{
    public class ProjectRepository : IProjectRepository<Project>
    {
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
    }
}
