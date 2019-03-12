using System;

using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatePattern
{
    public partial class Main : Form
    {
        private Parser Parser { get; set; }
        private DBConnector dbCon;
        private string Command { get; set; }

        public Main()
        {
            InitializeComponent();
            dbCon = new DBConnector();

            // get table structure from Database
            // create new parser with db structure
            try {
                Parser = new Parser(dbCon.GetDBTables());
            }
            catch (SqlException ex)
            {
                label1.Text = "Datenbankstrukur konnte\n nicht ermittelt werden\n Überprüfen Sie die Verbindung";
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeUIAccessibility();
            ResetIOFields();
            ParseCommand();


            // data bind queried data
            GetData();

            ChangeUIAccessibility();

            // reset fsm
            Parser.Reset();
        }

        private void ParseCommand()
        {
            // tokenize input
            string[] tokens = Tokenizer.tokenize(ParseInput.Text);

            for(int i=0;i<tokens.Length; i++)
            {
                // delegate parsing call to current state
                string commandPart = Parser.Parse(tokens[i]);

                Command += " " + commandPart;

                // set color regarding parser state
                if (Parser.IsAcceptable)
                {
                    label1.ForeColor = Color.DarkGreen;
                }
                else
                {
                    label1.ForeColor = Color.DarkRed;
                }

                if (commandPart.StartsWith("e"))
                {
                    label1.Text += "Fehler: "+ commandPart.Trim('e') + "\n";
                }
                else
                {
                    label1.Text += tokens[i] + " geprüft \n";
                }
            }
        }

        private void ChangeUIAccessibility()
        {
            button1.Enabled = !button1.Enabled;
            ParseInput.Enabled = !ParseInput.Enabled;
        }

        private void ResetIOFields()
        {
            Command = "";
            label1.Text = "";
        }

        private void GetData()
        {
            if (Parser.IsAcceptable)
            {
                try
                {
                    label1.Text += "Ausgeführtes SQL-Kommando\n" + Command;
                    DataSet dset = dbCon.runCommand(Command);
                    dataGridView1.DataSource = dset.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    label1.Text += "Ein oder mehrere Fehler gefunden";
                }
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }
    }
}
