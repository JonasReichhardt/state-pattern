﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    class State2 : State
    {
        public override void parse(Parser context, String toParse)
        {
            switch (toParse)
            {
                case ("-R"):
                    context.changeState(8);
                    break;
                default:
                    Console.WriteLine("parsing error");
                    context.changeState(11);
                    break;
            }
        }
    }
}
