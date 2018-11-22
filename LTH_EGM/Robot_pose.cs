
using System;
using System.Collections.Generic;
using System.Text;

namespace LTH_EGM
{
    public class Robot_pose
    {
        private double[] joints;
        private double[] cartesian;
        private double[] quarternion;
        private double[] euler;
        private double[] externalJoints;
        private Int64[] time;

        public double[] Joints { get => joints; set => joints = value; }
        public double[] Cartesian { get => cartesian; set => cartesian = value; }
        public double[] Quarternion { get => quarternion; set => quarternion = value; }
        public double[] Euler { get => euler; set => euler = value; }
        public double[] ExternalJoints { get => externalJoints; set => externalJoints = value; }
        public long[] Time { get => time; set => time = value; }

        public string PrintOut()
        {
            string s =
                $"\n time: {time[0]}, {time[1]}" +
                $"\n joints: \n\t{joints[0]}\n\t{joints[1]}\n\t{joints[2]}\n\t{joints[3]}\n\t{joints[4]}\n\t{joints[5]}" +
                //$"\n externalJoints: \n\t{externalJoints[0]}\n\t{externalJoints[1]}\n\t{externalJoints[2]}\n\t{externalJoints[3]}\n\t{externalJoints[4]}\n\t{externalJoints[5]}" +
                "\n coordinates:" +
                $"\n\t x:{cartesian[0]}\t u0:{quarternion[0]}\t\t euler_x:{euler[0]} \n" +
                $"\n\t y:{cartesian[1]}\t u1:{quarternion[1]}\t\t euler_y:{euler[1]} \n" +
                $"\n\t z:{cartesian[2]}\t u2:{quarternion[2]}\t\t euler_z:{euler[2]} \n" +
                $"\n\t                 \t u3:{quarternion[3]} \n";
            return s;
        }
    }
}
