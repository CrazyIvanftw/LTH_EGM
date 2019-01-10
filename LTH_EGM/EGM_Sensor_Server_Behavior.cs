using System;
using System.Collections.Generic;
using System.Text;

namespace LTH_EGM
{
    public class EGM_Sensor_Server_Behavior : Abstract_Data_Structure
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

        
        

        public EGM_Sensor_Server_Behavior()
        {
            
        }

        public string PrintOut()
        {
            throw new NotImplementedException();
        }

        public override double[] NextPose()
        {
            throw new NotImplementedException();
        }
        
        public override double[] PlannedPose()
        {
            throw new NotImplementedException();
        }

        public override void SetCurrentPose(double[] current)
        {
            throw new NotImplementedException();
        }

        public override void SetPlannedPose(double[] planned)
        {
            throw new NotImplementedException();
        }

        public override void SetNextPose(double[] next)
        {
            throw new NotImplementedException();
        }
    }
}
