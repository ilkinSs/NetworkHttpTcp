using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ServicePointManager.DefaultConnectionLimit = 10;
            string sentname;
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8000/");


            httpListener.Start();


            Console.WriteLine("Http Server runing");
            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                //stream.Write(Encoding.UTF8.GetBytes("Ok"));
                Stream body = request.InputStream;
                Stream stream = response.OutputStream;
                Encoding encoding = request.ContentEncoding;
                using (StreamReader reader = new StreamReader(body, encoding))
                {
                    sentname = reader.ReadToEnd();
                    Console.WriteLine(sentname);
                }
                Thread.Sleep(1000);
                stream.Write(Encoding.UTF8.GetBytes(sentname +"bla bla" ));
                response.Close();
                body.Close();
            }



        CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
