//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading.Tasks;

//namespace HttpServer
//{
//    public static class SharedListener
//    {


//        public static HttpListener httpListener = new HttpListener() { 
//        };
        

        
//        public static HttpListener StartListen()
//        {

            
//                httpListener.Prefixes.Add("http://localhost:8000/");
//                httpListener.Start();
//                httpListener.BeginGetContext(Process.Listen, null);

               

            
//            return httpListener;
           
       
//        }
//    }
//}
