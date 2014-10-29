using System;
using System.IO;
using VersionOne.Integration.Tfs.Core.Security;
using VersionOne.Integration.Tfs.Core.DataLayer;

namespace VersionOne.Integration.Tfs.Listener {
    /// <summary>
    /// Singleton class used for Debugging
    /// 1. Returns the singleton instance 
    /// 2. Define the interface
    /// </summary>
    [Obsolete]
    public abstract class Debug {
        // took the approach of 2 instances so we can enable and disable on the fly they are both really small
        private static readonly Debug noDebug = new NoDebug();
        private static readonly Debug debug = new DebugImpl();

        // get the static instance of the debug implementation
        public static Debug instance()
        {
            return Enabled ? debug : noDebug;
        }

        // Is debugging enabled
        public static bool Enabled
        {
            get
            {
                var config = new ConfigurationProxy().Retrieve(ProtectData.Unprotect);
                return config.DebugMode;
            }
        }

        // write the notification message
        public abstract void WriteNotificationMessage(string xml, string identityXml);

        // write a simple message
        public abstract void Write(string text);

        // write an exception message
        public abstract void Write(Exception e);
    }

    // Instance used when debugging is enabled.
    internal class DebugImpl : Debug
    {
        private readonly Object sync = new object();

        private readonly string fileName =
            Path.Combine(Paths.LoggingPath, "V1Debug.txt");
        public override void WriteNotificationMessage(string xml, string identityXml)
        {
            lock (sync)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Append))
                {
                    using (TextWriter textWriter = new StreamWriter(fs))
                    {
                        textWriter.WriteLine("{0:g} {1} Begin Notification Message", DateTime.Now, System.Threading.Thread.CurrentThread.Name);
                        textWriter.WriteLine("{0}", xml);
                        textWriter.WriteLine("{0}", identityXml);
                        textWriter.WriteLine("{0:g} {1} End Notification Message", DateTime.Now, System.Threading.Thread.CurrentThread.Name);
                    }
                }
            }
        }

        public override void Write(string text)
        {
            lock (sync)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Append))
                {
                    using (TextWriter textWriter = new StreamWriter(fs))
                    {
                        textWriter.WriteLine("{0:g} {1} {2}", DateTime.Now, System.Threading.Thread.CurrentThread.Name, text);
                    }
                }
            }
        }

        public override void Write(Exception e)
        {
            lock (sync) {
                using (FileStream fs = new FileStream(fileName, FileMode.Append)) {
                    using (TextWriter textWriter = new StreamWriter(fs)) {
                        textWriter.WriteLine("{0:g} {1} *** Caught the following Exception", DateTime.Now, System.Threading.Thread.CurrentThread.Name);
                        textWriter.WriteLine("{0}", e.Message);
                        textWriter.WriteLine("{0}", e.StackTrace);
                        textWriter.WriteLine("{0:g} {1} End Exception Data", DateTime.Now, System.Threading.Thread.CurrentThread.Name);
                    }
                }
            }		
        }
    }

    // The "Do Nothing" implementation
    internal class NoDebug : Debug {
        public override void WriteNotificationMessage(string xml, string identityXml) { }
        public override void Write(string text) { }
        public override void Write(Exception e){}
    }
}