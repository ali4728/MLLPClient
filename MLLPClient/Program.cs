using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MLLPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"\\Path\to\SampleMessage_ADT.txt";
            string data = File.ReadAllText(filePath);

            Client client = new Client();

            client.SendMesage("192.168.1.1", 12568, data);

            Console.WriteLine("Client is done!");
            Console.WriteLine("Check");
        }
    }
}
