using lth.line_sensor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LTH_EGM
{
    public class Thread_Sensor_Listener : Abstract_Udp_Thread
    {

        public Thread_Sensor_Listener() : base((int)Port_Numbers.TEST_PORT) { Debug.WriteLine("sensor listener started"); }

        public override void CreateMessage(Abstract_Data_Structure behavior)
        {
            //This method won't be used for the listener. It doesn't need to respond to any of its incoming messages.
            throw new NotImplementedException();
        }

        public override void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior)
        {
            EGM_Sensor_Server_Data_Structure monitor = (EGM_Sensor_Server_Data_Structure)behavior;
            LineSensor state = LineSensor.CreateBuilder().MergeFrom(data).Build();

            if(state.SensorID == 1)
            {
                //Debug.WriteLine(state);
                monitor.SensedPoint = new double[]
                {
                state.SensedPoint.X,
                state.SensedPoint.Y,
                state.SensedPoint.Z
                };
                monitor.SensedPart = state.SensedPart;
            }
            
        }
    }
}
