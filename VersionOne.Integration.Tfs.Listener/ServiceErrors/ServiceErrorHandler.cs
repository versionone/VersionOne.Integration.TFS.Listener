using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace VersionOne.Integration.Tfs.Listener.ServiceErrors
{
    public class ServiceErrorHandler : IErrorHandler
    {
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            LogWithElmah(error);
        }

        private static void LogWithElmah(Exception exception)
        {
            if (HttpContext.Current != null)
                Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
            else
                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(exception));
        }

        public bool HandleError(Exception error)
        {
            return false;
        }
    }
}