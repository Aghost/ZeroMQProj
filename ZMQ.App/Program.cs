﻿using System;
using System.IO;
using ZMQ.Infrastructure;

namespace ZMQ.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strfile = File.ReadAllLines(@"Boards/board1");
            char[][] Board = new char[strfile.Length][];

            for (int i = 0; i < strfile.Length; i++) {
                Board[i] = strfile[i].ToCharArray();
            }

            ServerProvider sp = new(Board);
            sp.StartProvider();
        }
    }
}
