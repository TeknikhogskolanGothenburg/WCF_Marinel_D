using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRentCarService" in both code and config file together.
    [ServiceContract]
    public interface IRentCarService
    {
        ////// Booking \\\\\\
        [OperationContract]
        List<Booking> GetActiveBookingsService(bool isStarted);

        [OperationContract]
        void CreateBookingService(Car car, CustomerInfo customer, DateTime startTime, DateTime endTime);

        [OperationContract]
        void RemoveBookingService(Booking booking);

        [OperationContract]
        void ReturnCarService(Booking booking);



        ////// Car \\\\\\
        [OperationContract]
        List<Car> GetCarsService();

        [OperationContract]
        void AddCarService(string registrationNumber, string brand, string model, int year);

        [OperationContract]
        List<Car> GetAvailableCarsService(DateTime fromDate, DateTime toDate);

        [OperationContract]
        void RemoveCarService(Car car);



        ////// Customer \\\\\\
        ///[OperationContract]
        List<CustomerInfo> GetCustomersService(CustomerRequest request);

        [OperationContract]
        void AddCustomerService(CustomerInfo customerinfo);

        [OperationContract]
        void ChangeCustomerService(CustomerInfo customer, CustomerInfo newDetails, CustomerRequest customerRequest);

        [OperationContract]
        void RemoveCustomerService(CustomerInfo customer);



    }
}
