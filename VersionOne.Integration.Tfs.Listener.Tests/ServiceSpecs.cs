using System;
using System.IO;
using System.ServiceModel;
using System.Xml;
using NSpec;

namespace VersionOne.Integration.Tfs.Listener.Tests
{

    public class ServiceSpecs : nspec
    {

        public void given_an_exception_occurs_on_a_tfs_checkin_event()
        {
            it["then the exception is returned to the client"] = () =>
                {
                    var client = new VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.ServiceClient();
                    try
                    {
                        expect<FaultException<ExceptionDetail>>(() => client.Notify(null, null));
                    }
                    finally
                    {
                        if (client.State != CommunicationState.Closed) client.Close();
                    }

                };
        }
        /// <summary>
        /// Commented out due to external deps on a TFS server being present.  Left in place for its usefulness in debugging customer reported exceptions.
        /// </summary>
        //public void given_a_soap_message_with_a_string_length_greater_than_the_default_of_8192_is_sent()
        //{
        //
        //    var longXml = GetXmlString(@".\Resources\LongCheckinEvent.xml");
        //
        //            it["then the message is processed successfully"] = () =>
        //                {
        //                    var client = new VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.ServiceClient();
        //
        //                    try
        //                    {
        //                        client.Notify(longXml, "<TeamFoundationServer url='http://localhost:8080/tfs/DefaultCollection/Services/v3.0/LocationService.asmx' />");
        //                    }
        //                    finally
        //                    {
        //                        if (client.State != CommunicationState.Closed) client.Close();
        //                    }
        //                };
        //

        //        }

        /// <summary>
        /// Commented out due to external deps on a TFS server being present.  Left in place for its usefulness in debugging customer reported exceptions.
        /// </summary>
        //public void given_a_soap_message_for_a_build_event()
        //{
        //    var buildXml = GetXmlString(@".\Resources\BuildEventExample.xml");

        //    it["then the message is processed successfully"] = () =>
        //        {
        //            var client = new ServiceProxy.ServiceClient();
        //            try
        //            {
        //                client.Notify(buildXml, "<TeamFoundationServer url='http://localhost:8080/tfs/DefaultCollection/Services/v3.0/LocationService.asmx' />");
        //            }
        //            finally
        //            {
        //                if (client.State != CommunicationState.Closed) client.Close();
        //            }
        //        };

        //}

        private static string GetXmlString(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);
            var stringWriter = new StringWriter();
            var xmlTextWriter = new XmlTextWriter(stringWriter);
            doc.WriteTo(xmlTextWriter);
            return stringWriter.ToString();
        }

    }
}
