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
            int nextState = 9;
            string ret = "eTabelle nicht gefunden oder\nTabelle hat angegebenen Attribute nicht";
            bool isTable = false;
            bool isLast = false;
            bool hasAttr = true;

            if (toParse.EndsWith(";"))
            {
                isLast = true;
                toParse = toParse.Trim(';');
            }

            foreach(DBTable table in context.Tables)
            {
                if (table.Name.Equals(toParse))
                {
                    context.selectedTable = table;
                    isTable = true;
                    foreach(string attr in context.selectedAttr)
                    {
                        if (!table.Attributes.Contains(attr))
                        {
                            hasAttr = false;
                        }
                    }
                }
            }

            if (isTable)
            {
                if (!hasAttr)
                {
                    nextState = 9;
                }
                if (isLast)
                {
                    nextState = 8;
                    ret = toParse + ";";
                }
                else
                {
                    nextState = 4;
                    ret = toParse;
                }
            }
            context.changeState(nextState);
            return ret;
        }
    }
}
