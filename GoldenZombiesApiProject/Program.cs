using GoldenZombiesApiProject.Services;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection-Henrik")));

            builder.Services.AddScoped<IEmployeeRepository<Employee>,EmployeeRepository>();
            builder.Services.AddScoped<IProjectRepository<Project>,ProjectRepository>();
            builder.Services.AddScoped<ITimeReportRepository<TimeReport>,TimeReportRepository>();

             var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}