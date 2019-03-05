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
            bool isAttr = false;
            foreach (DBTable table in context.Tables)
            {
                if (table.Attributes.Contains(toParse))
                {
                    isAttr = true;
                }
            }
            if (isAttr)
            {
                //change to State2
                context.changeState(2);
                return toParse;
            }
            else if(toParse.Equals("FRM"))
            {
                context.changeState(3);
                return "FROM";
            }
            else
            {
                Console.WriteLine("parsing error");
                context.changeState(11);
                return "";
            }
        }
    }
}
