using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State4 : State
    {
        public override string Parse(Parser context, string toParse, List<DBTable> tables)
        {
            switch (toParse)
            {
                case ("WHR"):
                    context.changeState(5);
                    return "WHERE";
                default:
                    Console.WriteLine("parsing error");
                    context.changeState(11);
                    return "";
            }
        }
    }
}
