using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ABB.Robotics.Math;
using ABB.Robotics.RobotStudio;
using ABB.Robotics.RobotStudio.Stations;

namespace start_thread_test
{
    /// <summary>
    /// Code-behind class for the start_thread_test Smart Component.
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
        }

        public override void OnSimulationStart(SmartComponent component)
        {
            base.OnSimulationStart(component);
            Test_thread thread = new Test_thread();
            thread.Start();
        }
    }

    public class Test_thread
    {

        int portNbr = 8080;
        private Thread _serverThread = null;
        private UdpClient _udpServer = null;
        private bool _exitThread = false;
        private uint _seqNumber = 0;

        string msg = "this is a message";

        public void ServerStart()
        {
            // create an udp client and listen on any address and the port _ipPortNumber

            _udpServer = new UdpClient(portNbr);
            var remoteEP = new IPEndPoint(IPAddress.Any, portNbr);
            int nbr = 1;

            while (_exitThread == false)
            {
                byte[] data = null;
                try
                {
                    data = _udpServer.Receive(ref remoteEP);
                    Logger.AddMessage(new LogMessage(Convert.ToString(data)));
                    nbr += 1;
                }
                catch (Exception e)
                {
                    Logger.AddMessage(new LogMessage(e.Message));
                    _exitThread = true;
                }


            }
        }

        // Start a thread to listen on inbound messages
        public void Start()
        {
            _serverThread = new Thread(new ThreadStart(ServerStart));
            _serverThread.Start();
        }

        // Stop and exit thread
        public void Stop()
        {
            _exitThread = true;
            _serverThread.Abort();
        }
    }
}
