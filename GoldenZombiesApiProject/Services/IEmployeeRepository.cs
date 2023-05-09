namespace GoldenZombiesApiProject.Services
{
    public interface IEmployeeRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<Employee> Add(Employee newEmployee);
        Task<Employee> Update(Employee newEmployee);
        Task<Employee> Delete(int id);
        Task<IEnumerable<Employee>> GetEmployeeHours(int id, int weeknumber);
        Task<IEnumerable<Employee>> GetEmployeeProjects(int id);
    }
}
