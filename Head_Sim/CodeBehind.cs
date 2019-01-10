using System;
using System.Collections.Generic;
using System.Text;

using ABB.Robotics.Math;
using ABB.Robotics.RobotStudio;
using ABB.Robotics.RobotStudio.Stations;

namespace Head_Sim
{
    /// <summary>
    /// Code-behind class for the Head_Sim Smart Component.
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
            double pos = Math.Cos(simulationTime / 10000);

            Logger.AddMessage(new LogMessage(pos.ToString()));

            Station station = Project.ActiveProject as Station;

            Logger.AddMessage(new LogMessage("GOT HERE 1"));

            foreach (var child in station.Children)
            {
                Logger.AddMessage(new LogMessage("GOT HERE 2"));

                if (child.Name == "Head_mechanism")
                {
                    Logger.AddMessage(new LogMessage("GOT HERE 3"));
                    Part part = child as Part;

                    Logger.AddMessage(new LogMessage("GOT HERE 4"));
                    Matrix4 origo = Matrix4.Identity;
                    Matrix4 transform = new Matrix4(new Vector3(0, pos, 0));

                    Logger.AddMessage(new LogMessage("GOT HERE 5"));
                    part.Transform.SetRelativeTransform(origo, transform);
                    Logger.AddMessage(new LogMessage("GOT HERE 6"));
                }

            }
        }
    }
}
