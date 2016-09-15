using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CarRentalService.Error
{
    public class CustomErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        #region IServiceBehavior Members

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
            Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase chanDispBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = chanDispBase as ChannelDispatcher;
                if (channelDispatcher == null)
                    continue;
                channelDispatcher.ErrorHandlers.Add(new CustomErrorHandler());
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}
