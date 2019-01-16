using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LTH_EGM
{
    public abstract class Abstract_Data_Structure
    {

        private static Mutex mutex = new Mutex();
        
        public void TakeMutex(int millisecond_timeout)
        {
            mutex.WaitOne(millisecond_timeout);
        }

        public void GiveMutex()
        {
            mutex.ReleaseMutex();
        }

        public abstract double[] NextPose();

        public abstract double[] PlannedPose();

        public abstract void SetNextPose(double[] next);

        public abstract void SetCurrentPose(double[] next);

        public abstract void SetPlannedPose(double[] next);
        
    }
}
