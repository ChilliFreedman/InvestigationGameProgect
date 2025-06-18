using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal static class InvestigationManager
    {
       
        public static List<string> SensorTypes = new List<string> {"Thermal", "Audio", "Pulse", "Motion", "Magnetic","Signal", "Light" };
        
        
        //public static ThermalSensor SensorThermal = new ThermalSensor();
        //public static AudioSensor SensorAudio = new AudioSensor();
        //public static PulseSensor SensorPulse = new PulseSensor();
        //public static MotionSensor SensorMotion = new MotionSensor();
        //public static MagneticSensor SensorMagnetic = new MagneticSensor();
        //public static SignalSensor SensorSignal = new SignalSensor();
        //public static LightSensor SensorLight = new LightSensor();
        //public static Dictionary<string, Sensor> DictSensors = new Dictionary<string, Sensor>
        //{
        //    {"Thermal",new ThermalSensor() },
        //    {"Audio", new AudioSensor() },
        //    {"Pulse",new PulseSensor() },
        //    {"Motion",new MotionSensor() },
        //    {"Magnetic",new MagneticSensor()},
        //    {"Signal",new SignalSensor() },
        //    {"Light",new LightSensor()}
        //};

        public static IranianAgent Agent = new IranianAgent();
        public static SquadLeader squadLeader = new SquadLeader();
        public static SeniorCommander seniorCommander = new SeniorCommander();
        public static OrganizationLeader organizationLeader = new OrganizationLeader();
        public static Sensor CreateNewSensor(string type)
        {
            switch (type)
            {
                case "Thermal": return new ThermalSensor();
                case "Audio": return new AudioSensor();
                case "Pulse": return new PulseSensor();
                case "Motion": return new MotionSensor();
                case "Magnetic": return new MagneticSensor();
                case "Signal": return new SignalSensor();
                case "Light": return new LightSensor();
                default: throw new ArgumentException("Unknown sensor type");
            }
        }

        public static int counter;
        public static void AddSensor()
        {
            if (SensorTypes.Contains(ConsoleUI.sensorType.Type))
            {
                //Sensor newSensor = CreateNewSensor(ConsoleUI.sensorType);
                ConsoleUI.agentName.AttachedSensors.Add(ConsoleUI.sensorType);
                counter++;
                if (ConsoleUI.agentName.Rank != 2 && counter % 3 == 0 && ConsoleUI.agentName.GetMatchCount() > 0)
                {
                    AttekBack();
                }
                
                //ConsoleUI.sensorType.PublicCounter++;

                //Agent1.AttachedSensors.Add(DictSensors[ConsoleUI.sensorType]);
                //מבצע את ההפסקה של הסנסור פולס לאחר 3 הרצות
                //if (Agent1.AttachedSensors.Contains(SensorPulse))
                //bool a = false;
                PulseSensor sensor1 = new PulseSensor();
                for (int i = 0; i < ConsoleUI.agentName.AttachedSensors.Count; i++)
                //foreach (Sensor sensor in Agent1.AttachedSensors)
                {
                    if (ConsoleUI.agentName.AttachedSensors[i].Type == "Pulse" && ConsoleUI.agentName.AttachedSensors[i].PrivatCounter > 0)
                    {
                        ConsoleUI.agentName.AttachedSensors[i].PrivatCounter++;
                        Console.WriteLine(ConsoleUI.agentName.AttachedSensors[i].PrivatCounter);
                        if (ConsoleUI.agentName.AttachedSensors[i].PrivatCounter == 4)
                        {
                            //Agent1.Weaknesses.Remove(sensor.Type);
                            ConsoleUI.agentName.AttachedSensors[i].PrivatCounter = 0;
                            ConsoleUI.agentName.AttachedSensors.RemoveAt(i);
                            //Agent1.Weaknesses.Add(sensor.Type);
                            
                            
                            


                        }

                    }
                    //if (a)
                    //{
                    //    Agent1.AttachedSensors.Remove(sensor);
                    //}
                    
                }

                //}
                //if (SensorPulse.PrivatCounter > 0)
                //{
                    //SensorPulse.PrivatCounter++;
                   
                
                

                //foreach (Sensor sensor in Agent1.AttachedSensors)
                //{
                //    sensor.Activate();
                //}
                //if ()

            }
            else
            {
                ConsoleUI.PrintError();
            }
            
        }

        public static void RunTurn()
        {
            do
            {
                ConsoleUI.SetSensorType();
                AddSensor();

                if (ConsoleUI.agentName.Weaknesses.Contains(ConsoleUI.sensorType.Type))
                {
                    ConsoleUI.sensorType.Activate();
                    //for (int i = ConsoleUI.agentName.AttachedSensors.Count - 1; i >= 0;i--)
                    //{
                    //    if (ConsoleUI.agentName.AttachedSensors[i].Type == ConsoleUI.sensorType.Type)
                    //    {
                    //        ConsoleUI.agentName.AttachedSensors[i].Activate();
                    //        break;
                    //    }
                    //}
                    //foreach (Sensor sensor in Agent1.AttachedSensors)
                    //{
                    //    if (sensor.Type == ConsoleUI.sensorType)
                    //    {
                            
                    //        //break;
                    //    }

                    //}
                    
                }     
                //if (Agent1.AttachedSensors.Contains(DictSensors[ConsoleUI.sensorType]))
                //{
                //    foreach (Sensor sensor in Agent1.AttachedSensors)
                //    {
                //        if (Agent1.Weaknesses.Contains(sensor.Type))
                //        {
                //            sensor.Activate();
                //        }
                //    }
                //}
                ConsoleUI.PrintTheResult();
                if (counter % 10 == 0)
                {
                    Clear10();
                }
                //רק הדפסה בשלב בנייה בשביל בדיקת הרשימות כל תור
                //Console.WriteLine(SensorPulse.PrivatCounter);
                foreach (var sensor in ConsoleUI.agentName.Weaknesses)
                {
                    Console.WriteLine(sensor + "1");
                }
                foreach (var sensor in ConsoleUI.agentName.AttachedSensors)
                {
                    Console.WriteLine(sensor.Type + "2");
                }
               

            }
            while (ConsoleUI.agentName.GetMatchCount() != ConsoleUI.agentName.Weaknesses.Count);
            
            
        }
        public static void AttekBack()
        {
            
            Random rand = new Random();
            int attackCount = ConsoleUI.agentName.Attack();
            int countSensors = ConsoleUI.agentName.AttachedSensors.Count;

            if (countSensors == 0)
            {
                return;
            }
                 

            if (attackCount > countSensors)
            {
                attackCount = countSensors;
            }
                
            for (int i = 0;  i < attackCount; i++)
            {
                
               
                int indexsensor = rand.Next(0, ConsoleUI.agentName.AttachedSensors.Count);
                    
                ConsoleUI.agentName.AttachedSensors.RemoveAt(indexsensor);
                    
                    
               
                


            }
        }
        public static void Clear10()
        {
            //ConsoleUI.agentName.Weaknesses.Clear();
            ConsoleUI.agentName.AttachedSensors.Clear();
            //ConsoleUI.agentName.AttachedSensors.Add(ConsoleUI.sensorType);
            ConsoleUI.agentName.Weaknesses = ConsoleUI.agentName.FunRendumToWeaknesses();


        }


    }
}
