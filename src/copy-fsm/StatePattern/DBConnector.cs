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
    }
}
