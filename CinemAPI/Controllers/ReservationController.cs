using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Input.Reservation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CinemAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly INewReservation newReservation;

        public ReservationController(INewReservation newReservation)
        {
            this.newReservation = newReservation;
        }

        [HttpPost]
        public HttpResponseMessage Index(ReservationCreationModel model)
        {
            NewReservationSummary summary = newReservation.New(new Reservation(model.Row, model.Column, model.ProjectionId));
            return Request.CreateResponse(summary.StatusCode, summary.Message); // TODO: fix null send to client when status is 200 OK
        }
    }
}
