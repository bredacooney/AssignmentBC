using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace CarsDataBase
{
    public partial class frmSearch : Form
    {
        SQLiteconnection databaseConnection = new SQLiteconnection("data source = C:\data\hire.db");
        public frmSearch()
        {
            InitializeComponent();
        }
        private void frmSearch_Load(object sender, EventArgs e)
        {
            // populate cbofield with field names; make, enginesize, rentalperday, available
            cboField.Items.Add("Vehicle Registration Number");
            cboField.Items.Add("Make");
            cboField.Items.Add(("Engine Size"));
            cboField.Items.Add(("Rental Per Day"));
            cboField.Items.Add(("Available"));

            // = OPERATOR ALWAYS STAYS.  OTHER OPERATORS IN FUNCTIONS THAT DETERMINES OF THEY DISPLAY
            cboOperator.Items.Add("=");

            // searchData();  // <-- UNCOMMENT TO SEARCH DATA RESULTS WHEN FORM LOADS

        }
        private void searchData()
        {//SETTING UP SEARCH PARAMATERS
            string findData = @" SELECT  * FROM tblCar";
            if (cboField.Text != "" && cboOperator.Text != "" && valueTextbox.Text != "")
            {

                // Available
                if (cboField.Text == "Available")
                {
                    if (valueTextbox.Text == "yes")
                    {


                        cboOperator.Text == "=";
                        findData = $@"SELECT * FROM tblcar WHERE Available != 0";
                        // search
                    }
                    else if (valueTextbox.Text == "No")
                    {
                        cboOperator.Text = "=";
                        findData = $@"SELECT * FROM tblcar WHERE Available = 0";
                        // search
                    }
                    else if (valueTextbox.Text != "Yes" || valueTextbox.Text != "No")
                    {
                        MessageBox.Show("Please Enter 'Yes' or 'No'. Ensure Capitals are present.");
                        valueTextbox.Text = "";
                        return;
                    }

                }//Engine Size
                if (cboField.Text == "Engine Size")
                {
                    findData = $@"SELECT * FROM tblcar WHERE EngineSize {cboOperator.Text} '{valueTextboxl.Text.TrimEnd('L')}L'";
                }

                //Rental Per Day
                if (cboField.Text == "Rental Per Day")
                {
                    findData = $@"SELECT * FROM tblcar WHERE RentalPerDay {cboOperator.Text} '{valueTextbox.Text}'";
                }

                //Make
                if (cboField.Text == "Make")
                {
                    cboOperator.Text = "=";
                    findData = $@"SELECT * FROM tblcar WHERE Make = '{valueTextbox.Test}'";
                }

                // Vehicle Registration Number
                if (cboField.Text == "Vehicle Registration Number")
                {
                    cboOperator.Text = "=";
                    findData = $@"SELECT * FROM tblcar WHERE VechicleRegNo = '{valueTextbox.Test}'";
                }



                // OPENING DB AND SEARCHING PARAMATERS
                SQLiteConnection connect = new SQLiteConnection(@"data source = C:\data\hire.db");
                connect.Open();
                string query = findData;
                SQLiteCommand cmd = new SQLiteCommand(query, connect);
                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(cmd);
                adapter2.Fill(dt);
                frmDataGrid.DataSource = dt;
                connect.Close();


            }
        }
            
           
            

            

            private void frmDataGrid_CellContentClick(object sender, EventArgs e)
            {

            }

            //private void cboOperator_SelectedIndexChanged(object sender, DataGridViewCellEventArgs e)
           // {
           //
            //}

            private void btnRun_Click(object sender, EventArgs e)
            {
                searchData();
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                Close();
            }
        // not using displayDb
            public void displayDb()
            {

            }

            private void cboField_SelectedIndexChanged(object sender, EventArgs e)
            {
                removeOrAddOperators();

            }

            private void removeOrAddOperators()
            { // ADDS OR REMOVES OPERATOR FROM THE FORM DEPENDING ON FIELD SELECTION
                if (cboField.Text == "Available"  || cboField.Text  == "Vehicle Registration Number"  | cboField.Text == "Make") 
                {
                cboOperator.Items.Remove("<");
                cboOperator.Items.Remove(">");
                cboOperator.Items.Remove("<=");
                cboOperator.Items.Remove(">=");
            }
            if ((cboField.Text == "Engine Size" || cboField.Text == "Rental Per Day") && !cboField.Items.Contains("<") && !cboOperator.Items.Contains(">") && !cboOperator.Items.Contains("<=") && !cboOperator.Items.Contains(">="))
            {
                cboOperator.Items.Add("<");
                cboOperator.Items.Add(">");
                cboOperator.Items.Add("<=");
                cboOperator.Items.Add(">=");
            }

        }

        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}





