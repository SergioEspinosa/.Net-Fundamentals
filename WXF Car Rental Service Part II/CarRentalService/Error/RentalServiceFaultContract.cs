using System;
using System.Runtime.Serialization;

namespace CarRentalService.Error
{
    [DataContract]
    public class RentalServiceFaultContract
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string TicketNumber { get; set; }
    }
}
