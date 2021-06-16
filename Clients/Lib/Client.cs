using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Clients.Lib
{
    public class Client
    {
        public readonly object MyProperty = new object();

        HttpClient client = new HttpClient(new HttpClientHandler
        {
            
        });

        public async Task Invoke()
        {
            var timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < 2500; i++)
            {                         
                StringContent stringContent = new StringContent(i.ToString() + "aloha" );
                var response = await client.PostAsync($"http://localhost:{8000}/", stringContent);             
                var resContent = await response.Content.ReadAsStringAsync();
            }
            timer.Stop();
            
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            Console.WriteLine(foo);




        }

    }
}
