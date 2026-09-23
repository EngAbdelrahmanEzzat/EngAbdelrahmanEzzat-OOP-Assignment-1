using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
   
    public class Guest
    {
        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

        private readonly List<Reservation> _reservations = [];

        public IReadOnlyList<Reservation> Reservations => _reservations;

        public Guest(int guestId, string fullName, string phoneNumber)
        {
            if (guestId <= 0)
                throw new ArgumentOutOfRangeException(               
                    "GuestId must be greater than zero.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException(
                    "Full name cannot be empty.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException(
                    "Phone number cannot be empty.");

            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public void AddReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation);
            _reservations.Add(reservation);
        }
    }


}
