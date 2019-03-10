using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StatePattern
{
    class DBConnector
    {
        private string conString {get; set;}
        private SqlDataAdapter adapter;
        private readonly string DBNAME = "state-pattern";

        public DBConnector()
        {
            conString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=state-pattern;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public DataSet runCommand(string command)
        {
            adapter = new SqlDataAdapter(command, conString);
            DataSet dset = new DataSet();
            adapter.Fill(dset);
            return dset;
        }
        public List<DBTable> GetDBTables()
        {
            List<DBTable> tables = new List<DBTable>();
            DataSet dset = runCommand("SELECT name FROM[" + DBNAME + "].sys.Tables;");
            DataTable dtable = dset.Tables[0];

            foreach(DataRow row in dtable.Rows)
            {
                tables.Add(new DBTable(row[0].ToString()));
            }

            foreach(DBTable table in tables)
            {
                dset = runCommand("select COLUMN_NAME from information_schema.columns where table_name = '"+table.Name+"';");
                dtable = dset.Tables[0];
                foreach(DataRow row in dtable.Rows)
                {
                    table.addAttribute(row[0].ToString());
                }
            }
            return tables;
        }
    }
}
