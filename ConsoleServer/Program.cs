using HttpServer;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentname;

          HttpListener httpListener =  SharedListener.StartListen();

            


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
                }
                Thread.Sleep(1000);
                stream.Write(Encoding.UTF8.GetBytes(sentname + "bla bla"));
                response.Close();
                body.Close();
            }
        }
    }
}
