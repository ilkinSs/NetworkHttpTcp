using Clients.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clients
{
    class Program
    {
        static  void Main(string[] args)
        {
            //ServicePointManager.DefaultConnectionLimit = 10;
            Thread.Sleep(1000);
            Client client = new Client();
            Client[] clients = new Client[3]
            {
                new Client(),
                new Client(),
                new Client()
            };

            int port = 8000;

            var tasks = new List<Task>();

            for (int i = 0; i < 3; i++)
            {
                var t = clients[i].Invoke(port);
                port++;

                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            Console.ReadLine();
        }
    }
}
