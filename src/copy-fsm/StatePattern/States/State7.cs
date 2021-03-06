﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State7 : State
    {
        public override string Parse(Parser context, string toParse)
        {
            int nextState = 9;
            string ret = "Attribut nicht vorhanden\noder nicht vom Typ 'String'";

            if (toParse.EndsWith(";"))
            {
                toParse = toParse.Trim(';');
                if (toParse.StartsWith("'") && toParse.EndsWith("'"))
                {
                    nextState = 8;
                    ret = toParse+";";
                }
            }
            context.ChangeState(nextState);
            return ret;
        }
    }
}
