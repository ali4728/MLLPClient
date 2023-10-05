using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MLLPClient
{
    public class Client
    {
        public void SendMesage(String server, Int32 port, String message)
        {
            try
            {
                using (TcpClient client = new TcpClient(server, port)) 
                {
                    client.ReceiveTimeout = 30000;
                    client.SendTimeout = 30000;
                    NetworkStream stream = client.GetStream();

                    Byte[] data = TCPUtils.GetMLLPBytes(message);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sent:\r\n{0}", message);

                                    
                    
                    string response = TCPUtils.GetMLLPString(stream);
                    Console.WriteLine("Received:\r\n{0}", response);

                    stream.Close();
                    client.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }

            Console.WriteLine("All done!!");
        }



    }
}
