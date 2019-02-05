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
    public class Parser
    {
        private State[] states;
        private State current;
        private string[][] transitions;
        private bool isAcceptable;
        private string msg;

        public Parser()
        {
            setState();
            reset();
        }

        public string parse(String toParse)
        {
            String[] parts = toParse.Split(' ');
            for(int i = 1; i < parts.Length; i++)
            {
                msg += "parsing: "+parts[i]+"\n";
                current.parse(this, parts[i]);
            }

            if(current is EndState)
            {
                isAcceptable = true;
            }
            else
            {
                isAcceptable = false;
            }

            msg += "Command accepted? " + isAcceptable;
            Task.Delay(100).ContinueWith(t => reset());
            return msg;
        }

        public void changeState(int state)
        {
           current = states[state];
           msg+= "Current state: " + current.GetType()+"\n";
        }
        
        private void setState()
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
            transitions = new string[][]
            {
                new string[] { "0","-R","1" },
                new string[] { "0","SRC","9" },
                new string[] { "0","-H","2" },
                new string[] { "0","-L","3" },
                new string[] { "0","-P","4" },
                new string[] { "1","-H","5" },
                new string[] { "1","-L","6" },
                new string[] { "1","-P","7" },
                new string[] { "2","-R","8" },
                new string[] { "3","-R","8" },
                new string[] { "4","-R","8" },
                new string[] { "8","SRC","9" },
                new string[] { "5","SRC","9" },
                new string[] { "6","SRC","9" },
                new string[] { "7","-R","9"},
                new string[] { "9","SRC","9"},
                new string[] { "9","DST","10"},
            };
        }

        private void reset()
        {
            Console.WriteLine("reseting fsm state");
            current = states[0];
            msg = "";
        }
    }
}
