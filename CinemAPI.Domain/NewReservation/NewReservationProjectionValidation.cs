using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
using System.Net;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationProjectionValidation : INewReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly INewReservation newReservation;

        public NewReservationProjectionValidation(IProjectionRepository projectionRepo, INewReservation newReservation)
        {
            this.projectionRepo = projectionRepo;
            this.newReservation = newReservation;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            IProjection projection = projectionRepo.GetById(reservation.ProjectionId);

            if (projection == null)
            {
                return new NewReservationSummary(HttpStatusCode.BadRequest, "Projection doesn't exist");
            }

            return newReservation.New(reservation);
        }
    }
}
