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
        
        public int PublicCounter { get; set; }
        public int PrivatCounter { get; set; } 
        public abstract void Activate();
        
    }

    internal  class AudioSensor : Sensor
    {
        public AudioSensor() : base()
        {
            this.Type = "Audio";
        }
        
        public override void Activate()
        {
            ConsoleUI.PrintCorect(Type);
        
           
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
            ConsoleUI.PrintCorect(Type);
            //if (this.PrivatCounter == 0)
            //{
                Random rand = new Random();

                int indexWeaknes = rand.Next(0, ConsoleUI.agentName.Weaknesses.Count);
                string Weaknes = ConsoleUI.agentName.Weaknesses[indexWeaknes];
                ConsoleUI.PrintThermalsActiv(Weaknes);
                //this.PrivatCounter++;
            //}
            




        }
    }

    internal class PulseSensor : Sensor
    {

        public PulseSensor() : base()
        {
            this.Type = "Pulse";
            this.PrivatCounter = 0;
        }
        
        public override void Activate()
        {
            //Console.WriteLine($"Pulse is activate {Counter} times.");
            if (this.PrivatCounter == 0)
            {
                this.PrivatCounter = 1;
            }
            
            ConsoleUI.PrintCorect(Type);
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
            ConsoleUI.PrintCorect(Type);
        }
    }

    internal class MagneticSensor : Sensor
    {
        public MagneticSensor() : base()
        {
            this.Type = "Magnetic";
        }

        public override void Activate()
        {
            ConsoleUI.PrintCorect(Type);
        }
    }

    internal class SignalSensor : Sensor
    {
        public SignalSensor() : base()
        {
            this.Type = "Signal";
        }

        public override void Activate()
        {
            ConsoleUI.PrintCorect(Type);
        }
    }

    internal class LightSensor : Sensor
    {
        public LightSensor() : base()
        {
            this.Type = "Light";
        }

        public override void Activate()
        {
            ConsoleUI.PrintCorect(Type);
        }
    }


    
}
