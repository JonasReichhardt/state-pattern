using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State1 : State
    {
        public override void parse(Parser context, string toParse)
        {
            switch (toParse)
            {
                case ("-H"):
                    context.changeState(5);
                    break;
                case ("-L"):
                    context.changeState(6);
                    break;
                case ("-P"):
                    context.changeState(7);
                    break;
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
