using CinemAPI.Models.Contracts.Report;
using System;

namespace CinemAPI.Domain.Report
{
    public class ProjectionReport : IProjectionReport
    {
        public long ProjectionId { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public DateTime MovieStartDate { get; set; }

        public int Reservations { get; set; }

        public int AvailableSeats { get; set; }
    }
}
