using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Domain.Contracts.Models
{
    public class ReservationSeat : IReservationSeat
    {
        public short Row { get; set;  }

        public short Column { get; set;  }
    }
}
