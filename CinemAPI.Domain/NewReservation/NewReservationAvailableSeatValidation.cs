using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationAvailableSeatValidation : INewReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly INewReservation newReservation;

        public NewReservationAvailableSeatValidation(IReservationRepository reservationRepo, INewReservation newReservation)
        {
            this.reservationRepo = reservationRepo;
            this.newReservation = newReservation;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            IReservation foundReservation = reservationRepo.Get(reservation.Row, reservation.Column, reservation.ProjectionId);

            if (foundReservation == null)
            {
                return newReservation.New(reservation);
            }

            return new NewReservationSummary(System.Net.HttpStatusCode.Forbidden, "Seat is not available");
        }
    }
}
