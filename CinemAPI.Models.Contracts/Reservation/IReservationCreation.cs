namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservationCreation
    {
        short Row { get; }

        short Column { get; }

        long ProjectionId { get; }
    }
}
