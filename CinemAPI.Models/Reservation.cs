using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Models
{
    public class Reservation : IReservation, IReservationCreation, IReservationSeat
    {
        public Reservation()
        {

        }

        public Reservation(short row, short col, long projectionId)
            : this()
        {
            this.Row = row;
            this.Column = col;
            this.ProjectionId = projectionId;
        }

        public long Id { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }

        public long ProjectionId { get; set; }
    }
}
