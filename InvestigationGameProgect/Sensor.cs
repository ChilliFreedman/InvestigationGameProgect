using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal abstract class Sensor
    {
        public string Type { get; protected set; }
        
        public abstract void Activate();
        
    }

    internal  class AudioSensor : Sensor
    {
        public AudioSensor() : base()
        {
            this.Type = "Audio";
        }
        //public static int counter = 1;
        public override void Activate()
        {
            
        //    Console.WriteLine($"Audio is activate {counter} times.");
        //    counter++;
           
        }
    }

    internal class ThermalSensor : Sensor
    {
        public ThermalSensor() : base()
        {
            this.Type = "Thermal";
        }

        public override void Activate()
        {
            Random rand = new Random();
            
            int indexWeaknes = rand.Next(0, InvestigationManager.Agent1.Weaknesses.Count);
            string Weaknes = InvestigationManager.Agent1.Weaknesses[indexWeaknes];
            ConsoleUI.PrintThermalsActiv(Weaknes);




        }
    }

    internal class PulseSensor : Sensor
    {
        public PulseSensor() : base()
        {
            this.Type = "Pulse";
        }

        public override void Activate()
        {

        }
    }

    internal class MotionSensor : Sensor
    {
        public MotionSensor() : base()
        {
            this.Type = "Motion";
        }

        public override void Activate()
        {

        }
    }


}
