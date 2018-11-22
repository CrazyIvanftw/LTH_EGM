using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LTH_EGM
{
    public class Test_Data_Structure : Abstract_Data_Structure
    {

        List<double[]> path;
        int pathCounter;

        double[] cp; //current pose
        double[] pp; //planned pose
        double[] np; //next pose

        public Test_Data_Structure()
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
            Console.WriteLine($"{pathCounter}, {path.Count}");

            if(pathCounter <= path.Count -1)
            {
                double o = 0.05;
                double difX = Math.Abs(np[0] - cp[0]);
                double difY = Math.Abs(np[1] - cp[1]);
                double difZ = Math.Abs(np[2] - cp[2]);

                Console.WriteLine($"{difX}, {difY}, {difZ}");

                if (difX <= o && difY <= o && difZ <= o)
                {
                    Console.WriteLine("where it should NEVER GO");
                    np = path[pathCounter++];
                }
                else
                {
                    Console.WriteLine("where it should get");
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
