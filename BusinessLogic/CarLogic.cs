using Models;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CarLogic
    {
        Data Data = new Data();

        public List<Car> GetCars()
        {
            return Data.Cars;
        }

        public void AddCar(string registrationNumber, string brand, string model, int year)
        {
            if (registrationNumber == null || registrationNumber.Length == 0 ||
                brand == null || brand.Length == 0 ||
                model == null || model.Length == 0 ||
                year < 1900 || year > DateTime.Now.Year)
            {
                throw new ArgumentException();
            }

            Data.Cars.Add(
                new Car
                {
                    RegistrationNumber = registrationNumber,
                    Brand = brand,
                    Model = model,
                    Year = year
                }
            );
        }

        public void RemoveCar(Car car)
        {
            if (car == null || !Data.Cars.Contains(car))
            {
                throw new ArgumentException();
            }

            Data.Cars.Remove(car);
        }

        public List<Car> GetAvailableCars(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null || toDate == null || fromDate > toDate)
            {
                throw new ArgumentException();
            }

            List<Car> cars = Data.Cars.ToList(); // all cars
            // the LINQ expression below gets bookings that are during the "fromDate" and "toDate" parameters
            List<Booking> currentActiveBookings = Data.Bookings.Where(b =>
                (b.StartTime >= fromDate && b.StartTime <= toDate || // if booking start time is within the fromDate to toDate timespan
                b.EndTime >= fromDate && b.EndTime <= toDate || // if booking end time is within the fromDate to toDate timespan
                b.StartTime <= fromDate && b.EndTime >= toDate) && // if booking covers the whole timespan
                b.ReturnTime == default(DateTime)) // if customer have not returned car
                .ToList();
            foreach (Booking b in currentActiveBookings)
            {
                if (cars.Contains(b.Car)) // failsafe
                {
                    cars.Remove(b.Car);
                }
            }
            return cars; // available cars (with occupied ones from bookings removed)
        }

    }
}
