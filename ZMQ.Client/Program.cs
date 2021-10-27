using System;
using ZMQ.Infrastructure;

namespace ZMQ.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ClientProgram();
            client.StartClient();
        }
    }
}
