using System;
using System.Collections.Generic;
using System.Text;

namespace LTH_EGM
{
    class EGM_Sensor_Server
    {
        private Abstract_Udp_Thread pos_stream_thread;
        private Abstract_Udp_Thread pos_guide_thread;
        //private Abstract_Udp_Thread path_corr_thread;
        private Abstract_Udp_Thread interface_thread;
        private EGM_Sensor_Server_Behavior behavior;

        public EGM_Sensor_Server()
        {
            behavior = new EGM_Sensor_Server_Behavior();
            pos_stream_thread = new Thread_Position_Stream();
            pos_guide_thread = new Thread_Position_Guidence();
            interface_thread = new Thread_Greg_Protocol_Adapter();
            //path_corr_thread = new Thread_Path_Correction();

        }
    }
}
