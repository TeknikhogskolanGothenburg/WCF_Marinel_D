using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Booking
    {
        [DataMember]
        public Car Car { get; set; }
        [DataMember]
        public CustomerInfo CustomerInfo { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
        [DataMember]
        public DateTime ReturnTime { get; set; }

        public override string ToString()
        {
            return (ReturnTime != default(DateTime) ? "[RETURNED]" : "[ACTIVE]") +
                $" {CustomerInfo.FirstName} {CustomerInfo.LastName} " +
                $"{StartTime}-{EndTime} {Car.ToString()}";
        }

        public bool IsStarted()
        {
            return DateTime.Now >= StartTime;
        }

    }
}
