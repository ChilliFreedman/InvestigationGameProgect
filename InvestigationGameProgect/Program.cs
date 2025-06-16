using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGameProgect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InvestigationManager.RunTurn();
            //for (int i = 0; i < InvestigationManager.Agent1.Rank; i++)
            //{
            //    Console.WriteLine(InvestigationManager.Agent1.Weaknesses[i]);
            //}
        }
    }
}
