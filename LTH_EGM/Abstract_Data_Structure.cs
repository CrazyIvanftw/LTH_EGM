using System;
using System.Collections.Generic;
using System.Text;

namespace LTH_EGM
{
    public abstract class Abstract_Data_Structure
    {
        public abstract double[] NextPose();

        public abstract double[] PlannedPose();

        public abstract void SetNextPose(double[] next);

        public abstract void SetCurrentPose(double[] next);

        public abstract void SetPlannedPose(double[] next);
        
    }
}
