using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        DbSet<Employee> Employees { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<TimeReport> TimeReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Henrik", LastName = "Rydén", Email = "Henriks.Mail@Hotmail.com", Title = "Junior" },
                new Employee { Id = 1, FirstName = "Henrik", LastName = "Rydén", Email = "Henriks.Mail@Hotmail.com", Title = "Junior" }

                );
        }


    }
}
