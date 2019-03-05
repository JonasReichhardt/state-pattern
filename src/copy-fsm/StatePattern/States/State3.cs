using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State3 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            bool isTable = false;
            bool isLast = false;
            if (toParse.EndsWith(";"))
            {
                isLast = true;
            }
            foreach(DBTable table in context.Tables)
            {
                if (table.Name.Equals(toParse))
                {
                    isTable = true;
                    context.selected = table;
                    if()
                }
            }
            if (isTable)
            {
                if (isLast)
                {
                    context.changeState(10);
                }
                else
                {
                    context.changeState(4);
                }
                return toParse;
            }
            else
            {
                context.changeState(11);
                Console.WriteLine("parse error");
                return "";
            }
        }
    }
}
