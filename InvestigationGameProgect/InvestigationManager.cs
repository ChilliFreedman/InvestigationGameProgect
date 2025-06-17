using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal static class InvestigationManager
    {
       
        public static List<string> SensorTypes = new List<string> {"Thermal", "Audio", "Pulse", "Motion" };
        public static ThermalSensor SensorThermal = new ThermalSensor();
        public static AudioSensor SensorAudio = new AudioSensor();
        public static PulseSensor SensorPulse = new PulseSensor();
        public static MotionSensor SensorMotion = new MotionSensor();
        public static Dictionary<string, Sensor> DictSensors = new Dictionary<string, Sensor>
        {
            {"Thermal",SensorThermal },
            {"Audio",SensorAudio },
            {"Pulse",SensorPulse },
            {"Motion",SensorMotion }
        };
        public static IranianAgent Agent1 = new IranianAgent();

        public static void AddSensor(string sensorType)
        {
            if (SensorTypes.Contains(sensorType))
            {
                Agent1.AttachedSensors.Add(DictSensors[sensorType]);
                DictSensors[sensorType].Activate();

                //foreach (Sensor sensor in Agent1.AttachedSensors)
                //{
                //    sensor.Activate();
                //}


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
                ConsoleUI.PrintTheResult();
            }
            while (InvestigationManager.Agent1.GetMatchCount() != InvestigationManager.Agent1.Weaknesses.Count);
            
            
        }


    }
}
