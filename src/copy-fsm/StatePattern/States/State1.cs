using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State1 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "eSyntaxfehler bei '"+toParse+"'";
            bool isAttr = false;
            foreach(DBTable table in context.Tables)
            {
                if (table.Attributes.Contains(toParse) || toParse.Equals("*"))
                {
                    isAttr = true;
                }
            }
            if (isAttr)
            {
                nextState = 2;
                context.addSelectedAttr(toParse);
                ret = toParse;
            }
            context.changeState(nextState);
            return ret;
        }
    }
}
