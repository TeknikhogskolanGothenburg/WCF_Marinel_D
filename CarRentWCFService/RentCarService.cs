using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;
using BusinessLogic;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RentCarService" in both code and config file together.
    public class RentCarService : IRentCarService, IRentCarServiceREST
    {
        BookingLogic _booking = new BookingLogic();
        CarLogic _car = new CarLogic();
        CustomerLogic _customer = new CustomerLogic();


        ////// Booking \\\\\\

        public List<Booking> GetActiveBookingsService(bool isStarted)
        {
            var returnBooking = _booking.GetActiveBookings(isStarted);
            return returnBooking;
        }

        public void CreateBookingService(Car car, CustomerInfo customer, DateTime startTime, DateTime endTime)
        {
            _booking.CreateBooking(car,customer,startTime,endTime);
        }

        public void RemoveBookingService(Booking booking)
        {
            _booking.RemoveBooking(booking);

        }

        public void ReturnCarService(Booking booking)
        {
            if (booking == null) 
                
            {
                throw new FaultException("Yours input are not correct, please try again");
            }

            _booking.ReturnCar(booking);


        }


        ////// Car \\\\\\
        
        public List<Car> GetCarsService()
        {
            var returnCars = _car.GetCars();
            return returnCars;
        }

        public void AddCarService(string registrationNumber, string brand, string model, int year)
        {
            if (registrationNumber == null || brand == null || model == null || year == 0   )
            {
                throw new FaultException("Yours input are not correct, please try again");
            }
            
            _car.AddCar(registrationNumber, brand, model, year);

        }

        public List<Car> GetAvailableCarsService(DateTime fromDate, DateTime toDate)
        {
            var availableCars = _car.GetAvailableCars(fromDate,toDate);
            return availableCars;

        }

        public void RemoveCarService(Car car)
        {
            _car.RemoveCar(car);
        }



        ////// Customer \\\\\\
        
        public List<CustomerInfo> GetCustomersService(CustomerRequest request)
        {
            var customerList =_customer.GetCustomers(request);
            return customerList;
        }

        public void AddCustomerService(CustomerInfo customerinfo)
        {

            if (customerinfo.FirstName == null || customerinfo == null || customerinfo == null || customerinfo == null)
            {
                throw new FaultException("Yours input are not correct, please try again");
            }
                
                _customer.AddCustomer(customerinfo);
        }

        public void ChangeCustomerService(CustomerInfo customer, CustomerInfo newDetails, CustomerRequest reques)
        {
            
            _customer.ChangeCustomer(customer,newDetails,reques);
        }

        public void RemoveCustomerService(CustomerInfo customer)
        {
            _customer.RemoveCustomer(customer);
        }




       
    }
}
