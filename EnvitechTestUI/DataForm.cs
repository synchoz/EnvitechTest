using EnvitechTestLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvitechTestUI
{
    public partial class DataForm : Form
    {
        SqlConnector _db = new SqlConnector();
        public DataForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {//List<List<T>>

            List<string> list = _db.LoadData("SELECT count(*) FROM information_schema.columns WHERE table_name = 'DATA'", new { });

            DataTable dataTable = _db.LoadData("select * from dbo.DATA");
            DataTableForm dataTableForm = new DataTableForm(dataTable);
            dataTableForm.ShowDialog();
        }
    }
}
