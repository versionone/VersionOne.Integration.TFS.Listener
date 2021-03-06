using System;
using System.Net;
using Microsoft.TeamFoundation.Client;
using VersionOne.Integration.Tfs.Core.DataLayer;
using VersionOne.Integration.Tfs.Core.Security;
using VersionOne.Integration.Tfs.Core.DataLayer.Providers;

namespace VersionOne.Integration.Tfs.Listener.Config {
    /// <summary>
    /// Summary description for Utils
    /// </summary>
    public class Utils
    {
        public static TfsTeamProjectCollection ConnectToTFS()
        {

            var config = new ConfigurationProxy().Retrieve(ProtectData.Unprotect);
            var user = config.TfsUserName;
            var domain = string.Empty;
            var pos = config.TfsUserName.IndexOf('\\');
            
            if (pos >= 0)
            {
                domain = config.TfsUserName.Substring(0, pos);
                user = user.Substring(pos + 1);
            }
            
            var creds = new NetworkCredential(user, config.TfsPassword, domain);
            var tfsServer = new TfsTeamProjectCollection(new Uri(config.TfsUrl), creds);
            tfsServer.Authenticate();
            return tfsServer;
        }

        public static string WebSiteName(Func<string, string> unprotect)
        {
            return (new ConfigurationProvider(unprotect)).WebSiteName;
        }
    }
}
