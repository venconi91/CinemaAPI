using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;
using System.Net;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationExistingSeatValidation : INewReservation
    {
        private readonly IProjectionRepository projectionRepo;
        private readonly IRoomRepository roomRepo;
        private readonly INewReservation newReservation;

        public NewReservationExistingSeatValidation(IProjectionRepository projectionRepo, IRoomRepository roomRepo, INewReservation newReservation)
        {
            this.projectionRepo = projectionRepo;
            this.roomRepo = roomRepo;
            this.newReservation = newReservation;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            int roomId = projectionRepo.GetById(reservation.ProjectionId).RoomId;
            IRoom room = roomRepo.GetById(roomId);

            if (reservation.Row > room.Rows)
            {
                return new NewReservationSummary(HttpStatusCode.BadRequest, "Row doesn't exist for the room of the projection");
            }
            else if (reservation.Column > room.SeatsPerRow)
            {
                return new NewReservationSummary(HttpStatusCode.BadRequest, "Column doesn't exist for the room of the projection");
            }

            return newReservation.New(reservation);
        }
    }
}
