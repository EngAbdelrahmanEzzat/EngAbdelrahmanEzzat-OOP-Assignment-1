using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
   
    public class Program
    {
        static void Main(string[] args)
        {
            Guest guest = new Guest(
                1,
                "Abdelrahman Ezzat",
                "01000000000");

            Room room = new Room(
                101,
                Room.RoomType.Single,
                1000,
                false);

            Reservation reservation = new Reservation(
                1,
                new DateTime(2026, 9, 25),
                new DateTime(2026, 9, 28),
                room,
                guest);

            room.AddReservation(reservation);
            guest.AddReservation(reservation);

            reservation.Confirm();
            reservation.CheckIn();

            Console.WriteLine($"Guest: {guest.FullName}");
            Console.WriteLine($"Room: {room.RoomNumber}");
            Console.WriteLine($"Status: {reservation.Status}");
            Console.WriteLine($"Total Cost: {reservation.GetTotalCost()}");

            reservation.CheckOut();

            Console.WriteLine($"Status: {reservation.Status}");
        }
    }


}
