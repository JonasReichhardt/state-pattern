using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State4 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "eWHR nicht gefunden";
            if (toParse.Equals("WHR"))
            {
                nextState = 5;
                ret = "WHERE";
            }
            context.changeState(nextState);
            return ret;
        }
    }
}
