using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public string RegistrationNumber { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} {Year} {RegistrationNumber}";
        }

    }
}
