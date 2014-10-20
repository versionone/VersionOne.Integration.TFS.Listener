using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VersionOne.Integration.Tfs.Listener.Config
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;
        static Program()
        {

            AttachConsole(ATTACH_PARENT_PROCESS);
            Dictionary<string, string[]> supportedDlls = new Dictionary<string, string[]>();
            supportedDlls.Add(
                "Microsoft.TeamFoundation.Client",
                new string[]{ 
                                    "Microsoft.TeamFoundation.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.Client, Version=11.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", 
                                    "Microsoft.TeamFoundation.Client, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"}
            );
            VersionOne.Integration.Tfs.Core.Extensions.ReferenceLoader.ResolveDlls(AppDomain.CurrentDomain, supportedDlls);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (arg == "/unsubscribe")
                {
                    try
                    {
                        ConfigForm.TFSUnsubscribe();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error unsubscribing from TFS events, you should manually unsubscribe");
                    }
                    return;
                }

                if (arg == "/install")
                {
                    try
                    {
                        ConfigForm.Install();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error setting .net version");
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ConfigForm());
        }
    }
}