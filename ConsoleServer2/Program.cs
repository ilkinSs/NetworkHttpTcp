using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleServer2
{
    class Program
    {
        static HttpListener httpListener = new HttpListener();

        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(800, 800); 

            httpListener.Prefixes.Add("http://localhost:8000/");
            httpListener.Start();

            Process.Listen();

            //httpListener.BeginGetContext(Process.Listen, null);

            Console.ReadLine();
        }

        public class Process
        {
            static string sentname;
            public async  static void Listen()
            {
                while (true)
                {
                    HttpListenerContext context = await  httpListener.GetContextAsync();

                     Task.Run(() => HandleRequest(context));
                    //ThreadPool.QueueUserWorkItem(HandleRequest, context);
                }
            }
            public static void HandleRequest(object contextt)
            {
                HttpListenerContext context = (HttpListenerContext)contextt;

                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                //stream.Write(Encoding.UTF8.GetBytes("Ok"));
                Stream body = request.InputStream;
                Stream stream = response.OutputStream;
                Encoding encoding = request.ContentEncoding;
                using (StreamReader reader = new StreamReader(body, encoding))
                {
                    sentname = reader.ReadToEnd();
                }
                stream.Write(Encoding.UTF8.GetBytes(sentname + "bla bla"));
                response.Close();
                body.Close();
            }
        }
    }
}
