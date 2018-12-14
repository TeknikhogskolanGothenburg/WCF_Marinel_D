using Models;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CustomerLogic
    {
        Data Data = new Data();

        public List<CustomerInfo> GetCustomers(CustomerRequest request)
        {
            return Data.Customers;
        }

        public void AddCustomer(CustomerInfo customerInfo)
        {
           
            CustomerInfo customerNew = new CustomerInfo
            {
                FirstName = customerInfo.FirstName,
                LastName = customerInfo.LastName,
                TelephoneNumber = customerInfo.TelephoneNumber,
                Email = customerInfo.Email
            };


            if (!customerNew.IsValid())
            {
                throw new ArgumentException();
            }

            Data.Customers.Add(customerNew);
        }

        public void ChangeCustomer(CustomerInfo customer, CustomerInfo newDetails, CustomerRequest request)
        {
            List<CustomerInfo> customers = GetCustomers(request);
            if (customer == null || !customers.Contains(customer) || newDetails == null || !newDetails.IsValid())
            {
                throw new ArgumentException();
            }

            int index = customers.FindIndex(c => c == customer);
            customers[index] = newDetails;
        }

        public void RemoveCustomer(CustomerInfo customer)
        {
            if (customer == null || !Data.Customers.Contains(customer))
            {
                throw new ArgumentException();
            }

            Data.Customers.Remove(customer);
        }


    }
}
