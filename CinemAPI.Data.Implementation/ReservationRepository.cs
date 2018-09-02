using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;

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

        private IEnumerable<IReservationSeat> GetReserved(long projectionId)
        {
            return db.Reservations.Where(r => r.ProjectionId == projectionId).ToList<IReservationSeat>();
        }

        public IEnumerable<IReservationSeat> GetAvailableSeats(long projectionId, IRoom room)
        {
            var reserved = (List<IReservationSeat>)GetReserved(projectionId);

            var availableSeats = new List<IReservationSeat>();

            for (short row = 1; row <= room.Rows; row++)
            {
                for (short col = 1; col <= room.SeatsPerRow; col++)
                {
                    if (reserved.Find(r => r.Row == row && r.Column == col) == null)
                    {
                        availableSeats.Add(new ReservationSeat() { Column = col, Row = row });
                    }
                }
            }

            return availableSeats;
        }

        public void Insert(IReservationCreation reservation)
        {
            Reservation newReservation = new Reservation(reservation.Row, reservation.Column, reservation.ProjectionId);

            db.Reservations.Add(newReservation);
            db.SaveChanges();
        }
    }
}
