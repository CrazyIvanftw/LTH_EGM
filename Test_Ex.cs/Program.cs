using System;
using LTH_EGM;

namespace Test_Ex.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Abstract_Udp_Thread thread = new Thread_Position_Stream();
            Abstract_Udp_Thread egm_thread = new Thread_Position_Guidence();
            Thread_Server server_thread = new Thread_Server();
            //Abstract_Udp_Thread interface_thread = new Thread_Server();
            EGM_Sensor_Server_Behavior ds = new EGM_Sensor_Server_Behavior();
            egm_thread.Start(ds);
            server_thread.Start(ds);
            //interface_thread.Start(ds);
            //Test_Data_Structure t = new Test_Data_Structure();
            while(true)
            {
                Console.WriteLine("Please start simulation in RS before continuing");
                Console.ReadKey();

                //Console.WriteLine($"{ds.PrintOut()}");
            }
        }
    }
}
