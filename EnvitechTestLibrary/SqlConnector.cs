using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace EnvitechTestLibrary
{
    public class SqlConnector
    {
        public List<T> LoadData<T>(string sqlStatement)
        {
            using (var connection = new SqlConnection(GlobalConfig.CnnString("test")))
            {
                List<T> rows = connection.Query<T>(sqlStatement).ToList();
                return rows;
            }
        }   
    }
}
