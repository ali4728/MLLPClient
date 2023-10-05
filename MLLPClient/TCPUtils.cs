using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MLLPClient
{
    public class TCPUtils
    {
        public static byte START_BLOCK = 0x0B;        // <VT>
        public static byte END_BLOCK = 0x1C;          // <FS>
        public static byte CARRIAGE_RETURN = 0x0D;    // \r


        public static byte[] GetMLLPBytes(string msg)
        {
            var bytes = Encoding.ASCII.GetBytes(msg);

            byte[] mllpBytes = new byte[bytes.Length + 3];
            mllpBytes[0] = START_BLOCK;
            bytes.CopyTo(mllpBytes, 1);

            mllpBytes[bytes.Length + 1] = END_BLOCK;
            mllpBytes[bytes.Length + 2] = CARRIAGE_RETURN;

            return mllpBytes;
        }

        public static string GetMLLPString(NetworkStream stream)
        {


            string data = "";
            Byte[] bytes = new Byte[256];

            List<byte> msgbytes = new List<byte>();
            int i;

            bool readmore = true;

            while (readmore && (i = stream.Read(bytes, 0, bytes.Length)) > 0)
            {

                for (int j = 0; j < i; j++)
                {
                    if (bytes[j] == TCPUtils.START_BLOCK)
                    {
                        msgbytes.Clear();
                    }
                    else if (bytes[j] == TCPUtils.END_BLOCK)
                    {
                        data = Encoding.ASCII.GetString(msgbytes.ToArray()).Trim();

                        readmore = false;
                    }
                    else
                    {
                        msgbytes.Add(bytes[j]);
                    }
                }
            }

            return data;

        }
    }
}
