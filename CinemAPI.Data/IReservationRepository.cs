using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IReservationRepository
    {
        IReservation Get(short row, short col, long projectionId);

        IEnumerable<IReservationSeat> GetAvailableSeats(long projectionId, IRoom room);

        void Insert(IReservationCreation reservation);
    }
}
