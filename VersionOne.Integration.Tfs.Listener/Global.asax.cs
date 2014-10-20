using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using VersionOne.Integration.Tfs.Listener.App_Start;

namespace VersionOne.Integration.Tfs.Listener
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            Dictionary<string, string[]> supportedDlls = new Dictionary<string, string[]>();
            supportedDlls.Add(
                "Microsoft.TeamFoundation.Client",
                new string[]{ 
                                    "Microsoft.TeamFoundation.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.Client, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.Client, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"}
            );
            supportedDlls.Add(
                "Microsoft.TeamFoundation.Build.Client",
                new string[]{ 
                                    "Microsoft.TeamFoundation.Build.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.Build.Client, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.Build.Client, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"}
            );
            supportedDlls.Add(
                "Microsoft.TeamFoundation.VersionControl.Common.Integration",
                new string[]{ 
                                    "Microsoft.TeamFoundation.VersionControl.Common.Integration, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.VersionControl.Common.Integration, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.VersionControl.Common.Integration, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"}
            );
            VersionOne.Integration.Tfs.Core.Extensions.ReferenceLoader.ResolveDlls(AppDomain.CurrentDomain, supportedDlls);
            WebApiConfig.RegisterRoutesIgnores(RouteTable.Routes);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}