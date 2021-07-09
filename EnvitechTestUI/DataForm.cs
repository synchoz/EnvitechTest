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
        List<DataModel> dataField;
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
             dataField = _db.LoadData<DataModel, dynamic>("SELECT Name FROM sys.columns WHERE OBJECT_ID = OBJECT_ID('dbo.DATA') AND name LIKE '%Value%'", new { });
            valueFieldBox.DataSource = dataField;
            //load the dropdown Operators
            List<OperatorModel> operators = _db.LoadData<OperatorModel,dynamic>("SELECT Name FROM dbo.OPERATOR", new { });
            operatorBox.DataSource = operators;
            valueFieldBox.Text = "";
            operatorBox.Text = "";
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string operatorName = operatorBox.Text;
            float valueNumber = float.Parse(valueTextBox.Text);
            string fieldValue = valueFieldBox.Text;
            //List<string> list = _db.LoadData("SELECT count(*) FROM information_schema.columns WHERE table_name = 'DATA'", new { });

            //DataTable dataTable = _db.LoadData("select * from dbo.DATA");//loading all data to table needs the status changed
            //StringBuilder sb = new StringBuilder($"select * from dbo.DATA where Value4 {operatorName} 9");
            
            List<string> dataTable;
            List<List<string>> listsOfDataValues = new List<List<string>>();
            string dateTime1 = $"{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}";
            string dateTime2 = $"{dateTimePicker2.Value.Year}-{dateTimePicker2.Value.Month}-{dateTimePicker2.Value.Day}";
            //dateTimePicker1.Value
            //dateTimePicker2.Value
            string sqlStatement = $"select Date_Time from dbo.DATA where {fieldValue} {operatorName} {valueNumber} and Date_Time BETWEEN '{dateTime1}' and '{dateTime2}'";
            dataTable = _db.LoadData<string, dynamic>(sqlStatement, new { });
            listsOfDataValues.Add(dataTable);
            foreach (var field in dataField) //make a status change plus adding filter for dates
            {
                dataTable = _db.LoadData<string, dynamic>($"select {field} from dbo.DATA where {fieldValue} {operatorName} {valueNumber}", new { });
                listsOfDataValues.Add(dataTable);
            }

            //DataTableForm dataTableForm = new DataTableForm(dataTable);
            DataTableForm dataTableForm = new DataTableForm(listsOfDataValues);
            dataTableForm.ShowDialog();
        }

        private void clearFormButton_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            valueFieldBox.Text = "";
            operatorBox.Text = "";
            valueTextBox.Text = "";
        }
    }
}
