using StatePattern.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatePattern
{
    internal class Parser
    {
        private State[] states;
        private State current;
        public DBTable selected { get; internal set; }
        public List<DBTable> Tables { get; private set; }
        public bool IsAcceptable { get; private set; }

        public Parser(List<DBTable> tables)
        {
            IsAcceptable = false;
            Tables = tables;
            setStates();
            reset();
        }

        public string Parse(string input)
        {
            return current.Parse(this, input);
        }

        public void changeState(int state)
        {
           current = states[state];
           if (current is EndState)
           {
                IsAcceptable = true;
           }
        }
        
        private void setStates()
        {
            Console.WriteLine("setting fsm states");
            states = new State[12];
            states[0] = new StartState();
            states[1] = new State1();
            states[2] = new State2();
            states[3] = new State3();
            states[4] = new State4();
            states[5] = new State5();
            states[6] = new State6();
            states[7] = new State7();
            states[8] = new State8();
            states[9] = new State9();
            states[10] = new EndState();
            states[11] = new ErrorState();
        }

        private void reset()
        {
            Console.WriteLine("reseting fsm state");
            current = states[0];
        }
    }
}
