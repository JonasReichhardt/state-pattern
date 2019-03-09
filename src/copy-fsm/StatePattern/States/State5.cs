using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State5 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "";
            bool isAttr = false;

            foreach (string attr in context.selectedTable.Attributes)
            {
                if (attr.Equals(toParse))
                {
                    isAttr = true;
                }
            }

            if (isAttr)
            {
                nextState = 6;
                ret = toParse;
            }
            context.changeState(nextState);
            return ret;
        }
    }
}
