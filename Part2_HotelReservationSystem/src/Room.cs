using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    
    public class Room
    {
        public enum RoomType
        {
            Single,
            Double,
            Suite
        }

        public int RoomNumber { get; }
        public RoomType Type { get; }
        public double NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }

        private readonly List<Reservation> _reservations = [];
        public IReadOnlyList<Reservation> Reservations => _reservations;

        public Room(
            int roomNumber,
            RoomType roomType,
            double nightlyRate,
            bool isUnderMaintenance)
        {
            if (roomNumber <= 0)
                throw new ArgumentOutOfRangeException(
                    "Room number must be greater than zero.");

            if (nightlyRate <= 0)
                throw new ArgumentOutOfRangeException(
                    "Nightly rate must be greater than zero.");

            RoomNumber = roomNumber;
            Type = roomType;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = isUnderMaintenance;
        }

        public void AddReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation);

            foreach (Reservation existingReservation in _reservations)
            {
                if (existingReservation.Status == Reservation.ReservationStatus.Cancelled ||
                    existingReservation.Status == Reservation.ReservationStatus.CheckedOut)
                {
                    continue;
                }

                bool overlap =
                    reservation.CheckInDate < existingReservation.CheckOutDate &&
                    reservation.CheckOutDate > existingReservation.CheckInDate;

                if (overlap)
                {
                    throw new InvalidOperationException(
                        "The room is already reserved during this period.");
                }
            }

            _reservations.Add(reservation);
        }

        public void ChangeNightlyRate(double newRate)
        {
            if (newRate <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(newRate),
                    "Nightly rate must be greater than zero.");

            NightlyRate = newRate;
        }

        public void StartMaintenance()
        {
            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            IsUnderMaintenance = false;
        }
    }


}
