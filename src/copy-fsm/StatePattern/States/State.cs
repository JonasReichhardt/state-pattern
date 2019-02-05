using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.States
{
    public abstract class State
    {
        abstract public void parse(Parser context, String toParse);
    }
}
