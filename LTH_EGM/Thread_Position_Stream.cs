using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

using abb.egm;

namespace LTH_EGM
{
    public class Thread_Position_Stream : Abstract_Udp_Thread
    {
        EgmSensor.Builder sensor = null;

        public Thread_Position_Stream() : base((int)Port_Numbers.POS_STREAM_PORT) { }

        public override void CreateMessage(double[] pose)
        {
            sensor = EgmSensor.CreateBuilder();
            // create a header
            EgmHeader.Builder hdr = new EgmHeader.Builder();
            hdr.SetSeqno((uint)_seqNbr++)
                .SetTm((uint)DateTime.Now.Ticks)
                .SetMtype(EgmHeader.Types.MessageType.MSGTYPE_CORRECTION);

            sensor.SetHeader(hdr);

            // create some sensor data
            EgmPlanned.Builder planned = new EgmPlanned.Builder();
            EgmPose.Builder pos = new EgmPose.Builder();
            EgmQuaternion.Builder pq = new EgmQuaternion.Builder();
            EgmCartesian.Builder pc = new EgmCartesian.Builder();

            pc.SetX(pose[0])
                .SetY(pose[1])
                .SetZ(pose[2]);

            pq.SetU0(1.0)
                .SetU1(0.0)
                .SetU2(0.0)
                .SetU3(0.0);

            pos.SetPos(pc)
                .SetOrient(pq);

            planned.SetCartesian(pos);  // bind pos object to planned
            sensor.SetPlanned(planned); // bind planned to sensor object

            return;
        }

        public override void CreateMessage(Abstract_Data_Structure behavior)
        {
            throw new NotImplementedException();
        }

        public override void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior)
        {
            EGM_Sensor_Server_Behavior behave = (EGM_Sensor_Server_Behavior)behavior;
            // Deserialize the message
            EgmRobot robot = EgmRobot.CreateBuilder().MergeFrom(data).Build();
            //DebugDisplay($"({robot.FeedBack.Cartesian.Pos.X}, {robot.FeedBack.Cartesian.Pos.Y}, {robot.FeedBack.Cartesian.Pos.Z})");
            Robot_pose feedback = new Robot_pose();
            Robot_pose planned = new Robot_pose();

            feedback.Joints = new double[] {
                robot.FeedBack.Joints.GetJoints(0),
                robot.FeedBack.Joints.GetJoints(1) ,
                robot.FeedBack.Joints.GetJoints(2) ,
                robot.FeedBack.Joints.GetJoints(3) ,
                robot.FeedBack.Joints.GetJoints(4) ,
                robot.FeedBack.Joints.GetJoints(5)
            };
            feedback.Cartesian = new double[] {
                robot.FeedBack.Cartesian.Pos.X,
                robot.FeedBack.Cartesian.Pos.Y,
                robot.FeedBack.Cartesian.Pos.Z
            };
            feedback.Quarternion = new double[] {
                robot.FeedBack.Cartesian.Orient.U0,
                robot.FeedBack.Cartesian.Orient.U1,
                robot.FeedBack.Cartesian.Orient.U2,
                robot.FeedBack.Cartesian.Orient.U3
            };
            feedback.Euler = new double[] {
                robot.FeedBack.Cartesian.Euler.X,
                robot.FeedBack.Cartesian.Euler.Y,
                robot.FeedBack.Cartesian.Euler.Z
            };
            feedback.ExternalJoints = new double[]
            {
                robot.FeedBack.ExternalJoints.GetJoints(0),
                robot.FeedBack.ExternalJoints.GetJoints(1),
                robot.FeedBack.ExternalJoints.GetJoints(2),
                robot.FeedBack.ExternalJoints.GetJoints(3),
                robot.FeedBack.ExternalJoints.GetJoints(4),
                robot.FeedBack.ExternalJoints.GetJoints(5)
            };
            feedback.Time = new Int64[]
            {
                (Int64)robot.FeedBack.Time.Sec, 
                (Int64)robot.FeedBack.Time.Usec
            };

            planned.Joints = new double[]
            {
                robot.Planned.Joints.GetJoints(0),
                robot.Planned.Joints.GetJoints(1),
                robot.Planned.Joints.GetJoints(2),
                robot.Planned.Joints.GetJoints(3),
                robot.Planned.Joints.GetJoints(4),
                robot.Planned.Joints.GetJoints(5)
            };
            planned.Cartesian = new double[] {
                robot.Planned.Cartesian.Pos.X,
                robot.Planned.Cartesian.Pos.Y,
                robot.Planned.Cartesian.Pos.Z
            };
            planned.Quarternion = new double[]
            {
                robot.Planned.Cartesian.Orient.U0,
                robot.Planned.Cartesian.Orient.U1,
                robot.Planned.Cartesian.Orient.U2,
                robot.Planned.Cartesian.Orient.U3
            };
            planned.Euler = new double[]
            {
                robot.Planned.Cartesian.Euler.X,
                robot.Planned.Cartesian.Euler.Y,
                robot.Planned.Cartesian.Euler.Z
            };
            planned.ExternalJoints = new double[]
            {
                robot.Planned.ExternalJoints.GetJoints(0),
                robot.Planned.ExternalJoints.GetJoints(1),
                robot.Planned.ExternalJoints.GetJoints(2),
                robot.Planned.ExternalJoints.GetJoints(3),
                robot.Planned.ExternalJoints.GetJoints(4),
                robot.Planned.ExternalJoints.GetJoints(5
                )
            };
            planned.Time = new Int64[] {
                (Int64)robot.Planned.Time.Sec,
                (Int64)robot.Planned.Time.Usec
            };

            behave.TakeMutex(10); //prevent the all race conditions!
            behave.Seqno = robot.Header.Seqno;
            behave.Tm = robot.Header.Tm;
            behave.Mtype = (int)robot.Header.Mtype;
            behave.Feedback = feedback;
            behave.Planned = planned;
            behave.MotorState = (int)robot.MotorState.State;
            behave.MciState = (int)robot.MciState.State;
            behave.MciConvergenceMet = robot.MciConvergenceMet;
            behave.TestSignals = robot.TestSignals.SignalsList;
            behave.RapidExceState = (int)robot.RapidExecState.State;
            behave.MesauredForce = new double[robot.MeasuredForce.ForceList.Count];
            int i = 0;
            foreach (double force in robot.MeasuredForce.ForceList)
            {
                behave.MesauredForce[i] = force;
                i++;
            }
            behave.GiveMutex();
            


            // Create this type of sensor message;
            CreateMessage(behavior.NextPose());

            // Send the message
            using (MemoryStream memoryStream = new MemoryStream())
            {
                EgmSensor sensorMessage = sensor.Build();
                sensorMessage.WriteTo(memoryStream);
                // send the udp message to the robot
                int bytesSent = udpServer.Send(memoryStream.ToArray(),
                    (int)memoryStream.Length, remoteEP);
                if (bytesSent < 0)
                {
                    DebugDisplay("Error send to robot");
                }
            }
            sensor = null;
        }
        
    }
}
