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
    // BAAS Battleship as a Service
    public class ServerProvider
    {
        private char[][] _Board;

        public ServerProvider(char[][] Board) {
            _Board = Board;
        }

        public void StartProvider() {
            WriteLine("starting server...");

            using (var server = new ResponseSocket()) {
                server.Bind("tcp://*:5555");
                while(true) {
                    var msg = server.ReceiveFrameString();
                    WriteLine($"received message: {msg}");
                    WriteLine("processing message and sending response...");
                    server.SendFrame(ProcessCoords(msg));
                    PrintBoard();
                    Thread.Sleep(5 * 1000);
                }
            }
        }

        private string ProcessCoords(string coords) {
            int x = int.Parse(coords.Split('-')[0]);
            int y = int.Parse(coords.Split('-')[1]);

            if (_Board[x][y] == '1') {
                return "HIT!";
            } else {
                FlipCoord(x, y);
                return "MISS!, flipping bit";
            }
        }

        private void FlipCoord(int x, int y) {
            _Board[x][y] = _Board[x][y] == '1' ? '0' : '1';
        }

        private void PrintBoard() {
            foreach (char[] row in _Board) {
                foreach (char c in row) {
                    Write(c);
                }

                WriteLine();
            }
        }

    }
}
