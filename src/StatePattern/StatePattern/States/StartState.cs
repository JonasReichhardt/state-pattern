using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class StartState : State
    {
        public override void parse(Parser context, String toParse)
        {
            switch(toParse)
            {
                case ("-R"):
                    context.changeState(1);
                    break;
                case ("-H"):
                    context.changeState(2);
                    break;
                case ("-L"):
                    context.changeState(3);
                    break;
                case ("-P"):
                    context.changeState(4);
                    break;
                //TODO
                //parse arg(SRC)
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
