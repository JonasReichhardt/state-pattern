using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class EndState : State
    {
        public override string Parse(Parser context, string toParse)
        {
            return "end";
        }
    }
}
