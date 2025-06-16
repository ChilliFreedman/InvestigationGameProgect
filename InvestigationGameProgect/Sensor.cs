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
        public override void Activate()
        {
            
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

        }
    }


}
