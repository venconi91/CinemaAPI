using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Room;
using CinemAPI.Models.Input.Reservation;
using System.Net.Http;
using System.Web.Http;

namespace CinemAPI.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationRepository reservationRepo;
        private readonly INewReservation newReservation;
        private readonly IProjectionRepository projectionRepo;
        private readonly IRoomRepository roomRepo;

        public ReservationController(IReservationRepository reservationRepo, INewReservation newReservation, IProjectionRepository projectionRepo, IRoomRepository roomRepo)
        {
            this.reservationRepo = reservationRepo;
            this.newReservation = newReservation;
            this.projectionRepo = projectionRepo;
            this.roomRepo = roomRepo;
        }

        [HttpGet]
        public IHttpActionResult Index([FromUri] ReservationFetchModel model)
        {
            IProjection projection = projectionRepo.GetById(model.ProjectionId);
            // TODO: implement validation in decorator
            if (projection == null)
            {
                return BadRequest();
            }

            IRoom room = roomRepo.GetById(projection.RoomId);

            var availableSeats = reservationRepo.GetAvailableSeats(model.ProjectionId, room);

            return Ok(availableSeats);
        }

        [HttpPost]
        public HttpResponseMessage Index(ReservationCreationModel model)
        {
            NewReservationSummary summary = newReservation.New(new Reservation(model.Row, model.Column, model.ProjectionId));
            return Request.CreateResponse(summary.StatusCode, summary.Message); // TODO: fix null send to client when status is 200 OK
        }
    }
}
