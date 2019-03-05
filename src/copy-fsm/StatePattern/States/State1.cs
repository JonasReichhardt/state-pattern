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
            bool isAttr = false;
            foreach(DBTable table in context.Tables)
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
            else
            {
                Console.WriteLine("parsing error");
                context.changeState(11);
                return "";
            }
        }
    }
}
