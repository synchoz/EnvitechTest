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
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDropDownDataFromDB();
        }

        private void LoadDropDownDataFromDB()
        {
            //load the dropdown DataFields
             dataField = _db.LoadData<DataModel>("SELECT Name FROM sys.columns WHERE OBJECT_ID = OBJECT_ID('dbo.DATA') AND name LIKE '%Value%'");
            valueFieldBox.DataSource = dataField;
            //load the dropdown Operators
            List<OperatorModel> operators = _db.LoadData<OperatorModel>("SELECT Name FROM dbo.OPERATOR");
            operatorBox.DataSource = operators;
            valueFieldBox.Text = "";
            operatorBox.Text = "";
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            bool isValidValuesOrNot = false;
            string operatorName;
            float valueNumber;
            string fieldValue;
            if (operatorBox.Text != "" || valueTextBox.Text != "" || valueFieldBox.Text != "") //needed to add check validation for number
            {
                isValidValuesOrNot = true;
            }
            operatorName = operatorBox.Text;
            valueNumber = float.Parse(valueTextBox.Text);
            fieldValue = valueFieldBox.Text;

            List<string> dataTable;
            List<List<string>> listsOfDataValues = new List<List<string>>();
            string dateTime1 = $"{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}";
            string dateTime2 = $"{dateTimePicker2.Value.Year}-{dateTimePicker2.Value.Month}-{dateTimePicker2.Value.Day}";
            string conditionalSqlStatment = "";
            if (isValidValuesOrNot)
            {
                conditionalSqlStatment = $"where {fieldValue} {operatorName} {valueNumber} and Date_Time BETWEEN '{dateTime1}' and '{dateTime2}'";
            }

            string sqlStatement = $"select Date_Time from dbo.DATA {conditionalSqlStatment}";
            dataTable = _db.LoadData<string>(sqlStatement);
            listsOfDataValues.Add(dataTable);

            foreach (var field in dataField) //make a status change plus adding filter for dates
            {
                dataTable = _db.LoadData<string>($"select {field} from dbo.DATA {conditionalSqlStatment}");
                listsOfDataValues.Add(dataTable);
            }

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
