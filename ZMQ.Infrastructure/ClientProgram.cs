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

                Write($"/>: ");
                while ((input = ReadLine()) != "exit") {
                    switch(input) {
                        case "add":
                            Write("Coordinates? (seperated by space): ");
                            if (int.TryParse(ReadLine(), out int tmpa) && int.TryParse(ReadLine(), out int tmpb)) {
                                client.SendFrame($"{tmpa}-{tmpb}");
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
