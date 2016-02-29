using System;
using System.Linq;
using System.Text;

namespace SampleShopServer
{
    static class Responder
    {
        private static Logger.Logger logger = Logger.Logger.GetInstance();

        public static void Respond(Server.ConnectionInfo conn_info, string content )
        {
            int content_length = content.Length;

            string resp_main = "HTTP/1.1 200 OK\r\n" +
                                "Content-Length: " + content_length.ToString() + "\r\n" +
                                "Content-Type: text/xml\r\n\r\n" +
                                content+"\r\n\r\n";

            logger.WriteEntry("Sending a response: " + resp_main);
            conn_info.socket.Send(Encoding.ASCII.GetBytes(resp_main));
            logger.WriteEntry("READY");
        }
        
        
    }
}
