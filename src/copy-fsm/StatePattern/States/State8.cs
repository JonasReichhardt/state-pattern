using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State8 : State
    {
        public override void parse(Parser context, string toParse)
        {
            switch (toParse)
            {
                //TODO
                //Regex arg(SRC)
                case ("SRC"):
                    context.changeState(9);
                    break;
                default:
                    Console.WriteLine("parsing error");
                    context.changeState(11);
                    break;
            }
        }
    }
}
