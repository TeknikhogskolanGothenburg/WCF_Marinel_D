using Models;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BookingLogic
    {
        Data Data = new Data();

        CarLogic carLogic = new CarLogic();

        public List<Booking> GetActiveBookings(bool isStarted)
        {
            return Data.Bookings.Where(b =>
            b.ReturnTime == default(DateTime) && (isStarted ? b.IsStarted() : !b.IsStarted())).ToList();
        }

        public void CreateBooking(Car car, CustomerInfo customer, DateTime startTime, DateTime endTime)
        {
            List<Car> availableCars = carLogic.GetAvailableCars(startTime, endTime);
            if (car == null || customer == null || startTime == null || endTime == null || startTime > endTime ||
                !Data.Cars.Contains(car) || !Data.Customers.Contains(customer) ||
                !availableCars.Contains(car)) // makes sure car is available
            {
                throw new ArgumentException();
            }

            Data.Bookings.Add(
                new Booking
                {
                    Car = car,
                    CustomerInfo = customer,
                    StartTime = startTime,
                    EndTime = endTime,
                    ReturnTime = default(DateTime)
                }
            );
        }

        public void RemoveBooking(Booking booking)
        {
            if (booking == null || !Data.Bookings.Contains(booking) ||
                DateTime.Now >= booking.StartTime && booking.ReturnTime == default(DateTime)) // booking is active and did not return car
            {
                throw new ArgumentException();
            }

            Data.Bookings.Remove(booking);
        }

        public void ReturnCar(Booking booking)
        {
            if (booking == null || !Data.Bookings.Contains(booking) ||
                booking.ReturnTime != default(DateTime)) // already returned car
            {
                throw new ArgumentException();
            }

            booking.ReturnTime = DateTime.Now;
        }
    }
}
