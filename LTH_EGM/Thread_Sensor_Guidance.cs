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
            double offset = 145.0; //the standard offset for the tool poinf of the robot at the radius of the *head* the radius of the sphere is 150mm 
            behave.TakeMutex(50);
            coordinates = behave.Feedback.Cartesian;
            double plannedY = behave.Planned.Cartesian[1];
            double sensedY = behave.SensedPoint[1] + offset;
            behave.GiveMutex();
            double currentY = coordinates[1];
            double deltaY = sensedY - currentY;
            double sentY = currentY + deltaY*1.8;
             
            Debug.WriteLine($"Data: \n robot y: \t{currentY} \n planned y: \t{plannedY} \n sensed y + offset: \t{sensedY} \n old sense y: \t{oldY} \n delta y: \t{deltaY} \n sent y: \t{sentY}");

            oldY = sensedY;
            if (false)
            {
                pc.SetX(testTarget[0])
                .SetY(testTarget[1])
                .SetZ(testTarget[2]);
            }
            else
            {
                pc.SetX(coordinates[0])
                .SetY(sentY)
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
            Debug.WriteLine($"sent egm message: ({sensor.Planned.Cartesian.Pos.X}, {sensor.Planned.Cartesian.Pos.Y}, {sensor.Planned.Cartesian.Pos.Z})");
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
            Debug.WriteLine($"incoming egm message: ({robot.FeedBack.Cartesian.Pos.X}, {robot.FeedBack.Cartesian.Pos.Y}, {robot.FeedBack.Cartesian.Pos.Z})");

            Robot_pose feedback = new Robot_pose();
            Robot_pose planned = new Robot_pose();

            feedback.Cartesian = new double[] {
                robot.FeedBack.Cartesian.Pos.X,
                robot.FeedBack.Cartesian.Pos.Y,
                robot.FeedBack.Cartesian.Pos.Z
            };

            planned.Cartesian = new double[]
            {
                robot.Planned.Cartesian.Pos.X,
                robot.Planned.Cartesian.Pos.Y,
                robot.Planned.Cartesian.Pos.Z
            };
            //Debug.WriteLine($"inbound: ({feedback.Cartesian[0]}, {feedback.Cartesian[1]}, {feedback.Cartesian[2]})");
            //Debug.WriteLine($"inbound: ({robot.Planned.Cartesian.Pos})");




            //behave.TakeMutex(10); //prevent the all race conditions!
            behave.Feedback = feedback;
            behave.Planned = planned;
            //behave.GiveMutex();

            // Create this type of sensor message;
            CreateMessage(behavior);

            // Send the message
            using (MemoryStream memoryStream = new MemoryStream())
            {
                EgmSensor sensorMessage = sensor.Build();
                //Debug.WriteLine("Guide Message:");
                //Debug.WriteLine(sensor.Planned.Cartesian);
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

