using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

using abb.egm;

namespace LTH_EGM
{
    public class Thread_Sensor_Guidance : Abstract_Udp_Thread
    {

        EgmSensor.Builder sensor = null;
        double[] testTarget = new double[] { 878.795086254, -100.066190776, 1412.499981377 };
        double oldY = 0.0;

        public Thread_Sensor_Guidance() : base((int)Port_Numbers.POS_GUIDE_PORT) { Debug.WriteLine("sensor guide started"); }

        public override void CreateMessage(Abstract_Data_Structure behavior)
        {
            EGM_Sensor_Server_Data_Structure behave = (EGM_Sensor_Server_Data_Structure)behavior;
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

            double[] coordinates;
            coordinates = behave.Feedback.Cartesian;
            double deltaY = 0.0;
            Debug.WriteLine($"coordinates: {0} \n delta Y: {1}", coordinates, deltaY);
            if (behave.SensedPoint[1] != 0.0)
            {
                deltaY = behave.SensedPoint[1] - oldY;
                oldY = behave.SensedPoint[1];
            }

            if (false)
            {
                pc.SetX(testTarget[0])
                .SetY(testTarget[1])
                .SetZ(testTarget[2]);
            }
            else
            {
                pc.SetX(coordinates[0])
                .SetY(coordinates[1] + deltaY)
                .SetZ(coordinates[2]);
            }

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

        public override void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior)
        {
            //Debug.WriteLine("--------------------------POS GUIDE THREAD--------------------------");
            EGM_Sensor_Server_Data_Structure behave = (EGM_Sensor_Server_Data_Structure)behavior;
            // Deserialize the message
            EgmRobot robot = EgmRobot.CreateBuilder().MergeFrom(data).Build();
            //Debug.WriteLine("--------------------------EGM INBOUND--------------------------");
            //Debug.WriteLine(robot);
            //Debug.WriteLine("--------------------------EGM INBOUND--------------------------");


            Robot_pose feedback = new Robot_pose();

            feedback.Cartesian = new double[] {
                robot.FeedBack.Cartesian.Pos.X,
                robot.FeedBack.Cartesian.Pos.Y,
                robot.FeedBack.Cartesian.Pos.Z
            };
            

            

            //behave.TakeMutex(10); //prevent the all race conditions!
            behave.Feedback = feedback;
            //behave.GiveMutex();

            // Create this type of sensor message;
            CreateMessage(behavior);

            // Send the message
            using (MemoryStream memoryStream = new MemoryStream())
            {
                EgmSensor sensorMessage = sensor.Build();
                //Debug.WriteLine("--------------------------EGM.PROTO MESSAGE--------------------------");
                //Debug.WriteLine(sensorMessage);
                //Debug.WriteLine("--------------------------EGM.PROTO MESSAGE--------------------------");
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

