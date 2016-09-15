using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace CarRentalService.Error
{
    public class CustomErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            if (error is FaultException<RentalServiceFaultContract>)
                return true;

            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(error));
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException<RentalServiceFaultContract>) return;

            var faultDetail = BuildFaultError(error);

            Type faultType =
                typeof(FaultException<>).MakeGenericType(faultDetail.GetType());

            var faultReason = new FaultReason(faultDetail.Message);
            FaultCode faultCode = FaultCode.CreateReceiverFaultCode(new FaultCode(faultDetail.TicketNumber));

            var faultException =
                (FaultException)Activator.CreateInstance(faultType, faultDetail, faultReason, faultCode);

            MessageFault faultMessage = faultException.CreateMessageFault();

            fault = Message.CreateMessage(version, faultMessage, faultException.Action);
        }

        private RentalServiceFaultContract BuildFaultError(Exception error)
            => new RentalServiceFaultContract
            {
                Date = DateTime.UtcNow,
                Message = $"Upps something happened.... we are working trying to fix it : {error.Message}",
                TicketNumber = Guid.NewGuid().ToString()
            };
    }
}
