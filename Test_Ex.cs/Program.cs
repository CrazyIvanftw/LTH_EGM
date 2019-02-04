using System;
using System.Diagnostics;
using LTH_EGM;

namespace Test_Ex.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Abstract_Udp_Thread thread = new Thread_Position_Stream();
            //Abstract_Udp_Thread egm_thread = new Thread_Position_Guidence();
            //Thread_Greg_Protocol_Adapter greg_protocol_adapter_thread = new Thread_Greg_Protocol_Adapter();
            //Abstract_Udp_Thread interface_thread = new Thread_Server();
            EGM_Sensor_Server_Data_Structure ds = new EGM_Sensor_Server_Data_Structure();
            //egm_thread.StartTryFetch(ds);
            //greg_protocol_adapter_thread.StartTryFetch(ds);
            //interface_thread.Start(ds);
            //Test_Data_Structure t = new Test_Data_Structure();
            Abstract_Udp_Thread sensorGuide = new Thread_Sensor_Guidance();
            Abstract_Udp_Thread sensorListener = new Thread_Sensor_Listener();
            sensorGuide.StartTryFetch(ds);
            sensorListener.StartTryFetch(ds);
            //sensorGuide.StartAsyncFetch(ds);
            //sensorListener.StartAsyncFetch(ds);
            Debug.WriteLine("Please start simulation in RS before continuing");
        }
    }
}
