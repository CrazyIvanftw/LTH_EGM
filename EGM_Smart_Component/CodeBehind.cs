using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ABB.Robotics.Math;
using ABB.Robotics.RobotStudio;
using ABB.Robotics.RobotStudio.Stations;
using LTH_EGM;

namespace EGM_Smart_Component
{
    /// <summary>
    /// Code-behind class for the EGM_Smart_Component Smart Component.
    /// </summary>
    /// <remarks>
    /// The code-behind class should be seen as a service provider used by the 
    /// Smart Component runtime. Only one instance of the code-behind class
    /// is created, regardless of how many instances there are of the associated
    /// Smart Component.
    /// Therefore, the code-behind class should not store any state information.
    /// Instead, use the SmartComponent.StateCache collection.
    /// </remarks>
    public class CodeBehind : SmartComponentCodeBehind
    {
        Thread_Position_Guidence egmThread;
        Thread_Greg_Protocol_Adapter greg_protocol_adapter_thread;
        EGM_Sensor_Server_Data_Structure ds;
        /// <summary>
        /// Called when the value of a dynamic property value has changed.
        /// </summary>
        /// <param name="component"> Component that owns the changed property. </param>
        /// <param name="changedProperty"> Changed property. </param>
        /// <param name="oldValue"> Previous value of the changed property. </param>
        public override void OnPropertyValueChanged(SmartComponent component, DynamicProperty changedProperty, Object oldValue)
        {
        }

        /// <summary>
        /// Called when the value of an I/O signal value has changed.
        /// </summary>
        /// <param name="component"> Component that owns the changed signal. </param>
        /// <param name="changedSignal"> Changed signal. </param>
        public override void OnIOSignalValueChanged(SmartComponent component, IOSignal changedSignal)
        {
        }

        /// <summary>
        /// Called during simulation.
        /// </summary>
        /// <param name="component"> Simulated component. </param>
        /// <param name="simulationTime"> Time (in ms) for the current simulation step. </param>
        /// <param name="previousTime"> Time (in ms) for the previous simulation step. </param>
        /// <remarks>
        /// For this method to be called, the component must be marked with
        /// simulate="true" in the xml file.
        /// </remarks>
        public override void OnSimulationStep(SmartComponent component, double simulationTime, double previousTime)
        {
        }

        public override void OnSimulationStart(SmartComponent component)
        {
            
            base.OnSimulationStart(component);
            Debug.WriteLine("Sim-start---------------------------------------------------");
            // Make new threads
            egmThread = new Thread_Position_Guidence();
            greg_protocol_adapter_thread = new Thread_Greg_Protocol_Adapter();
            Debug.WriteLine("threads made");
            // Make new data structure
            ds = new EGM_Sensor_Server_Data_Structure();
            Debug.WriteLine("data structure made");
            // Start Threads
            egmThread.StartTryFetch(ds);
            greg_protocol_adapter_thread.StartTryFetch(ds);
            Debug.WriteLine("threads started");
        }

        public override void OnSimulationStop(SmartComponent component)
        {
            base.OnSimulationStop(component);
            Debug.WriteLine("Sim-stop---------------------------------------------------");
            // Stop Threads
            egmThread.Stop();
            greg_protocol_adapter_thread.Stop();
            // Null the threads and data structure
            egmThread = null;
            greg_protocol_adapter_thread = null;
            ds = null;
        }
    }
}
