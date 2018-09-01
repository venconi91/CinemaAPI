using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Data.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaDbContext db;

        public ReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IReservation Get(short row, short col, long projectionId)
        {
            return db.Reservations.FirstOrDefault(r => r.Row == row &&
                                                       r.Column == col &&
                                                       r.ProjectionId == projectionId);
        }

        public void Insert(IReservationCreation reservation)
        {
            Reservation newReservation = new Reservation(reservation.Row, reservation.Column, reservation.ProjectionId);

            db.Reservations.Add(newReservation);
            db.SaveChanges();
        }
    }
}
