using System;
using ZMQ.Infrastructure;

namespace ZMQ.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerProvider sp = new();
            sp.StartProvider();
        }
    }
}
