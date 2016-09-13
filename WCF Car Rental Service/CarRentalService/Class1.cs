namespace CarRentalService
{
    using System.ServiceModel;
    using System.Runtime.Serialization;

    [DataContract]
    public class ReservationInfo
    {
        [DataMember]
        public int VehicleClass;
        [DataMember]
        public int Location;
        [DataMember]
        public string Dates;
        [DataMember]
        public string CorrelationId;
    }

    [ServiceContract]
    interface IReservations
    {
        [OperationContract]
        bool Check(ReservationInfo info);
        [OperationContract(IsOneWay =true)]
        void Reserve(ReservationInfo info);
        [OperationContract]
        bool Cancel(int confirmationNumber);
        [OperationContract]
        int GetStats();
        [OperationContract]
        int GetConfirmationNumber(string correlationId);
    }

    public class RentalReservations : IReservations
    {
        public bool Check(ReservationInfo info)
        {
            bool availability = true;
            // logic to check availability goes here
            return availability;
        }
        
        public void Reserve(ReservationInfo info)
        {
            // logic to reserve rental car goes here
            System.Threading.Thread.Sleep(10000);
        }

        public bool Cancel(int confirmationNumber)
        {
            bool success = false;
            // logic to cancel reservation goes here
            return success;
        }

        public int GetStats()
        {
            int numberOfReservations = 0;
            // logic to determine reservation count goes here
            return numberOfReservations;
        }

        public int GetConfirmationNumber(string correlationId) => correlationId.Length + 58457;
    }
}
