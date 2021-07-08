using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EnvitechTestLibrary
{
    public class SqlConnector
    {
        public List<string> CreateTable()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("test")))
            {

            }
        }
        
/*        using(SqlConnection connection = new SqlConnection())
        {

        }*/

    }
}
