using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    internal class Tokenizer
    {
        public static string[] tokenize(string input)
        {
            string[] tokens = input.Split(' ');
            List<string> ret = new List<string>();

            foreach(string token in tokens)
            {
                if (!token.Contains(","))
                {
                    ret.Add(token);
                }
                else
                {
                    string[] splitted = token.Split(',');
                    foreach (string split in splitted)
                    {
                        ret.Add(split);
                    }
                }
            }

            Console.WriteLine("tokens:"+ ret);
            return ret.ToArray<string>();
        }
    }
}
