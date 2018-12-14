using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

    [MessageContract(IsWrapped =true, WrapperName="CustomerRequestObject", WrapperNamespace = "http://localhost:8080/Customer")]
    public class CustomerRequest
    {
        [MessageHeader(Namespace = "http://localhost:8080/Customer")]
        public string LicensKey { get; set; }
    }


    [MessageContract(IsWrapped = true, WrapperName = "CustomerInfoObject", WrapperNamespace = "http://localhost:8080/Customer")]
    public class CustomerInfo
    {

        public CustomerInfo()
        {

        }

        public CustomerInfo(Customer customer)
        {
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.TelephoneNumber = customer.TelephoneNumber;
            this.Email = customer.Email;
        }


        [MessageBodyMember(Order=2, Namespace = "http://localhost:8080/Customer")]
        public string FirstName { get; set; }

        [MessageBodyMember(Order = 1, Namespace = "http://localhost:8080/Customer")]
        public string LastName { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://localhost:8080/Customer")]
        public string TelephoneNumber { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://localhost:8080/Customer")]
        public string Email { get; set; }




        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email} {TelephoneNumber}";
        }

        public bool IsValid()
        {
            if (FirstName == null || LastName == null || TelephoneNumber == null || Email == null)
            {
                return false;
            }
            return true;
        }

    }



    [DataContract]
    public class Customer
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string TelephoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }


    }
}
