using System;
using MonoRemoteDebugger.SharedLib;
using MonoRemoteDebugger.SharedLib.Server;

namespace MonoRemoteDebugger.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool runOnce = false;
            if (args.Length != 0 && args[0] == "runOnce")
                runOnce = true;

            using (var server = new MonoDebugServer(runOnce))
            {
                Console.CancelKeyPress += delegate
                {
                    server.Stop();
                };

                MonoLogger.Setup();

                server.StartAnnouncing();
                server.Start();
                server.WaitForExit();
            }
        }
    }
}