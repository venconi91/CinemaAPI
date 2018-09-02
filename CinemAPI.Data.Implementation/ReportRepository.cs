using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Domain.Report;
using CinemAPI.Models.Contracts.Report;

namespace CinemAPI.Data.Implementation
{
    public class ReportRepository : IReportRepository
    {
        private readonly CinemaDbContext db;

        public ReportRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<IProjectionReport> FetchReportWithActiveProjections()
        {
            var report = db.Database.SqlQuery<ProjectionReport>("EXEC usp_FetchReportWithActiveProjections").ToList();
            return report;
        }
    }
}