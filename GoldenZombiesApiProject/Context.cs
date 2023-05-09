using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Henrik", LastName = "Rydén", Email = "Henriks.Mail@Hotmail.com", Title = "Junior" },
                new Employee { Id = 2, FirstName = "Kenny", LastName = "Lindblom", Email = "Kenny.Mail@Hotmail.com", Title = "Junior" },
                new Employee { Id = 3, FirstName = "John", LastName = "Albrektsson", Email = "John.Mail@Hotmail.com", Title = "Junior" },
                new Employee { Id = 4, FirstName = "Lars", LastName = "Laxsson", Email = "Lars.Mail@Hotmail.com", Title = "Senior" },
                new Employee { Id = 5, FirstName = "Johanna", LastName = "Svensson", Email = "Johanna.Mail@Hotmail.com", Title = "Senior" }

                );
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, ProjectName = "BankApplication", ProjectStart = new DateTime(2023, 2, 2), ProjectEnd = new DateTime(2023, 4, 4), IsActive = true },
                new Project { Id = 2, ProjectName = "ShoppingWebsite", ProjectStart = new DateTime(2021, 1, 4), ProjectEnd = new DateTime(2023, 4, 4), IsActive = true },
                new Project { Id = 3, ProjectName = "Build API", ProjectStart = new DateTime(2022, 4, 3), ProjectEnd = new DateTime(2023, 5, 5), IsActive = true },
                new Project { Id = 4, ProjectName = "Quiz Game", ProjectStart = new DateTime(2022, 4, 3), IsActive = false },
                new Project { Id = 5, ProjectName = "Desktop Application", ProjectStart = new DateTime(2022, 2, 3), ProjectEnd = new DateTime(2023, 6, 9), IsActive = true }


                );
            modelBuilder.Entity<TimeReport>().HasData(
                new TimeReport { Id = 1, EmployeeId = 1, HoursWorked = 40.20, ProjectId = 1, WeekNumber = 8, },
                new TimeReport { Id = 2, EmployeeId = 1, HoursWorked = 10.20, ProjectId = 2, WeekNumber = 7, },
                new TimeReport { Id = 3, EmployeeId = 2, HoursWorked = 20.40, ProjectId = 1, WeekNumber = 8, },
                new TimeReport { Id = 4, EmployeeId = 2, HoursWorked = 22.30, ProjectId = 4, WeekNumber = 4, },
                new TimeReport { Id = 5, EmployeeId = 3, HoursWorked = 20.20, ProjectId = 4, WeekNumber = 7, },
                new TimeReport { Id = 6, EmployeeId = 3, HoursWorked = 30.10, ProjectId = 2, WeekNumber = 6, },
                new TimeReport { Id = 7, EmployeeId = 4, HoursWorked = 40.20, ProjectId = 5, WeekNumber = 8, },
                new TimeReport { Id = 8, EmployeeId = 4, HoursWorked = 30.20, ProjectId = 4, WeekNumber = 7, },
                new TimeReport { Id = 9, EmployeeId = 5, HoursWorked = 20.20, ProjectId = 1, WeekNumber = 4, },
                new TimeReport { Id = 10, EmployeeId = 5, HoursWorked = 30.10, ProjectId = 3, WeekNumber = 6, }


                );
        }


    }
}
