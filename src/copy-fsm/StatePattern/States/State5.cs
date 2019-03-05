using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State5 : State
    {
        public override string Parse(Parser context, string toParse, List<DBTable> tables)
        {
            bool isAttr = false;
            foreach (DBTable table in tables)
            {
                if (table.Attributes.Contains(toParse))
                {
                    isAttr = true;
                }
            }
            if (isAttr)
            {
                context.changeState(6);
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
