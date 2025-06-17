using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal static class InvestigationManager
    {
       
        public static List<string> SensorTypes = new List<string> {"Thermal", "Audio", "Pulse", "Motion", "Magnetic","Signal", "Light" };
        public static ThermalSensor SensorThermal = new ThermalSensor();
        public static AudioSensor SensorAudio = new AudioSensor();
        public static PulseSensor SensorPulse = new PulseSensor();
        public static MotionSensor SensorMotion = new MotionSensor();
        public static MagneticSensor SensorMagnetic = new MagneticSensor();
        public static SignalSensor SensorSignal = new SignalSensor();
        public static LightSensor SensorLight = new LightSensor();
        public static Dictionary<string, Sensor> DictSensors = new Dictionary<string, Sensor>
        {
            {"Thermal",SensorThermal },
            {"Audio",SensorAudio },
            {"Pulse",SensorPulse },
            {"Motion",SensorMotion },
            {"Magnetic",SensorMagnetic },
            {"Signal",SensorSignal },
            {"Light",SensorLight }
        };
        public static IranianAgent Agent1 = new IranianAgent();

        public static void AddSensor()
        {
            if (SensorTypes.Contains(ConsoleUI.sensorType))
            {
                Agent1.AttachedSensors.Add(DictSensors[ConsoleUI.sensorType]);
                

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

                if (Agent1.Weaknesses.Contains(ConsoleUI.sensorType))
                {
                    DictSensors[ConsoleUI.sensorType].Activate();
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
            }
            while (InvestigationManager.Agent1.GetMatchCount() != InvestigationManager.Agent1.Weaknesses.Count);
            
            
        }


    }
}
