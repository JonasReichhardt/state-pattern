using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatePattern
{
    public partial class Main : Form
    {
        private int Index { get; set; }
        private Parser Context { get; set; }
        private List<DBTable> Tables { get; set; }
        private string Command { get; set; }

        public Main()
        {
            InitializeComponent();
            Tables = new List<DBTable>();
            DBTable table = new DBTable("user");
            table.addAttribute("idUser");
            table.addAttribute("firstname");
            table.addAttribute("lastname");
            Tables.Add(table);
            Index = 0;
            Context = new Parser(Tables);
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // tokenize input
            string[] tokens = Tokenizer.tokenize(ParseInput.Text);
            Console.WriteLine(tokens);

            if (Index<tokens.Length){
                ParseInput.Enabled = false;
                string commandPart = Context.Parse(tokens[Index]);
                if (commandPart.Length < 0)
                {
                    label1.Text += "parse error";
                }
                else
                {
                    Command += " " + commandPart;
                }
                Index += 1;
                if (Context.IsAcceptable)
                {
                    label1.ForeColor = Color.DarkGreen;
                }
                else
                {
                    label1.ForeColor = Color.DarkRed;
                }
                label1.Text += "parsed " + tokens[Index] + "\n";
            }

            ParseInput.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ParseInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
