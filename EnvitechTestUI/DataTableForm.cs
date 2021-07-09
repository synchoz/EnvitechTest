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
            
            PopulateColumns(dataTable);
            this.tableDataGridView.DataSource = dataTable;
        }

        private void PopulateColumns(List<List<string>> dataTable)
        {
            
            int i = 0;
            foreach (var data in dataTable)
            {
                if(i == 0)
                {
                    tableDataGridView.Columns.Add("Time Stamp", "Time Stamp");
                }
                else
                {
                    this.tableDataGridView.Columns.Add("Value", $"Value{i}");
                }
                
                i++;
            }

           


        }
    }
}
