using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager
{
    public class Connection
    {

        public static SqlConnection InitServerConnection()
        {

            string connectionString = "Server=localhost; Trusted_Connection=True; Encrypt=false;";
            return new SqlConnection(connectionString);
        }
        public static SqlConnection InitMyTaskManagerConnection()
        {
            string connectionString = "Server=localhost; Database=MyTaskManager; Trusted_Connection=True; Encrypt=false;";
            return new SqlConnection(connectionString);
        }



    }
}
