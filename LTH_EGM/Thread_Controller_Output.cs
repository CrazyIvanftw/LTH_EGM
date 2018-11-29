using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LTH_EGM
{
    public class Thread_Controller_Output : Abstract_Udp_Thread
    {
        public int PortNbr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Thread_Controller_Output() : base((int)Port_Numbers.CONTROLLER_PORT) { }

        public override void CreateMessage(double[] pose)
        {
            throw new NotImplementedException();
        }

        public override void CreateMessage(Abstract_Data_Structure behavior)
        {
            throw new NotImplementedException();
        }

        public override void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior)
        {
            throw new NotImplementedException();
        }
    }
}
