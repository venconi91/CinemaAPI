using CinemAPI.Data;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportRepository reportsRepo;

        public ReportController(IReportRepository reportsRepo)
        {
            this.reportsRepo = reportsRepo;
        }

        [HttpGet]
        public IHttpActionResult Reservations()
        {
            return Ok(reportsRepo.FetchReportWithActiveProjections());
        }
    }
}
