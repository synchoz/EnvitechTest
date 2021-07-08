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
        public DataTableForm(DataTable dataTable)
        {
            InitializeComponent();
            this.tableDataGridView.DataSource = dataTable;
        }
    }
}
