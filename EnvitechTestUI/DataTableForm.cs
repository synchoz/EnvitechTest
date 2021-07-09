using EnvitechTestLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnvitechTestUI
{
    public partial class DataTableForm : Form
    {
        DataTable table = new DataTable();
        public DataTableForm(List<List<string>> dataTable)
        {

           
            InitializeComponent();
            table.Columns.Add();
            //tableDataGridView.Columns.Add("Time Stamp", "Time Stamp");
            PopulateColumns(dataTable);
            this.tableDataGridView.DataSource = table;
        }

        private void PopulateColumns(List<List<string>> dataTable)
        {
            
            int i = 1;
            foreach (var data in dataTable)
            {
/*                DataRow newRow = table.NewRow();
                newRow["Time Stamp"] = 1;
                newRow["Name"] = "John";*/
                table.Rows.Add(newRow);
                //this.tableDataGridView.Columns.Add("Value", $"Value{i}");
                

                foreach (var row in data)
                {
                    
                    table.Rows.Add(row);
                    table.Rows.InsertAt
                }
                table.Columns.Add();
                i++;
            }

            
        }
    }
}
