using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal  class IranianAgent
    {
        public List<string> Weaknesses { get; set; }
        public List<Sensor> AttachedSensors { get; set; }

        public int Rank { get;protected set; }
        public virtual int Attack()
        {
            return 0;
        }
       
        public  IranianAgent(int rank = 2)
        {
           
            this.Rank = rank;
            this.AttachedSensors = new List<Sensor>();
            this.Weaknesses = FunRendumToWeaknesses();
        }
        public List<string> FunRendumToWeaknesses()
        {
            List<string> weaknespush = new List<string>();
            //weaknespush.Add(new PulseSensor().Type);
            Random rand = new Random();
            for (int i = 0; i < Rank; i++)
            {
                int indextype = rand.Next(0, InvestigationManager.SensorTypes.Count);
                string type = InvestigationManager.SensorTypes[indextype];
                weaknespush.Add(type);
            }
            return weaknespush;

        }
        public int GetMatchCount()
        {
            int counter = 0;
            List<string> matches = new List<string>(Weaknesses);
          
            for (int i = 0;i <  AttachedSensors.Count; i++)
            {
                for (int j = 0; j < matches.Count; j++)
                {
                    if ( AttachedSensors[i].Type == matches[j])
                    {
                        counter++;
                        matches.RemoveAt(j);
                        break;
                    }
                }
            }
            return counter;
        }
        
    }
    internal class SquadLeader : IranianAgent
    {
        //public int Attack {  get; set; }
        public SquadLeader() : base(4)
        {
            //this.Attack = 1;
        }
        public override int Attack()
        {
            return 1;
        }



    }
    internal class SeniorCommander : IranianAgent
    {
        //public int Attack { get; set; }
        public SeniorCommander() : base(6)
        {
            //this.Attack = 2;
        }
        public override int Attack()
        {
            return 2;
        }
    }
    internal class OrganizationLeader : IranianAgent
    {
        //public int Attack { get; set; }
        public OrganizationLeader() : base(8)
        {
            //this.Attack = 1;
        }
        public override int Attack()
        {
            return 1;
        }
    }

}
