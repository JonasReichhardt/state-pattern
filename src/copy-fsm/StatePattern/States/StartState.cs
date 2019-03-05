using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class StartState : State
    {
        public override string Parse(Parser context, string toParse)
        {
            switch(toParse)
            {
                case ("SLCT"):
                    context.changeState(1);
                    return "SELECT";
                default:
                    Console.WriteLine("parsing error");
                    context.changeState(11);
                    return "";
            }
        }
    }
}
