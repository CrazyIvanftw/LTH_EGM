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

        public string PrintOut()
        {
            string s = $"\n seqno:{seqno}  tm:{tm}  mtype:{mtype}" +
                $"\n feedback: " +
                feedback.PrintOut() +
                $"\n planned: " +
                planned.PrintOut() +
                $"\n motorState: {motorState}" +
                $"\n mciState: {mciState}" +
                $"\n mciConvergenceMet: {mciConvergenceMet}" +
                //$"\n testSignals: {testSignals}" +
                $"\n rapidExceState: {rapidExceState}" +
                $"\n mesauredForce: {mesauredForce}" +
                $"\n testSignals:";
            foreach (double signal in testSignals)
            {
                s = s + $"\n\t{signal}";
            }
            return s;
        }

        //--------------------------------------//
        // WILL REMOVE THESE PARAMETERS LATER   //
        List<double[]> path;                    //
        int pathCounter;                        //
                                                //
        double[] cp; //current pose             //
        double[] pp; //planned pose             //
        double[] np; //next pose                //
        //--------------------------------------//

        public EGM_Sensor_Server_Behavior()
        {
            path = new List<double[]>();
            pathCounter = 0;

            path.Add(new double[] { -0.05758161, -0.056587974, 10.010103493 });
            path.Add(new double[] { 299.94241839, -0.056587974, 10.010103493 });
            path.Add(new double[] { 299.94241839, -200.056587974, 10.010103493 });
            path.Add(new double[] { 213.474183961, -200.056587974, 10.010103493 });
            path.Add(new double[] { 190.254237086, -126.401926961, 10.010103493 });
            path.Add(new double[] { 122.459604485, -163.389260093, 10.010103493 });
            path.Add(new double[] { 59.039406438, -163.389260093, 10.010103493 });
            path.Add(new double[] { 33.084307566, -142.780034243, 10.010103493 });
            path.Add(new double[] { -0.05758161, -0.056587974, 10.010103493 });

            cp = path[1];
            pp = new double[3];
            np = path[pathCounter];
        }

        public override double[] NextPose()
        {

            if (pathCounter <= path.Count - 1)
            {
                double o = 0.05;
                double difX = Math.Abs(np[0] - cp[0]);
                double difY = Math.Abs(np[1] - cp[1]);
                double difZ = Math.Abs(np[2] - cp[2]);
                

                if (difX <= o && difY <= o && difZ <= o)
                {
                    np = path[pathCounter++];
                }
                
            }
            return np;

        }
        
        public override double[] PlannedPose()
        {
            throw new NotImplementedException();
        }

        public override void SetCurrentPose(double[] current)
        {
            cp = current;
        }

        public override void SetPlannedPose(double[] planned)
        {
            pp = planned;
        }

        public override void SetNextPose(double[] next)
        {
            np = next;
        }
    }
}
