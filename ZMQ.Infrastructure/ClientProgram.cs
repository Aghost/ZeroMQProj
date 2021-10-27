using System;
using NetMQ;
using NetMQ.Sockets;

using static System.Console;

namespace ZMQ.Infrastructure
{
    public class ClientProgram
    {
        public void StartClient()
        {
            using (var client = new RequestSocket()) {
                client.Connect("tcp://localhost:5555");

                for (int i = 0; i < 10; i++) {
                    WriteLine($"sending hello");
                    client.SendFrame("Hello");
                    var msg = client.ReceiveFrameString();
                    WriteLine($"received: {msg}");
                }
            }
        }
    }
}
