
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

        
    }
}
