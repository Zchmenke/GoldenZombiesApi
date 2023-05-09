namespace GoldenZombiesApiProject.Services
{
    public interface IProjectRepository<Project>
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> Get(int id);
        Task<Project> Add(Project project);
        Task<Project> Update(Project project);
        Task<Project> Delete(int id);
        Task<IEnumerable<Project>> GetAllEmployees(int id);
    }
}
