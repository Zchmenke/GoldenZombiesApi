using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Services
{
    public class TimeReportRepository : ITimeReportRepository<TimeReport>
    {
        private Context _context;
        public TimeReportRepository(Context context)
        {
            this._context = context;
        }
        public async Task<TimeReport> Add(TimeReport timeReport)
        {
            var timereportADD = await _context.TimeReports.AddAsync(timeReport);
            await _context.SaveChangesAsync();
            return timereportADD.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var timereporttoDelete = await _context.TimeReports.FirstOrDefaultAsync(t => t.Id == id);
            if(timereporttoDelete != null)
            {
                _context.TimeReports.Remove(timereporttoDelete);
                await _context.SaveChangesAsync();
                return timereporttoDelete;
            }
            return null;
        }

        public async Task<TimeReport> Get(int id)
        {
            return await _context.TimeReports.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _context.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> Update(TimeReport timeReport)
        {
            var timereporttoUpdate = await _context.TimeReports.FirstOrDefaultAsync(t => t.Id == timeReport.Id);

            if(timereporttoUpdate != null)
            {
                timereporttoUpdate.WeekNumber = timeReport.WeekNumber;
                timereporttoUpdate.HoursWorked = timeReport.HoursWorked;
                timereporttoUpdate.ProjectId = timeReport.ProjectId;
                timereporttoUpdate.EmployeeId = timeReport.EmployeeId;
            }
            await _context.SaveChangesAsync();
            return timereporttoUpdate;
        }
    }
}
