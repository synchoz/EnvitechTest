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
        public List<T> LoadData<T,U>(string sqlStatement,U parameters)//change for T
        {
            using (var connection = new SqlConnection(GlobalConfig.CnnString("test")))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public DataTable LoadData<U>(string sqlStatement,U parameters)
        {
            using (var connection = new SqlConnection(GlobalConfig.CnnString("test")))
            using (var adapter = new SqlDataAdapter(sqlStatement, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable LoadData(string sqlStatement)
        {
            using (var connection = new SqlConnection(GlobalConfig.CnnString("test")))
            using (var adapter = new SqlDataAdapter(sqlStatement, connection))
            {
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        
    }
}
