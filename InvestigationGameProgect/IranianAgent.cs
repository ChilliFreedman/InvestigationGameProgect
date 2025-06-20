﻿using System;
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
          
            List<string> matches = new List<string>(Weaknesses);
            foreach (Sensor sensor in AttachedSensors)
            {
                matches.Remove(sensor.Type);
            }
            return Weaknesses.Count - matches.Count;
            
        }
        
    }
    internal class SquadLeader : IranianAgent
    {

        public SquadLeader() : base(4)
        {
        }
        public override int Attack()
        {
            return 1;
        }



    }
    internal class SeniorCommander : IranianAgent
    {
        public SeniorCommander() : base(6)
        {
        }
        public override int Attack()
        {
            return 2;
        }
    }
    internal class OrganizationLeader : IranianAgent
    {
        public OrganizationLeader() : base(8)
        {
        }
        public override int Attack()
        {
            return 1;
        }
    }

}
