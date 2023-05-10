using ModelLibrary.Models;

namespace GoldenZombiesApiProject.Services
{
    public interface ITimeReportRepository<TimeReport>
    {
        Task<IEnumerable<TimeReport>> GetAll();
        Task<TimeReport> Get(int id);
        Task<TimeReport> Update(TimeReport timeReport);
        Task<TimeReport> Delete(int id);
        Task<TimeReport> Add(TimeReport timeReport);
    }
}
