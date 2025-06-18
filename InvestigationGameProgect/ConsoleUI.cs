using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal static class ConsoleUI
    {
        public static Sensor sensorType;
        public static IranianAgent agentName;

        public static void setagent()
        {
            string choise;
            do
            {
                Console.WriteLine("enter a type of agent \nfor Foot Soldier press 1." +
                "\nfor Squad Leader press 2" +
                "\nfor Senior Commander press 3" +
                "\nfor Organization Leader press 4 ");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        agentName = new IranianAgent();
                        break;

                    case "2":
                        agentName = new SquadLeader();
                        break;
                    case "3":
                        agentName = new SeniorCommander();
                        break;
                    case "4":
                        agentName = new OrganizationLeader();
                        break;
                    default:
                        Console.WriteLine("not aloud choise");
                        break;
                }
                

            
            }
            while (choise != "1" && choise != "2" && choise != "3" && choise != "4");



        }
        public static void SetSensorType()
        {
            string choise2;
            do
            {
                Console.WriteLine("enter a sensor: Thermal/Audio/Pulse/Motion/Magnetic/Signal/Light.");
                choise2 = Console.ReadLine();
                switch (choise2)
                {
                    case "Thermal":
                        sensorType = new ThermalSensor();
                        break;
                    case "Audio":
                        sensorType = new AudioSensor();
                        break;
                    case "Pulse":
                        sensorType = new PulseSensor();
                        break;
                    case "Motion":
                        sensorType = new MotionSensor();
                        break;

                    case "Magnetic":
                        sensorType = new MagneticSensor();
                        break;
                    case "Signal":
                        sensorType = new SignalSensor();
                        break;

                    case "Light":
                        sensorType = new LightSensor();
                        break;

                    default:
                        Console.WriteLine("Unknown sensor type");
                        break;
                }

                //try
                //{

                //    InvestigationManager.AddSensor(agentName);

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message + "1");
                //}
            }
            while (!InvestigationManager.SensorTypes.Contains(choise2));
            
            
        }
        public static void PrintTheResult()
        {
            
                try
                {

                    Console.WriteLine($"you have rigt {agentName.GetMatchCount()}/{agentName.Weaknesses.Count}");
         
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "2");
                }
           



        }
        public static void PrintError()
        {
            Console.WriteLine("not aloud sensor");
        }



        public static void PrintThermalsActiv(string Weaknes)
        {
            Console.WriteLine($"thermal sensor rturnd thet  sensor '{Weaknes}' is in the Weaknes list");
        }

        public static void PrintCorect(string sensor)
        {
            Console.WriteLine($"corect!!! sensor {sensor} was tornd an");
        }
    }
}
