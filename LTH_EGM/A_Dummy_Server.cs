﻿using System;
using System.Collections.Generic;

namespace LTH_EGM
{
    public class A_Dummy_Server
    {

        Thread_Greg_Protocol_Adapter thread = new Thread_Greg_Protocol_Adapter();
        EGM_Sensor_Server_Data_Structure behavior = new EGM_Sensor_Server_Data_Structure();

        public A_Dummy_Server()
        {
            Robot_pose dummyPose = new Robot_pose();
            dummyPose.Cartesian = new double[] { 0, 1, 2 };
            dummyPose.Quarternion = new double[] { 0, 1, 2, 3 };
            dummyPose.Euler = new double[] { 0, 1, 2 };
            dummyPose.ExternalJoints = new double[] { 0, 1, 2, 3, 4, 5 };
            dummyPose.Joints = new double[] { 0, 1, 2, 3, 4, 5 };
            dummyPose.Time = new long[] { 0, 1 };
            behavior.Desired = dummyPose;
            behavior.Feedback = dummyPose;
            behavior.Planned = dummyPose;
            behavior.MciState = (int)abb.egm.EgmMCIState.Types.MCIStateType.MCI_ERROR;
            behavior.MciConvergenceMet = false;
            behavior.MotorState = (int)abb.egm.EgmMotorState.Types.MotorStateType.MOTORS_UNDEFINED;
            behavior.RapidExceState = (int)abb.egm.EgmRapidCtrlExecState.Types.RapidCtrlExecStateType.RAPID_UNDEFINED;
            behavior.Seqno = 0;
            behavior.Tm = 0;
            behavior.Mtype = 0;
            List<double> list = new List<double>();
            for (int i = 0; i < 6; i++)
            {
                list.Add(i);
            }
            behavior.TestSignals = list;
            behavior.MesauredForce = new double[] { 0, 1, 2, 3, 4, 5 };
            Console.WriteLine(behavior.PrintOut());
        }

        public void StartServer()
        {
            thread.StartTryFetch(behavior);
        }

        public void StopServer()
        {
            thread.Stop();
        }
    }
}
