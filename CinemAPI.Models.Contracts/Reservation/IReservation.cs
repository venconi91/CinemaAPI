namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservation
    {
        long Id { get; }

        short Row { get; }

        short Column { get; }

        long ProjectionId { get; }
    }
}
