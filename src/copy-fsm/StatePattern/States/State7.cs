using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State7 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "";

            if (toParse.StartsWith('"'.ToString()) && toParse.EndsWith('"'.ToString()))
            {
                nextState = 10;
                ret = toParse;
            }
            context.changeState(nextState);
            return ret;
        }
    }
}
