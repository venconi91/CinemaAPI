﻿namespace CinemAPI.Models.Input.Reservation
{
    public class ReservationCreationModel
    {
        public long ProjectionId { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}