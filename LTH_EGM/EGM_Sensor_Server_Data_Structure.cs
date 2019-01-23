using System;
using System.Collections.Generic;
using System.Text;

namespace LTH_EGM
{
    public class EGM_Sensor_Server_Data_Structure : Abstract_Data_Structure
    {

        // Header
        private UInt32 seqno;
        private UInt32 tm;
        private int mtype;
        // Feedback
        private Robot_pose feedback;
        // Planned
        private Robot_pose planned;
        // desired
        private Robot_pose desired;
        // Motor State
        private int motorState;
        // MCI State
        private int mciState;
        // MCI Convergence Met
        private bool mciConvergenceMet;
        // Test Signals
        private IList<double> testSignals;
        //RAPID Execution State
        private int rapidExceState;
        //Measured Force
        private double[] mesauredForce;

        //Sensor Data
        private double[] sensedPoint;
        private double[] start;
        private double[] end;
        private double radius;
        private string sensedPart;
        private UInt32 sensorID;

        public uint Seqno { get => seqno; set => seqno = value; }
        public uint Tm { get => tm; set => tm = value; }
        public int Mtype { get => mtype; set => mtype = value; }
        public Robot_pose Feedback { get => feedback; set => feedback = value; }
        public Robot_pose Planned { get => planned; set => planned = value; }
        public int MotorState { get => motorState; set => motorState = value; }
        public int MciState { get => mciState; set => mciState = value; }
        public bool MciConvergenceMet { get => mciConvergenceMet; set => mciConvergenceMet = value; }
        public int RapidExceState { get => rapidExceState; set => rapidExceState = value; }
        public double[] MesauredForce { get => mesauredForce; set => mesauredForce = value; }
        public IList<double> TestSignals { get => testSignals; set => testSignals = value; }
        public Robot_pose Desired { get => desired; set => desired = value; }
        public uint SensorID { get => sensorID; set => sensorID = value; }
        public string SensedPart { get => sensedPart; set => sensedPart = value; }
        public double Radius { get => radius; set => radius = value; }
        public double[] End { get => end; set => end = value; }
        public double[] Start { get => start; set => start = value; }
        public double[] SensedPoint { get => sensedPoint; set => sensedPoint = value; }

        public EGM_Sensor_Server_Data_Structure()
        {
            // Populate the data structure with dummy values so there isn't an accidental crash if any calls are made before the
            // position guidace thread can populate it with real values.
            Robot_pose dummyPose = new Robot_pose();
            dummyPose.Cartesian = new double[] { 0, 1, 2 };
            dummyPose.Quarternion = new double[] { 0, 1, 2, 3 };
            dummyPose.Euler = new double[] { 0, 1, 2 };
            dummyPose.ExternalJoints = new double[] { 0, 1, 2, 3, 4, 5 };
            dummyPose.Joints = new double[] { 0, 1, 2, 3, 4, 5 };
            dummyPose.Time = new long[] { 0, 1 };
            Desired = dummyPose;
            Feedback = dummyPose;
            Planned = dummyPose;
            MciState = (int)abb.egm.EgmMCIState.Types.MCIStateType.MCI_ERROR;
            MciConvergenceMet = false;
            MotorState = (int)abb.egm.EgmMotorState.Types.MotorStateType.MOTORS_UNDEFINED;
            RapidExceState = (int)abb.egm.EgmRapidCtrlExecState.Types.RapidCtrlExecStateType.RAPID_UNDEFINED;
            Seqno = 0;
            Tm = 0;
            Mtype = 0;
            List<double> list = new List<double>();
            for (int i = 0; i < 6; i++)
            {
                list.Add(i);
            }
            TestSignals = list;
            MesauredForce = new double[] { 0, 1, 2, 3, 4, 5 };

            //Make dummy values for sensed point
            SensedPoint = new double[]
            {
                0.0,
                0.0,
                0.0
            };
        }

        public string PrintOut()
        {
            throw new NotImplementedException();
        }
    }
}
