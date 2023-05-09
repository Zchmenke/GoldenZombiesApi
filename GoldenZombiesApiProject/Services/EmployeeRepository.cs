using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Services
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee newEmployee)
        {
            var employeeToAdd = await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return employeeToAdd.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var employeeToDelete = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                await _context.SaveChangesAsync();
                return employeeToDelete;
            }
            return null;
        }

        public async Task<Employee> Get(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeHours(int id, int weeknumber)
        {
            var employeeHours = await (from employee in _context.Employees
                                       join timeReport in _context.TimeReports on employee.Id equals timeReport.EmployeeId
                                       where employee.Id == id && timeReport.WeekNumber == weeknumber

                                       select new Employee
                                       {
                                           Id = employee.Id,
                                           FirstName = employee.FirstName,
                                           LastName = employee.LastName,

                                           TimeReports = new List<TimeReport>()
                                           {
                                               new TimeReport()
                                               {
                                                   Id = timeReport.Id,
                                                   EmployeeId = timeReport.EmployeeId,
                                                   WeekNumber = timeReport.WeekNumber,
                                                   HoursWorked = timeReport.HoursWorked
                                               }
                                           }
                                       }).ToListAsync();
            return employeeHours;
        }

      

        public async Task<Employee> Update(Employee newEmployee)
        {
            var employeeToUpdate = await _context.Employees
                 .FirstOrDefaultAsync(e => e.Id == newEmployee.Id);

            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = newEmployee.FirstName;
                employeeToUpdate.LastName = newEmployee.LastName;
                employeeToUpdate.Email = newEmployee.Email;
                employeeToUpdate.Title = newEmployee.Title;
            }
            await _context.SaveChangesAsync();
            return employeeToUpdate;
        }
    }
}
