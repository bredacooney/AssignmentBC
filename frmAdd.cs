﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics.Eventing.Reader;

namespace CarsDataBase
{
    public partial class frmAdd : Form
    {
        SQLiteConnection connects = new SQLiteConnection(@"data source = C:\data\hire.db");

        public frmAdd()
        {
            InitializeComponent();
        }
        private void frmAdd_load(object sender, EventArgs e)
        {
        }
        private int availability;
        private string returnedReg;

        private void btnAdd_click(object sender, EventArgs e)
        {  // to evaluate to true in order to skip out of it    if they are all clear we want that to be true     if all of them are not equal to clear if that evaluates to true, you are going to use the "try " statement" 

            if (frmVehicleReg.Text != "" && frmMake.Text != "" && frmDateReg.Text != "" && frmEngine.Text != "" && frmRentalPerDay.Value != 0) {
                try
                {
                    //STRINGS USED FOR DB
                    String is RegInDb = $@"SELECT VehicleRegNo FROM tblCar WHERE VehicleRegNo = '" + frmVehicleReg.Text + "'";
                    connects.Open();

                    var command = connect.CreateCommand();
                    command.CommandText = isRegInDb;

                    using (var reader = command.ExecuteReader())
                    { //GETTING MATCHING RECORD
                        while (reader.Read())
                        {
                            var reg = reader.GetString(0);
                            returnedReg = reg;
                        }

                        //RETURNING IF VEHICLE REG MATCHES RECORD IN DB
                        if (frmVehicleReg.Text == returnedReg)
                        {
                            MessageBox.Show("Vehicle Registration Number may already exist in the database.");
                        }

                        // ADDING RECORD IF VehicleRegNo DOSEN'T MATCH
                        if (frmAvailable.Text != returnedReg)
                        {
                            if (frmAvailable.Checked == true)
                            {
                                availability = 1;
                            }
                            if (frmAvailable.Checked == false)
                            {
                                availability = 0;
                            }
                            string addRecord = $@"INSER INTO tblCar (VehicleRegNo, Make, EngineSize, DateRegistered, RentalPerDay, Available) Values
                           ('" + frmVehicleReg.Text + "', '" + frmMake.Test + "', '" + frmEngine.Text + "', '" + frmDateReg.Text + "', '" + frmRentalPerDay.Value + "', '" + availability + "')";

                            SQLiteCommand insertSQL = newSQLiteCommand(addARecord, connect);
                            insertSQL.CommandText = AddARecord;
                            insertSQL.ExecuteNonQuery();
                            MessageBox.Show("You have succesfully added a new record to the datbase");
                            connects.Close();
                        }


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("cannot add data");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please make sure all fields are completed");
            }
        }
                    
         private void frmVehicleReg_TextChanged(object sender, EventArgs e) 
        { 
        
        }

        private void frmMake_TextChanged(object sender, EventArgs e) 
        {
        
        }
        
        private void frmEngine_TextChanged(object sender, EventArgs e) 
        {
        
        }

        private void frmDateReg_textChanged (object sender, EventArgs e) 
        {
        
        }

        private void frmRentalPerDay_TextChanged(object sender, EventArgs e) 
        {
        
        }

        private void frmAvailable_CheckedChanged(object sender, EventArgs e) 
        {
        
        }

        private void button1_click(object sender, EventArgs e)
        {
            frmVehicleReg.Text = "";
            frmEngine.Text = "";
            frmDateReg.Text = "";
            frmMake.Text = "";
            frmRentalPerDay.Value = 0;
            frmAvailable.Checked = false;
        }

        private void btnclose_click(object sender, EventArgs e)
        {

            frmCars goToFrmCars = new frmCars();
            this.Hide()
            goToFrnmCars.ShowDialog();
            this.Close();
        }

        private void frmRentalPerDay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
    


