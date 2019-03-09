﻿using StatePattern.States;
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
        public State current { get; internal set; }
        public DBTable selectedTable { get; internal set; }
        public List<string> selectedAttr { get; internal set; }
        public List<DBTable> Tables { get; private set; }
        public bool IsAcceptable { get; private set; }

        public Parser(List<DBTable> tables)
        {
            selectedAttr = new List<string>();
            IsAcceptable = false;
            Tables = tables;
            setStates();
            reset();
        }

        public string Parse(string input)
        {
            Console.WriteLine("old state: "+current.ToString());
            Console.WriteLine("input:" + input);
            return current.Parse(this, input);
        }

        public void changeState(int state)
        {
           current = states[state];
           if (current is EndState)
           {
                IsAcceptable = true;
           }
            Console.WriteLine("new state: " + current.ToString());
        }
        
        private void setStates()
        {
            Console.WriteLine("setting fsm states");
            states = new State[10];
            states[0] = new StartState();
            states[1] = new State1();
            states[2] = new State2();
            states[3] = new State3();
            states[4] = new State4();
            states[5] = new State5();
            states[6] = new State6();
            states[7] = new State7();
            states[8] = new EndState();
            states[9] = new ErrorState();
        }

        public void reset()
        {
            Console.WriteLine("reseting fsm state");
            current = states[0];
            IsAcceptable = false;
        }

        internal void addSelectedAttr(string attr)
        {
            selectedAttr.Add(attr);
        }
    }
}
