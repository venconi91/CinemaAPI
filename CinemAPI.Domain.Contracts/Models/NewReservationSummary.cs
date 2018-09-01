using System.Net;

namespace CinemAPI.Domain.Contracts.Models
{
    public class NewReservationSummary
    {
        public NewReservationSummary(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public NewReservationSummary(HttpStatusCode statusCode, string msg)
            : this(statusCode)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
