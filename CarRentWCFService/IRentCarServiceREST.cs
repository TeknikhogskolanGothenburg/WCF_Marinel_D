using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRentCarService" in both code and config file together.
    [ServiceContract]
    public interface IRentCarServiceREST
    {

        ////// Car REST \\\\\\
        

        [OperationContract(Name = "GetCarsServiceREST")]
        [WebGet(UriTemplate = "Cars", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Car> GetCarsService();

        [OperationContract(Name = "AddCarServiceREST")]
        [WebInvoke(Method = "POST", UriTemplate = "Car", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddCarService(string registrationNumber, string brand, string model, int year);

        [OperationContract(Name = "GetAvailableCarsServiceREST")]
        [WebGet(UriTemplate = "AvailableCars", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        List<Car> GetAvailableCarsService(DateTime fromDate, DateTime toDate);

        [OperationContract(Name = "RemoveCarServiceREST")]
        [WebInvoke(Method = "DELETE", UriTemplate = "Car/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void RemoveCarService(Car car);

        


    }
}
