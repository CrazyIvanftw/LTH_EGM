using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using lth.egm;

namespace LTH_EGM
{
    public class EGM_Client
    {
        public void send()
        {
            int _portNbr = (int)Port_Numbers.SERVER_PORT;
            EGM_Control.Builder request = EGM_Control.CreateBuilder();
            UdpClient udpServer = new UdpClient(_portNbr);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, _portNbr);
            // Send the message
            using (MemoryStream memoryStream = new MemoryStream())
            {
                EGM_Control message = request.Build();
                message.WriteTo(memoryStream);
                // send the udp message to the robot
                int bytesSent = udpServer.Send(memoryStream.ToArray(),
                    (int)memoryStream.Length, remoteEP);
                if (bytesSent < 0)
                {
                    //DebugDisplay("Error send to robot");
                }
            }
        }
    }
}
