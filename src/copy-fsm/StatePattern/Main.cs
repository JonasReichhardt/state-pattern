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
        private Parser Context { get; set; }
        private List<DBTable> Tables { get; set; }
        private DBConnector dbCon;
        private string Command { get; set; }

        public Main()
        {
            InitializeComponent();
            dbCon = new DBConnector();
            Tables = new List<DBTable>();
            DBTable table = new DBTable("user");
            table.addAttribute("idUser");
            table.addAttribute("firstname");
            table.addAttribute("lastname");
            Tables.Add(table);
            Context = new Parser(Tables);
            dataGridView1.DataSource = dbCon.runCommand("Select * from dbo.user;");
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Command = "";
            label1.Text = "";
            button1.Enabled = false;
            ParseInput.Enabled = false;

            parseCommand();

            label1.Text += "SQL-Kommando: " + Command;
            ParseInput.Enabled = true;
            button1.Enabled = true;
            Context.reset();
        }

        private void parseCommand()
        {
            // tokenize input
            string[] tokens = Tokenizer.tokenize(ParseInput.Text);

            for(int i=0;i<tokens.Length; i++)
            {
                string commandPart = Context.Parse(tokens[i]);
                
                if (commandPart.Length < 0)
                {
                    label1.Text += "parse error";
                }
                else
                {
                    Command += " " + commandPart;
                }

                // set color
                if (Context.IsAcceptable)
                {
                    label1.ForeColor = Color.DarkGreen;
                }
                else
                {
                    label1.ForeColor = Color.DarkRed;
                }
            
                label1.Text += tokens[i] + " geprüft \n";
                
            }
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
