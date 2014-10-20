using System;
using System.Net;
using Microsoft.TeamFoundation.Client;
using VersionOne.ServiceHost.Core.Configuration;
using VersionOne.Integration.Tfs.Core.DataLayer.Providers;

namespace VersionOne.Integration.Tfs.Listener
{
    /// <summary>
    /// Summary description for Utils
    /// </summary>
    public class Utils
    {
        public static TfsTeamProjectCollection ConnectToTfs()
        {

            var config = new ConfigurationProvider();

            var url = config.TfsUrl;
            var user = config.TfsUserName;
            var password = config.TfsPassword;

            var domain = string.Empty;
            var pos = user.IndexOf('\\');

            if (pos >= 0)
            {
                domain = user.Substring(0, pos);
                user = user.Substring(pos + 1);
            }

            var creds = new NetworkCredential(user, password, domain);
            var tfsServer = new TfsTeamProjectCollection(url, creds);
            tfsServer.Authenticate();
            return tfsServer;
        }

        /// <summary>
        /// Yuck.  Why?
        /// </summary>
        /// <returns></returns>
        public static VersionOne.Integration.Tfs.Core.DataLayer.VersionOneSettings GetV1Settings()
        {

            var config = new ConfigurationProvider();

            return new VersionOne.Integration.Tfs.Core.DataLayer.VersionOneSettings 
                {
                    Path = config.VersionOneUrl.ToString(),
                    Username = config.VersionOneUserName,
                    Password = config.VersionOnePassword,
                    Integrated = config.IsWindowsIntegratedSecurity,
                    ProxySettings = config.ProxySettings
                };
        }


    }
}