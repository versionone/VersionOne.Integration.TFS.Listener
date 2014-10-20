using System;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace VersionOne.Integration.Tfs.Listener.ServiceErrors
{
    public class ServiceErrorBehaviorAttribute : Attribute, IServiceBehavior
    {
        readonly Type _errorHandlerType;
        public ServiceErrorBehaviorAttribute(Type errorHandlerType)
        {
            this._errorHandlerType = errorHandlerType;
        }
        #region IServiceBehavior Members
        public void AddBindingParameters(ServiceDescription serviceDescription,
           System.ServiceModel.ServiceHostBase serviceHostBase,
           System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints,
           System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            var errorHandler = (IErrorHandler)Activator.CreateInstance(_errorHandlerType);
            foreach (var cd in serviceHostBase.ChannelDispatchers.Select(cdb => cdb as ChannelDispatcher))
            {
                cd.ErrorHandlers.Add(errorHandler);
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
        }
        #endregion
    }
}