using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Data
{
    public interface IReservationRepository
    {
        IReservation Get(short row, short col, long projectionId);

        void Insert(IReservationCreation reservation);
    }
}
