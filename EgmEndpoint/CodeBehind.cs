using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ABB.Robotics.Math;
using ABB.Robotics.RobotStudio;
using ABB.Robotics.RobotStudio.Stations;
using LTH_EGM;

namespace EgmEndpoint
{
    public class CodeBehind : SmartComponentCodeBehind
    {

        EGM_Sensor_Server_Data_Structure ds;
        Abstract_Udp_Thread sensorGuide;
        Abstract_Udp_Thread sensorListener;

        public override void OnPropertyValueChanged(SmartComponent component, DynamicProperty changedProperty, Object oldValue)
        {
        }
        
        public override void OnIOSignalValueChanged(SmartComponent component, IOSignal changedSignal)
        {
        }
        
        public override void OnSimulationStep(SmartComponent component, double simulationTime, double previousTime)
        {
        }

        public override void OnSimulationStart(SmartComponent component)
        {
            base.OnSimulationStart(component);
            ds = new EGM_Sensor_Server_Data_Structure();
            sensorGuide = new Thread_Sensor_Guidance();
            sensorListener = new Thread_Sensor_Listener();
            sensorGuide.StartTryFetch(ds);
            sensorListener.StartTryFetch(ds);
        }

        public override void OnSimulationStop(SmartComponent component)
        {
            base.OnSimulationStop(component);
            sensorGuide.Stop();
            sensorListener.Stop();
            ds = null;
            sensorGuide = null;
            sensorListener = null;
        }
    }
}
