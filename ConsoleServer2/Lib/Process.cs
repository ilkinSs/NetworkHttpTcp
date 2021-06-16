//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Text;
//using System.Threading;
//using ConsoleServer2.Lib;

//namespace ConsoleServer2.Lib
//{
//   public  class Process
//    {
//        static string sentname;

//        HttpListener httpListener = new HttpListener();
     
//        public static void Listen(IAsyncResult ar)
//        {

//            while (true)
//            {
//                HttpListenerContext context = httpListener.EndGetContext(ar);
//                httpListener.BeginGetContext(Listen, null);

//                ThreadPool.QueueUserWorkItem(HandleRequest, context);
//            }
//        }
//        public static void HandleRequest(object contextt)
//        {

//            HttpListenerContext context = (HttpListenerContext)contextt;

//            HttpListenerRequest request = context.Request;
//            HttpListenerResponse response = context.Response;
//            //stream.Write(Encoding.UTF8.GetBytes("Ok"));
//            Stream body = request.InputStream;
//            Stream stream = response.OutputStream;
//            Encoding encoding = request.ContentEncoding;
//            using (StreamReader reader = new StreamReader(body, encoding))
//            {
//                sentname = reader.ReadToEnd();
//            }
//            stream.Write(Encoding.UTF8.GetBytes(sentname + "bla bla"));
//            response.Close();
//            body.Close();
//        }
//    //}
//}
