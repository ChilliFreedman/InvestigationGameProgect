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
            ConsoleUI.setagent();
            InvestigationManager.RunTurn();
          
        }
    }
}
