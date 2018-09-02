using System;

namespace CinemAPI.Models.Contracts.Report
{
    public interface IProjectionReport
    {
        long ProjectionId { get; set; }

        string MovieName { get; set; }

        string CinemaName { get; set; }

        int RoomNumber { get; set; }

        DateTime MovieStartDate { get; set; }

        int Reservations { get; set; }

        int AvailableSeats { get; set; }
    }
}
