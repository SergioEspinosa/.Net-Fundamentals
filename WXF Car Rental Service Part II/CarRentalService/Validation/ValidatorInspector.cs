using System;
using System.ServiceModel.Dispatcher;

namespace CarRentalService.Validation
{
    public class ValidatorInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            foreach (var input in inputs)
            {
                var reservationInfo = input as ReservationInfo;

                if(reservationInfo == null)
                {
                    throw new ArgumentException("The request value reservationInfo is null");
                }

                if (string.IsNullOrWhiteSpace(reservationInfo.CorrelationId))
                {
                    throw new ArgumentException("The parameter CorrelationId is null");
                }
            }

            return null;
        }
    }
}
