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



namespace CarsDataBase
{
    public partial class frmCars : Form
    {
        SQLiteConnection dataBaseConnection = new SQLiteConnection(@"data source = c:\data\hire.db"); // connects to the Database
        public frmCars()
        {
            InitializeComponent();
        }

        // line 25 to 29 was there automatically when I opened it up   -  do I delete these of leave them
        //private void frmCars_Load(object sender, EventArgs e)  // this was here when i started   

         // this was here    

         //this was here   















        private void btnFirst_Click(object sender, EventArgs e)
        {
            recordCounter("first"); //go to first position
            getData(); //get data of current position
        }
        private void btnPrevious_Click(object sender, EventArgs e)

        {
            recordCounter("previous"); //go to previous position
            getData();//get data of current position
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            recordCounter("next"); //go to next position
            getData(); //get data of current position
        }
        private void frmLast(object sender, EventArgs e)
        {
            recordCounter("last"); //go to last position
            getData(); //get data of current position
        }


        int recordControlNo = 1; //used in number display at bottom of for
        int totalRecords; //Where we store the total ammount of records
        public void recTotal()
        {//FINDS THE TOTAL AMOUNT OF RECORDS WHEN CALLED
            string findTotal = @"SELECT COUNT(*) FROM tblCar"; //SQL Query to find the count of all records

            databaseConnection.Open(); //open the connection to the database
            var command = databaseConnection.CreateCommand(); //creating a command
            command.CommandText = findTotal; //turning the sql query into the command
            using (var reader = command.ExecuteReader()) // using reader to execute the command
            {
                while (reader.Read())
                {
                    var total = reader.GetInt32(0);
                    totalRecords = total; //returns the query and stores the number as totalRecords
                }
            }
            recordCount.Text = $"{recordControlNo} of {totalRecords}"; //Heres how we show our record count at the bottom of our form
            databaseConnection.Close(); //closing the database connection
        }


        public void recordCounter(string frmBtn)
        {//UPDATES RECORD BOX DEPENDING ON BUTTONS PRESSED && ALSO USED AS A REFERENCE FOR CYCLING THROUGH -> getData()
            if (frmBtn == "next")
            {//Determines behaviour of next button
                if (recordControlNo < totalRecords)
                { recordControlNo += 1; }
            }

            if (frmBtn == "previous")
            {//Determines behaviour of previous button
                if (recordControlNo > 1)
                { recordControlNo -= 1; }
            }

            //Determines behaviour of first button
            if (frmBtn == "first")
            { recordControlNo = 1; }

            //Determines behaviour of last button
            if (frmBtn == "last")
            { recordControlNo = totalRecords; }

            recordCount.Text = $"{recordControlNo} of {totalRecords}"; //Updates the record counter at the bottom of the form
        }


        private void recordCount_TextChanged_1(object sender, EventArgs e)
        {
            recordCount.Text = $"{recordControlNo} of {totalRecords}";
        }


        private void frmCars_Load(object sender, EventArgs e)
        {//This is what happens when to form loads
            try
            {//It will try to load the total amount of records, and the data for the first record
                recTotal();
                getData();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't load database. Check database connection."); //if it fails to do the above we will display a message to the screen
            }

            btnUpdate.Enabled = false; // Update button unusable until use conditions are met
            btnCancel.Enabled = false; // Cancel button unusable until use conditions are met
            updatePanel.Visible = false;// Panel button unusable until use conditions are met. This Panel simply has text on it notifying if we are editing the record


            if (btnUpdate.Enabled == true)
            {
                updatePanel.Visible = true; // if Update button is on then we can see the text telling us we are editing the record
            }
        }

        Details details = new Details();
        public void getData()
        {
            int rowPosition = recordControlNo - 1;

            try
            {//RETURNS DATA BASED ON SELECTED RECORD.
                databaseConnection.Open(); //open connection
                string getDB = $@"SELECT * FROM (SELECT * from tblCar LIMIT 1 OFFSET {rowPosition})"; //SQL query to get data from database
                SQLiteCommand cmd = new SQLiteCommand(getDB, databaseConnection); //making getDB into a command
                DataTable dt = new DataTable(); //declaring dt as a new datatable
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd); // adapter for collecting data from the database
                adapter.Fill(dt); //filling dt with data from adapter

                frmDataGrid.DataSource = dt; //filling datagrid with data
                databaseConnection.Close(); //closing connection to database

                //Making text fields in form equal to specific data search in datatable
                frmVehicleReg.Text = Convert.ToString(dt.Rows[0].ItemArray[1]);
                frmMake.Text = Convert.ToString(dt.Rows[0].ItemArray[2]);
                frmEngine.Text = Convert.ToString(dt.Rows[0].ItemArray[3]);
                frmDateReg.Text = Convert.ToString(dt.Rows[0].ItemArray[4]);
                frmRentalPerDay.Text = Convert.ToString(dt.Rows[0].ItemArray[5]);
                int available = Convert.ToInt32(dt.Rows[0].ItemArray[6]);
                if (available == 1)
                {//if database returns 1 then we check the checkbox
                    frmAvailable.Checked = true;
                }
                else
                {//if database returns 0 then we uncheck the checkbox
                    frmAvailable.Checked = false;
                }

                btnUpdate.Enabled = false;
                btnCancel.Enabled = false;
                updatePanel.Visible = false;

                //Not entirely neccecary, just getting famililar with properties. I used these to display in the delete message box but its not needed
                details.VehicleReg = frmVehicleReg.Text;
                details.Make = frmMake.Text;
                details.Engine = frmEngine.Text;
                details.DateReg = frmDateReg.Text;
                details.RentalPerDay = frmRentalPerDay.Text;
                details.Available = available;

            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find data"); // if getData fails to works this message box appears.
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void vehicleTooltip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch searchForm = new frmSearch();
            searchForm.ShowDialog();
        }

        private void frmVehicleReg_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }


        private int availability;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd openAddForm = new frmAdd();
            this.Hide();
            openAddForm.ShowDialog();
            this.Close();

        }

        private void updateRecord()
        {//UPDATES RECORD BASED ON INFORMATION IN TEXT FIELDS
            int offsetNumber = recordControlNo - 1;
            try
            {
                if (frmAvailable.Checked == true)
                {
                    availability = 1;
                }
                if (frmAvailable.Checked == false)
                {
                    availability = 0;
                }

                string updateARecord = $@"UPDATE tblCar SET VehicleRegNo = '" + frmVehicleReg.Text + "', Make = '" + frmMake.Text + "', EngineSize == '" + frmEngine.Text + "', DateRegistered== '" + frmDateReg.Text + "', RentalPerDay = '" + frmRentalPerDay.Value + "', Available = '" + availability + "' WHERE VehicleRegNo = (SELECT VehicleRegNo from tblCar limit 1 OFFSET '" + offsetNumber + "');";
                databaseConnection.Open();
                SQLiteCommand insertSQL = new SQLiteCommand(databaseConnection);
                insertSQL.CommandText = updateARecord;
                insertSQL.ExecuteNonQuery();
                databaseConnection.Close();
                recTotal();
                getData();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot update data");
                return;
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DialogResult toDelete = MessageBox.Show($"Are you sure you'd like to delete this record\nVehicle Registration: {details.VehicleReg}\nMake: {details.Make}\nEngine Size: {details.Engine}\nDate Registered: {details.DateReg}\nRental Per Day: {details.RentalPerDay}\nAvailable: {details.SAvailable}", "Delete Record", MessageBoxButtons.YesNo);
            if (toDelete == DialogResult.Yes)
            {
                deleteData();
                MessageBox.Show("Record Deleted");


            }
            else if (toDelete == DialogResult.No)
            {
                MessageBox.Show("No record has been deleted.");
            }

        }
        private void deleteData()
        {
            {//DELETES CURRENT DISPLAYED DATA FROM DATABASE
                try
                {
                    string deleteARecord = $@"DELETE FROM tblCar WHERE VehicleRegNo = '{frmVehicleReg.Text}'";

                    databaseConnection.Open();
                    string sendData2 = deleteARecord;
                    SQLiteCommand deleteSQL = new SQLiteCommand(databaseConnection);
                    deleteSQL.CommandText = sendData2;
                    deleteSQL.ExecuteNonQuery();
                    databaseConnection.Close();
                    recTotal();
                    recordCounter("last");
                    getData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot delete data");
                }
            }
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            getData();
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            updatePanel.Visible = false;
            frmMake.BackColor = Color.White;
            frmEngine.BackColor = Color.White;
            frmDateReg.BackColor = Color.White;
            frmAvailable.BackColor = Color.White;
            frmRentalPerDay.BackColor = Color.White;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

            DialogResult toUpdate = MessageBox.Show("Are you sure you'd like to Update this record?", "Update Record", MessageBoxButtons.YesNo);
            if (toUpdate == DialogResult.Yes)
            {
                updateRecord();
                MessageBox.Show("Record Updated");


            }
            else if (toUpdate == DialogResult.No)
            {
                MessageBox.Show("No record has been deleted.");
            }
            frmMake.BackColor = Color.White;
            frmEngine.BackColor = Color.White;
            frmDateReg.BackColor = Color.White;
            frmAvailable.BackColor = Color.White;
            frmRentalPerDay.BackColor = Color.White;

        }

        private void frmMake_TextChanged(object sender, EventArgs e)
        {

            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }

        private void frmEngine_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }

        private void frmDateReg_TextChanged(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }

        private void frmRentalPerDay_TextChanged(object sender, EventArgs e)
        {

            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dateRegTooltip_Popup(object sender, PopupEventArgs e)
        {
        }

        private void frmRentalPerDay_ValueChanged(object sender, EventArgs e)
        {

            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }
        private void frmRentalPerDay_KeyDown(object sender, KeyEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            updatePanel.Visible = true;
        }

        public void frmMake_KeyDown(object sender, KeyEventArgs e)
        {
            frmMake.BackColor = Color.LightGoldenrodYellow;
        }

        private void frmEngine_KeyDown(object sender, KeyEventArgs e)
        {
            frmEngine.BackColor = Color.LightGoldenrodYellow;
        }

        private void frmDateReg_KeyDown(object sender, KeyEventArgs e)
        {
            frmDateReg.BackColor = Color.LightGoldenrodYellow;
        }

        private void frmAvailable_KeyDown(object sender, KeyEventArgs e)
        {
            frmAvailable.BackColor = Color.LightGoldenrodYellow;
        }

       // private void btnNext_Click(object sender, EventArgs e)
        

        

        //private void recordCount_TextChanged_1(object sender, EventArgs e)




        //private void btnPrevious_Click(object sender, EventArgs e)




        //private void btnFirst_Click(object sender, EventArgs e)




        // private void btnExit_Click(object sender, EventArgs e)




        // private void btnCancel_Click_1(object sender, EventArgs e)




        // private void btnSearch_Click(object sender, EventArgs e)




        //private void btnDelete_Click_1(object sender, EventArgs e)




        // private void btnUpdate_Click_1(object sender, EventArgs e)




        // private void btnAdd_Click(object sender, EventArgs e)



    }
}












    }
