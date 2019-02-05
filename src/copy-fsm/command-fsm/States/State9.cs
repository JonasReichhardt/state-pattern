using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State9 : State
    {
        public override void parse(Parser context, string toParse)
        {
            switch (toParse)
            {
                //TODO
                //Regex arg(DST)
                case ("DST"):
                    context.changeState(10);
                    break;
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
