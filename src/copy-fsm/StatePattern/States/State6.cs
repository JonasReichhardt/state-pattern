using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State6 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "e'=' nicht gefunden";
            if (toParse.Equals("="))
            {
                nextState = 7;
                ret = toParse;
            }
            context.ChangeState(nextState);
            return ret;
        }
    }
}
