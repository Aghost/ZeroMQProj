using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using NetMQ;
using NetMQ.Sockets;

using static System.Console;

namespace ZMQ.Infrastructure
{
    public class ServerProvider
    {
        public void StartProvider() {
            WriteLine("starting server...");

            using (var server = new ResponseSocket()) {
                server.Bind("tcp://*:5555");
                while(true) {
                    var msg = server.ReceiveFrameString();
                    WriteLine($"message: {msg}");

                    Thread.Sleep(1000);
                    WriteLine("sending...");
                    server.SendFrame("World");
                }
            }
        }

    }
}
