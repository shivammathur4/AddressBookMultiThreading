using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookMultiThreading
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {
            string connectiongString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectiongString);
            return connection;
        }
    }
}
