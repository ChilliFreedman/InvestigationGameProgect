using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal static class ConsoleUI
    {
        public static string sensorType;
        public static void SetSensorType()
        {
            
            do
            {
                Console.WriteLine("enter a sensor: Thermal/Audio/Pulse/Motion/Magnetic/Signal/Light.");
                sensorType = Console.ReadLine();

                try
                {

                    InvestigationManager.AddSensor();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "1");
                }
            }
            while (!InvestigationManager.SensorTypes.Contains(sensorType));
            
            
        }
        public static void PrintTheResult()
        {
            
                try
                {

                    Console.WriteLine($"you have rigt {InvestigationManager.Agent1.GetMatchCount()}/{InvestigationManager.Agent1.Weaknesses.Count}");
         
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
