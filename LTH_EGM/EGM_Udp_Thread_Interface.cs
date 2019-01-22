using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LTH_EGM
{
    interface EGM_Udp_Thread_Interface
    {
        void ThreadStartTryFetch(Abstract_Data_Structure behavior);

        void DebugDisplay(string s);

        void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior);

        void StartTryFetch(Abstract_Data_Structure behavior);

        void Stop();
    }
}
