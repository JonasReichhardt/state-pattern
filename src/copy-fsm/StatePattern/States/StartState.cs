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
            int nextState = 9;
            string ret = "eKein SLCT gefunden";

            if (toParse.Equals("SLCT"))
            {
                nextState = 1;
                ret = "SELECT";
            }

            context.changeState(nextState);
            return ret;
        }
    }
}
