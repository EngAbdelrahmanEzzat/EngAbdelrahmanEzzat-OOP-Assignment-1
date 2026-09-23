using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
   
    public class Reservation
    {
        public enum ReservationStatus
        {
            Pending,
            Confirmed,
            CheckedIn,
            CheckedOut,
            Cancelled
        }

        public int ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public Room Room { get; }
        public Guest Guest { get; }
        public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;

        public Reservation(
            int reservationId,
            DateTime checkInDate,
            DateTime checkOutDate,
            Room room,
            Guest guest)
        {
            if (reservationId <= 0)
                throw new ArgumentOutOfRangeException(              
                    "Reservation ID must be greater than zero.");

            ArgumentNullException.ThrowIfNull(room);
            ArgumentNullException.ThrowIfNull(guest);

            if (checkInDate >= checkOutDate)
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException(
                    "The room is under maintenance.");

            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Guest = guest;
        }

        public double GetTotalCost()
        {
            TimeSpan t = CheckOutDate - CheckInDate;
            return Room.NightlyRate * t.Days;
        }

        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
                throw new InvalidOperationException(
                    "Only a pending reservation can be confirmed.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException(
                    "Only a confirmed reservation can be checked in.");

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new InvalidOperationException(
                    "Only a checked-in reservation can be checked out.");

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending &&
                Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException(
                    "Only a pending or confirmed reservation can be cancelled.");

            Status = ReservationStatus.Cancelled;
        }
    }


}
