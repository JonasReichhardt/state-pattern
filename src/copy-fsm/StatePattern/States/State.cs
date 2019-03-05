using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    internal abstract class State
    {
        abstract public string Parse(Parser context, string toParse);
    }
}
