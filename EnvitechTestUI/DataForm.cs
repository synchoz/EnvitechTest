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
            LoadDropDownDataFromDB();
        }

        private void LoadDropDownDataFromDB()
        {
            //load the dropdown DataFields
            List<DataModel> dataField = _db.LoadData<DataModel, dynamic>("SELECT Name FROM sys.columns WHERE OBJECT_ID = OBJECT_ID('dbo.DATA') AND name LIKE '%Value%'", new { });
            valueFieldBox.DataSource = dataField;
            //load the dropdown Operators
            List<OperatorModel> operators = _db.LoadData<OperatorModel,dynamic>("SELECT Name FROM dbo.OPERATOR", new { });
            operatorBox.DataSource = operators;
        }

        private void showButton_Click(object sender, EventArgs e)
        {

            //List<string> list = _db.LoadData("SELECT count(*) FROM information_schema.columns WHERE table_name = 'DATA'", new { });

            DataTable dataTable = _db.LoadData("select * from dbo.DATA");
            DataTableForm dataTableForm = new DataTableForm(dataTable);
            dataTableForm.ShowDialog();
        }
    }
}
