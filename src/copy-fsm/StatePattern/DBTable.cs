using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    internal class DBTable
    {
        public DBTable(string name)
        {
            Name = name;
            Attributes = new List<string>();
        }

        public string Name{ get; set; }
        public List<string> Attributes { get; set; }

        public void addAttribute(string attr)
        {
            if (attr.Length > 0)
            {
                Attributes.Add(attr);
            }
        }
    }
}
