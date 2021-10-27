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

                string input = "";
                while (input != "exit") {
                    Write($"/>: ");
                    switch (input = ReadLine()) {
                        case "add":
                            Write("Coordinates? (seperated by space): ");
                            string[] tmp = ReadLine().Split(' ');
                            if (int.TryParse(tmp[0], out int x) && int.TryParse(tmp[1], out int y)) {
                                client.SendFrame($"{x}-{y}");
                                var msg = client.ReceiveFrameString();
                                WriteLine($"received: {msg}");
                            } else {
                                WriteLine("input error");
                            }
                            break;
                        case "help":
                            PrintHelp();
                            break;
                        default: break;
                    }
                }

            }
        }

        public void PrintHelp() {
            WriteLine("cmds:\n\tadd | help");
        }
    }
}
