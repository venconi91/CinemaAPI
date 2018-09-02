namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservationSeat
    {
        short Row { get; }

        short Column { get; }
    }
}
