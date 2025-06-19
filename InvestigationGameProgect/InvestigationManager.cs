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

        //public static IranianAgent Agent = new IranianAgent();
        //public static SquadLeader squadLeader = new SquadLeader();
        //public static SeniorCommander seniorCommander = new SeniorCommander();
        //public static OrganizationLeader organizationLeader = new OrganizationLeader();
        

        public static int counter;
        public static void AddSensor()
        {
            if (SensorTypes.Contains(ConsoleUI.sensorType.Type))
            {
                ConsoleUI.agentName.AttachedSensors.Add(ConsoleUI.sensorType);
                counter++;
                if (ConsoleUI.agentName.Rank != 2 && counter % 3 == 0 && ConsoleUI.agentName.GetMatchCount() > 0)
                {
                    AttekBack();
                }
                
                
                //PulseSensor sensor1 = new PulseSensor();
                for (int i = 0; i < ConsoleUI.agentName.AttachedSensors.Count; i++)
                {
                    if (ConsoleUI.agentName.AttachedSensors[i].Type == "Pulse" && ConsoleUI.agentName.AttachedSensors[i].PrivatCounter > 0)
                    {
                        ConsoleUI.agentName.AttachedSensors[i].PrivatCounter++;
                        Console.WriteLine(ConsoleUI.agentName.AttachedSensors[i].PrivatCounter);
                        if (ConsoleUI.agentName.AttachedSensors[i].PrivatCounter == 4)
                        {
                            ConsoleUI.agentName.AttachedSensors[i].PrivatCounter = 0;
                            ConsoleUI.agentName.AttachedSensors.RemoveAt(i);
                        }

                    }
           
                }

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
                   
                }     
 
                ConsoleUI.PrintTheResult();
                if (counter % 10 == 0)
                {
                    Clear10();
                }
                //רק הדפסה בשלב בנייה בשביל בדיקת הרשימות כל תור
                Console.WriteLine("\nweknes list:\n");
                foreach (var sensor in ConsoleUI.agentName.Weaknesses)
                {
                    Console.WriteLine(sensor +" " + "1");
                }
                Console.WriteLine("\nAttached list:\n");
                foreach (var sensor in ConsoleUI.agentName.AttachedSensors)
                {
                    Console.WriteLine(sensor.Type + " " + "2");
                }
               //

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
            ConsoleUI.agentName.AttachedSensors.Clear();
            ConsoleUI.agentName.Weaknesses = ConsoleUI.agentName.FunRendumToWeaknesses();
        }


    }
}
