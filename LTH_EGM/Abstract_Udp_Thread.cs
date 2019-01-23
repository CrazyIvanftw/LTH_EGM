using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using abb.egm;


namespace LTH_EGM
{
    public abstract class Abstract_Udp_Thread : EGM_Udp_Thread_Interface
    {

        private int _portNbr;
        public int _seqNbr = 0;
        private bool _exitThread = false;
        private Thread _thread;

        public Abstract_Udp_Thread(int portNbr)
        {
            _portNbr = portNbr;
        }

        public void DebugDisplay(string s)
        {
            Debug.WriteLine("pos stream ->" + s);
        }

        public abstract void CreateMessage(Abstract_Data_Structure behavior);

        public abstract void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior);

        public void StartTryFetch(Abstract_Data_Structure behavior)
        {
            _exitThread = false;
            _thread = new Thread(() => ThreadStartTryFetch(behavior));
            _thread.Start();
        }

        public void StartDoFetch(Abstract_Data_Structure behavior)
        {
            _exitThread = false;
            _thread = new Thread(() => ThreadStartDoFetch(behavior));
            _thread.Start();
        }

        public void Stop()
        {
            _exitThread = true;
            _thread = null;
        }

        public void ThreadStartTryFetch(Abstract_Data_Structure behavior)
        {
            _seqNbr = 0;
            int timeout = 0;
            UdpClient udpServer = new UdpClient(_portNbr);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, _portNbr);
            while (!_exitThread)
            {
                byte[] data = null;
                try
                {
                    if(udpServer.Available > 0)
                    {
                        data = udpServer.Receive(ref remoteEP);
                    }
                }
                catch (Exception e)
                {
                    DebugDisplay(e.Message);
                    Stop();
                }
                if(data != null)
                {
                    ProcessData(udpServer, remoteEP,  data, behavior);
                    timeout = 0;
                }
                else if(_seqNbr != 0 && timeout > 50)
                {
                    _exitThread = true;
                }
                Thread.Sleep(10);
                timeout++;
            }
        }

        public void ThreadStartDoFetch(Abstract_Data_Structure behavior)
        {
            _seqNbr = 0;
            UdpClient udpServer = new UdpClient(_portNbr);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, _portNbr);
            while (!_exitThread)
            {
                byte[] data = null;
                try
                {
                    data = udpServer.Receive(ref remoteEP);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                
                
                if (data != null)
                {
                    ProcessData(udpServer, remoteEP, data, behavior);
                }
            }
        }



    }
}