using System;
using System.ServiceModel.Description;

namespace CarRentalService.Validation
{
    public class ValidatorInspectorAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new ValidatorInspector());
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
