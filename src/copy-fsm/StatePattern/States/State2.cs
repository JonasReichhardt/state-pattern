using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State2 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "eAttribut oder FRM nicht gefunden";
            bool isAttr = false;
            foreach (DBTable table in context.Tables)
            {
                if (table.Attributes.Contains(toParse))
                {
                    isAttr = true;
                }
            }
            if (isAttr && !context.selectedAttr.Contains("*"))
            {
                context.addSelectedAttr(toParse);
                nextState = 2;
                ret = ","+toParse;
            }
            else if(toParse.Equals("FRM"))
            {
                nextState = 3;
                ret = "FROM";
            }
            context.changeState(nextState);
            return ret;
        }
    }
}
