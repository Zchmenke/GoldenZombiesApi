using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Services
{
    public class TimeReportRepository : ITimeReportRepository<TimeReport>
    {
        public Task<TimeReport> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TimeReport>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TimeReport> Update(TimeReport timeReport)
        {
            throw new NotImplementedException();
        }
    }
}
