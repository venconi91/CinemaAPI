using CinemAPI.Models.Contracts.Report;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IReportRepository
    {
        IEnumerable<IProjectionReport> FetchReportWithActiveProjections();
    }
}
