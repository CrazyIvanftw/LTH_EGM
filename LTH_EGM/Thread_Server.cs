using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using lth.egm;

namespace LTH_EGM
{
    public class Thread_Server : Abstract_Udp_Thread
    {

        EGM_Control.Builder response;

        public Thread_Server() : base((int)Port_Numbers.SERVER_PORT) { }

        public override void CreateMessage(double[] pose)
        {
            EGM_Control.Builder response = EGM_Control.CreateBuilder();
            Header.Builder header = new Header.Builder();
        }

        public override void CreateMessage(Abstract_Data_Structure behavior)
        {
            response = EGM_Control.CreateBuilder();
            Header.Builder header = new Header.Builder();
            header.SetMtype(Header.Types.MessageType.MSGTYPE_POS_ACK);
        }

        public void CreateMessageType(int type, Abstract_Data_Structure behavior)
        {
            EGM_Sensor_Server_Behavior behave = (EGM_Sensor_Server_Behavior)behavior;
            response = EGM_Control.CreateBuilder();
            Header.Builder header = new Header.Builder();
            Position_Values.Builder desired = new Position_Values.Builder();
            Position_Values.Builder current = new Position_Values.Builder();
            Position_Values.Builder planned = new Position_Values.Builder();
            Feedback_Values.Builder feedback = new Feedback_Values.Builder();
            Time.Builder time = new Time.Builder();
            Console.WriteLine("inside create message type");
            switch (type)
            {
                // UNDEFINED --------------------------------------------------
                case (int)Header.Types.MessageType.MSGTYPE_UNDEFINED:
                    // I don't know... I'm never gonna do anything with this... maybe there's value to leaving it in
                    // There's also a reasonable argument to wait for the code review
                    // I might use this as a general error 
                    break;

                // POSITION COMMAND ACK --------------------------------------------------
                case (int)Header.Types.MessageType.MSGTYPE_POS_ACK:
                    header.SetMtype(Header.Types.MessageType.MSGTYPE_POS_ACK);
                    response.SetHeader(header);
                    break;

                // POSITION REQUEST ACK --------------------------------------------------
                case (int)Header.Types.MessageType.MSGTYPE_ACK_POS_VALUES:
                    header.SetMtype(Header.Types.MessageType.MSGTYPE_ACK_POS_VALUES);

                    //INCOMPLETE -> FLESH OUT ALL OF THIS NONSENSE 
                    //*******************************************************
                    //desired
                    desired.SetCartesianX(behave.Desired.Cartesian[0]);
                    desired.SetCartesianY(behave.Desired.Cartesian[1]);
                    desired.SetCartesianZ(behave.Desired.Cartesian[2]);
                    //current
                    current.SetCartesianX(behave.Feedback.Cartesian[0]);
                    current.SetCartesianY(behave.Feedback.Cartesian[1]);
                    current.SetCartesianZ(behave.Feedback.Cartesian[2]);
                    //planned
                    planned.SetCartesianX(behave.Planned.Cartesian[0]);
                    planned.SetCartesianY(behave.Planned.Cartesian[1]);
                    planned.SetCartesianZ(behave.Planned.Cartesian[2]);

                    response.SetHeader(header);
                    response.SetDesiredPosition(desired);
                    response.SetCurrentPosition(current);
                    response.SetPlannedPosition(planned);
                    //*******************************************************
                    break;

                // FEEDBACK REQUEST ACK --------------------------------------------------
                case (int)Header.Types.MessageType.MSGTYPE_ACK_FEEDBACK_VALUES:
                    header.SetMtype(Header.Types.MessageType.MSGTYPE_ACK_FEEDBACK_VALUES);
                    //set motor state
                    switch (behave.MotorState)
                    {
                        case (int)Feedback_Values.Types.MotorStateType.MOTORS_OFF:
                            feedback.SetMotorState(Feedback_Values.Types.MotorStateType.MOTORS_OFF);
                            break;

                        case (int)Feedback_Values.Types.MotorStateType.MOTORS_ON:
                            feedback.SetMotorState(Feedback_Values.Types.MotorStateType.MOTORS_ON);
                            break;

                        case (int)Feedback_Values.Types.MotorStateType.MOTORS_UNDEFINED:
                            feedback.SetMotorState(Feedback_Values.Types.MotorStateType.MOTORS_UNDEFINED);
                            break;
                    }
                    //set MCI State
                    switch (behave.MciState)
                    {
                        case (int)Feedback_Values.Types.MCIStateType.MCI_ERROR:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_ERROR);
                            break;

                        case (int)Feedback_Values.Types.MCIStateType.MCI_RUNNING:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_RUNNING);
                            break;

                        case (int)Feedback_Values.Types.MCIStateType.MCI_STOPPED:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_STOPPED);
                            break;

                        case (int)Feedback_Values.Types.MCIStateType.MCI_UNDEFINED:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_UNDEFINED);
                            break;
                    }
                    //set MCI convergence met
                    feedback.SetMciConvergenceMet(behave.MciConvergenceMet);
                    //set RAPID execution state
                    switch (behave.RapidExceState)
                    {
                        case (int)Feedback_Values.Types.RapidCtrlExecStateType.RAPID_RUNNING:
                            feedback.SetRapidExceState(Feedback_Values.Types.RapidCtrlExecStateType.RAPID_RUNNING);
                            break;

                        case (int)Feedback_Values.Types.RapidCtrlExecStateType.RAPID_STOPPED:
                            feedback.SetRapidExceState(Feedback_Values.Types.RapidCtrlExecStateType.RAPID_STOPPED);
                            break;

                        case (int)Feedback_Values.Types.RapidCtrlExecStateType.RAPID_UNDEFINED:
                            feedback.SetRapidExceState(Feedback_Values.Types.RapidCtrlExecStateType.RAPID_UNDEFINED);
                            break;
                    }
                    //set test signals
                    int i = 0;
                    foreach (double signal in behave.TestSignals)
                    {
                        feedback.SetTestSignals(i, signal);
                        i++;
                    }
                    //set measured force
                    for (int j = 0; j < 6; j++)
                    {
                        feedback.SetMeasuredForce(j, behave.MesauredForce[j]);
                    }
                    response.SetHeader(header);
                    response.SetFeedback(feedback);
                    break;

                // ALL REQUEST ACK --------------------------------------------------
                case (int)Header.Types.MessageType.MSGTYPE_ACK_ALL_VALUES:
                    Console.WriteLine($"MSGTYPE_ACK_ALL_VALUES -> switch nbr: {type}");
                    int marker = 0;
                    //header
                    header.SetMtype(Header.Types.MessageType.MSGTYPE_ACK_ALL_VALUES);

                    //INCOMPLETE -> FLESH OUT ALL OF THIS NONSENSE 
                    //*******************************************************
                    //desired
                    desired.SetCartesianX(behave.Desired.Cartesian[0]);
                    desired.SetCartesianY(behave.Desired.Cartesian[1]);
                    desired.SetCartesianZ(behave.Desired.Cartesian[2]);
                    //current
                    current.SetCartesianX(behave.Feedback.Cartesian[0]);
                    current.SetCartesianY(behave.Feedback.Cartesian[1]);
                    current.SetCartesianZ(behave.Feedback.Cartesian[2]);
                    //planned
                    planned.SetCartesianX(behave.Planned.Cartesian[0]);
                    planned.SetCartesianY(behave.Planned.Cartesian[1]);
                    planned.SetCartesianZ(behave.Planned.Cartesian[2]);
                    Console.WriteLine($"marker: {marker++}");
                    //*******************************************************

                    //FEEDBACK
                    //set motor state
                    switch (behave.MotorState)
                    {
                        case (int)Feedback_Values.Types.MotorStateType.MOTORS_OFF:
                            feedback.SetMotorState(Feedback_Values.Types.MotorStateType.MOTORS_OFF);
                            break;

                        case (int)Feedback_Values.Types.MotorStateType.MOTORS_ON:
                            feedback.SetMotorState(Feedback_Values.Types.MotorStateType.MOTORS_ON);
                            break;

                        case (int)Feedback_Values.Types.MotorStateType.MOTORS_UNDEFINED:
                            feedback.SetMotorState(Feedback_Values.Types.MotorStateType.MOTORS_UNDEFINED);
                            break;
                    }
                    Console.WriteLine($"marker: {marker++}");
                    //set MCI State
                    switch (behave.MciState)
                    {
                        case (int)Feedback_Values.Types.MCIStateType.MCI_ERROR:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_ERROR);
                            break;

                        case (int)Feedback_Values.Types.MCIStateType.MCI_RUNNING:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_RUNNING);
                            break;

                        case (int)Feedback_Values.Types.MCIStateType.MCI_STOPPED:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_STOPPED);
                            break;

                        case (int)Feedback_Values.Types.MCIStateType.MCI_UNDEFINED:
                            feedback.SetMciState(Feedback_Values.Types.MCIStateType.MCI_UNDEFINED);
                            break;
                    }
                    Console.WriteLine($"marker: {marker++}");
                    //set MCI convergence met
                    feedback.SetMciConvergenceMet(behave.MciConvergenceMet);
                    Console.WriteLine($"marker: {marker++}");
                    //set RAPID execution state
                    switch (behave.RapidExceState)
                    {
                        case (int)Feedback_Values.Types.RapidCtrlExecStateType.RAPID_RUNNING:
                            feedback.SetRapidExceState(Feedback_Values.Types.RapidCtrlExecStateType.RAPID_RUNNING);
                            break;

                        case (int)Feedback_Values.Types.RapidCtrlExecStateType.RAPID_STOPPED:
                            feedback.SetRapidExceState(Feedback_Values.Types.RapidCtrlExecStateType.RAPID_STOPPED);
                            break;

                        case (int)Feedback_Values.Types.RapidCtrlExecStateType.RAPID_UNDEFINED:
                            feedback.SetRapidExceState(Feedback_Values.Types.RapidCtrlExecStateType.RAPID_UNDEFINED);
                            break;
                    }
                    Console.WriteLine($"marker: {marker++}");
                    //set test signals
                    int k = 0;
                    foreach (double signal in behave.TestSignals)
                    {
                        //feedback.SetTestSignals(k, signal);
                        //k++;
                    }
                    Console.WriteLine($"marker: {marker++}");
                    //set measured force
                    for (int j = 0; j < 6; j++)
                    {
                        //feedback.SetMeasuredForce(j, behave.MesauredForce[j]);
                    }
                    Console.WriteLine($"marker: {marker++}");
                    //set response
                    response.SetHeader(header);
                    response.SetDesiredPosition(desired);
                    response.SetCurrentPosition(current);
                    response.SetPlannedPosition(planned);
                    response.SetFeedback(feedback);
                    Console.WriteLine($"marker: {marker++}");
                    break;
            }
        }

        public override void ProcessData(UdpClient udpServer, IPEndPoint remoteEP, byte[] data, Abstract_Data_Structure behavior)
        {
            EGM_Sensor_Server_Behavior behave = (EGM_Sensor_Server_Behavior)behavior;
            EGM_Control control = EGM_Control.CreateBuilder().MergeFrom(data).Build();
            Console.WriteLine("In Server Thread!!!");
            Console.WriteLine(control);
            int type = (int)control.Header.Mtype;
            Console.WriteLine($"Mtype: {type}");
            switch (type)
            {
                case (int)Header.Types.MessageType.MSGTYPE_UNDEFINED:
                    // I don't know... I'm never gonna do anything with this... maybe there's value to leaving it in
                    // There's also a reasonable argument to wait for the code review
                    // I might use this as a general error 
                    Console.WriteLine("MSGTYPE_UNDEFINED");
                    break;

                case (int)Header.Types.MessageType.MSGTYPE_POS_COMMAND:
                    // This is supposed to replace the current desired target with a new desired target
                    Robot_pose pose = new Robot_pose();
                    pose.Joints = new double[]
                    {
                        control.DesiredPosition.RobotJoints.GetJoints_(0),
                        control.DesiredPosition.RobotJoints.GetJoints_(1),
                        control.DesiredPosition.RobotJoints.GetJoints_(2),
                        control.DesiredPosition.RobotJoints.GetJoints_(3),
                        control.DesiredPosition.RobotJoints.GetJoints_(4),
                        control.DesiredPosition.RobotJoints.GetJoints_(5)
                    };
                    pose.Cartesian = new double[]
                    {
                        control.DesiredPosition.CartesianX,
                        control.DesiredPosition.CartesianY,
                        control.DesiredPosition.CartesianZ
                    };
                    pose.Quarternion = new double[]
                    {
                        control.DesiredPosition.Quarternion0,
                        control.DesiredPosition.Quarternion1,
                        control.DesiredPosition.Quarternion2,
                        control.DesiredPosition.Quarternion3
                    };
                    pose.Euler = new double[]
                    {
                        control.DesiredPosition.EulerX,
                        control.DesiredPosition.EulerY,
                        control.DesiredPosition.EulerZ
                    };
                    pose.ExternalJoints = new double[]
                    {
                        control.DesiredPosition.ExternalJoints.GetJoints_(0),
                        control.DesiredPosition.ExternalJoints.GetJoints_(1),
                        control.DesiredPosition.ExternalJoints.GetJoints_(2),
                        control.DesiredPosition.ExternalJoints.GetJoints_(3),
                        control.DesiredPosition.ExternalJoints.GetJoints_(4),
                        control.DesiredPosition.ExternalJoints.GetJoints_(5)
                    };
                    pose.Time = new long[]
                    {
                        (long)control.DesiredPosition.Time.Sec,
                        (long)control.DesiredPosition.Time.Usec
                    };
                    behave.Desired = pose;
                    CreateMessageType((int)Header.Types.MessageType.MSGTYPE_POS_ACK, behave);
                    Console.WriteLine("MSGTYPE_POS_COMMAND");
                    break;

                case (int)Header.Types.MessageType.MSGTYPE_REQUEST_POS_VALUES:
                    CreateMessageType((int)Header.Types.MessageType.MSGTYPE_ACK_POS_VALUES, behave);
                    Console.WriteLine("MSGTYPE_REQUEST_POS_VALUES");
                    break;

                case (int)Header.Types.MessageType.MSGTYPE_REQUEST_FEEDBACK_VALUES:
                    CreateMessageType((int)Header.Types.MessageType.MSGTYPE_ACK_FEEDBACK_VALUES, behave);
                    Console.WriteLine("MSGTYPE_REQUEST_FEEDBACK_VALUES");
                    break;

                case (int)Header.Types.MessageType.MSGTYPE_REQUEST_ALL_VALUES:
                    Console.WriteLine("Start MSGTYPE_REQUEST_ALL_VALUES");
                    CreateMessageType((int)Header.Types.MessageType.MSGTYPE_ACK_ALL_VALUES, behave);
                    Console.WriteLine("MSGTYPE_REQUEST_ALL_VALUES");
                    break;
            }

            // Send the message
            using (MemoryStream memoryStream = new MemoryStream())
            {
                EGM_Control message = response.Build();
                Console.WriteLine("message to send back:");
                Console.WriteLine(message);
                message.WriteTo(memoryStream);
                // send the udp message to the robot
                int bytesSent = udpServer.Send(memoryStream.ToArray(),
                    (int)memoryStream.Length, remoteEP);
                if (bytesSent < 0)
                {
                    DebugDisplay("Error send to robot");
                }
            }
            response = null;
        }

        
    }
}
