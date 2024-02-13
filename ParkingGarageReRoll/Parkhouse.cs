﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingGarageReRoll
{
    public partial class Parkhouse : Form
    {

        Floor floor = null;
        Vehicle vehicle = null;

        //GetParkedVehicleByIndex gpvByIndex = new GetParkedVehicleByIndex();
        public Parkhouse()
        {
            InitializeComponent();
        }

        readonly internal Dictionary<int, Floor> floorById = new Dictionary<int, Floor>();
        readonly internal Dictionary<int, Vehicle> vehicleById = new Dictionary<int, Vehicle>();

        internal void AddFloor(Floor p)
        {
            floorById[p.FloorId] = p;

            int index = dataGridViewParkingFloor.Rows.Add();
            dataGridViewParkingFloor.Rows[index].Cells["ColumnID"].Value = p.FloorId;
            dataGridViewParkingFloor.Rows[index].Cells["ColumnFloorname"].Value = p.FloorName;
            dataGridViewParkingFloor.Rows[index].Cells["ColumnCarSlotCount"].Value = p.CarSlotCount;
            dataGridViewParkingFloor.Rows[index].Cells["ColumnBikeSlotCount"].Value = p.BikeSlotCount;
        }
        internal void AddVehicleToFloor(Vehicle v)
        {
            vehicleById[v.VehicleId] = v;

            int index = dataGridViewVehicle.Rows.Add();
            dataGridViewVehicle.Rows[index].Cells["ColumnVehicleId"].Value = v.VehicleId;
            dataGridViewVehicle.Rows[index].Cells["ColumnVehicleLicensePlate"].Value = v.LicensePlate;
            dataGridViewVehicle.Rows[index].Cells["ColumnVehicleType"].Value = v.VehicleType;
        }
        internal void LoadParkingFloors()
        {
            List<Floor> floors = LoadTablesSql.LoadParkingFloors();
            foreach (Floor floor in floors)
            {
                AddFloor(floor);
            }
        }

        internal void Parkhouse_Load(object sender, EventArgs e)
        {
            LoadParkingFloors();
            dataGridViewParkingFloor_SelectionChanged(sender, e);
            dataGridViewParkingFloor.ClearSelection();
            dataGridViewVehicle.ClearSelection();
        }

        private void buttonFloorAdd_Click(object sender, EventArgs e)
        {
            int carSlotCount = (int)numericUpDownFloorCar.Value;
            if (carSlotCount <= 0)
            {
                numericUpDownFloorCar.Focus();
                return;
            }
            int bikeSlotCount = (int)numericUpDownFloorBike.Value;
            if (bikeSlotCount <= 0)
            {
                numericUpDownFloorBike.Focus();
                return;
            }

            // TODO - Floor muss immer bei 0 anfangen - Wenn floor gelöscht muss nächster die gelöschte zahl erhalten -- Done = Nur letzter Floor löschbar
            int floorname = Floor.GetNextAvailableFloorname();

            try
            {
                SqlDatabase.Open();       // Table Floor
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = "INSERT INTO `floor` (`FloorId`, `Floorname`, `CarSlotCount`, `BikeSlotCount`) VALUES (NULL, @Floorname, @CarSlotCount, @BikeSlotCount)";
                command.Parameters.AddWithValue("Floorname", floorname);
                command.Parameters.AddWithValue("CarSlotCount", carSlotCount);
                command.Parameters.AddWithValue("BikeSlotCount", bikeSlotCount);
                command.ExecuteNonQuery();

                int id = (int)command.LastInsertedId;


                AddFloor(new Floor(id, floorname, carSlotCount, bikeSlotCount));

                command = SqlDatabase.CreateCommand();
                command.CommandText = "INSERT INTO `carslot` (`CarSlotId`, `FloorId`, `VehicleId`, `ParkingPosition`) VALUES (NULL, @FloorId, NULL, @ParkingPosition)";
                command.Parameters.AddWithValue("FloorId", id);
                command.Parameters.AddWithValue("ParkingPosition", 0);
                for (int i = 0; i < carSlotCount; i++)
                {
                    command.Parameters["ParkingPosition"].Value = i + 1;
                    command.ExecuteNonQuery();
                }
                command = SqlDatabase.CreateCommand();
                command.CommandText = "INSERT INTO `bikeslot` (`BikeSlotId`, `FloorId`, `VehicleId`, `ParkingPosition`) VALUES (NULL, @FloorId, NULL, @ParkingPosition)";
                command.Parameters.AddWithValue("FloorId", id);
                command.Parameters.AddWithValue("ParkingPosition", 0);
                for (int i = 0; i < bikeSlotCount; i++)
                {
                    command.Parameters["ParkingPosition"].Value = i + 1;
                    command.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                SqlDatabase.Close();
                Console.WriteLine("Error adding floor: " + ex.Message);
                MessageBox.Show("Error adding floor.");
            }
            finally
            {
                SqlDatabase.Close();
            }
        }

        private void buttonFloorUpdate_Click(object sender, EventArgs e)
        {
            int index = -1;

            if (dataGridViewParkingFloor.SelectedRows.Count == 1)
            {
                index = dataGridViewParkingFloor.SelectedRows[0].Index;
            }
            else if (dataGridViewParkingFloor.SelectedCells.Count == 1)
            {
                index = dataGridViewParkingFloor.SelectedCells[0].RowIndex;
            }
            if (index == -1)
            {
                return;
            }

            int id = (int)dataGridViewParkingFloor.Rows[index].Cells["ColumnId"].Value;
            floor = floorById[id];

            int newCarSlot = (int)numericUpDownFloorCar.Value;
            if (newCarSlot <= 0)
            {
                numericUpDownFloorCar.Focus();
                return;
            }
            int newBikeSlot = (int)numericUpDownFloorBike.Value;
            if (newBikeSlot <= 0)
            {
                numericUpDownFloorBike.Focus();
                return;
            }


            SqlDatabase.Open();

            //TODO fehlende slots erstellen (falls count größer geworden) oder überschüssige slots löschen (fals count kleiner geworden)
            //if(newcarnumber<bearbeitetesFloor.carNumber)
            //delete from carslot where floorid=... and parkingposition>newcarnumber
            //else if(newcarnumber>bearbeiteterFloor.carNumber)
            //for(int i=bearbeiteterFloor.carNumber;i<newcarnumber;++i)
            //inser into carslot(...)
            MySqlCommand command;
            if (newCarSlot < floor.CarSlotCount)
            {
                command = SqlDatabase.CreateCommand();
                command.CommandText = "DELETE FROM `carslot` WHERE `FloorId` = @FloorId and ParkingPosition>@newcount"; //  + floor.FloorId // id
                command.Parameters.AddWithValue("FloorId", id);
                command.Parameters.AddWithValue("newcount", newCarSlot);
                command.Prepare();
                command.ExecuteNonQuery();
            }
            else if (newCarSlot > floor.CarSlotCount)
            {
                command = SqlDatabase.CreateCommand();
                command.CommandText = "INSERT INTO `carslot` (`CarSlotId`, `FloorId`, `VehicleId`, `ParkingPosition`) VALUES (NULL, @FloorId, NULL, @ParkingPosition)";
                command.Parameters.AddWithValue("FloorId", id);
                command.Parameters.AddWithValue("ParkingPosition", 0);
                for (int i = floor.CarSlotCount; i < newCarSlot; i++)
                {
                    command.Parameters["ParkingPosition"].Value = i + 1;
                    command.ExecuteNonQuery();
                }

            }
            if (newBikeSlot < floor.BikeSlotCount)
            {
                command = SqlDatabase.CreateCommand();
                command.CommandText = "DELETE FROM `bikeslot` WHERE `FloorId` = @FloorId and ParkingPosition>@newcount"; //  + floor.FloorId // id
                command.Parameters.AddWithValue("FloorId", id);
                command.Parameters.AddWithValue("newcount", newBikeSlot);
                command.Prepare();
                command.ExecuteNonQuery();
            }
            else if (newBikeSlot > floor.BikeSlotCount)
            {
                command = SqlDatabase.CreateCommand();
                command.CommandText = "INSERT INTO `bikeslot` (`BikeSlotId`, `FloorId`, `VehicleId`, `ParkingPosition`) VALUES (NULL, @FloorId, NULL, @ParkingPosition)";
                command.Parameters.AddWithValue("FloorId", id);
                command.Parameters.AddWithValue("ParkingPosition", 0);
                for (int i = floor.BikeSlotCount; i < newBikeSlot; i++)
                {
                    command.Parameters["ParkingPosition"].Value = i + 1;
                    command.ExecuteNonQuery();
                }

            }
            command = SqlDatabase.CreateCommand();
            command.CommandText = "UPDATE `floor` SET `CarSlotCount` = @CarSlotCount, `BikeSlotCount` = @BikeSlotCount WHERE `FloorId` = @Id";
            command.Parameters.AddWithValue("CarSlotCount", newCarSlot);
            command.Parameters.AddWithValue("BikeSlotCount", newBikeSlot);
            command.Parameters.AddWithValue("id", id);
            command.Prepare();
            command.ExecuteNonQuery();

            SqlDatabase.Close();

            floor.CarSlotCount = newCarSlot;
            floor.BikeSlotCount = newBikeSlot;

            dataGridViewParkingFloor.Rows[index].Cells["ColumnCarSlotCount"].Value = newCarSlot;
            dataGridViewParkingFloor.Rows[index].Cells["ColumnBikeSlotCount"].Value = newBikeSlot;

            numericUpDownFloorCar.Value = 0;
            numericUpDownFloorBike.Value = 0;
        }

        private void buttonFloorRemove_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDatabase.Open();

                MySqlCommand cmd = SqlDatabase.CreateCommand();

                cmd.CommandText = "SELECT FloorId FROM floor where floorname=(SELECT MAX(Floorname) FROM floor)";
                int lastFloorid = (int)cmd.ExecuteScalar();

                cmd = SqlDatabase.CreateCommand();
                cmd.CommandText = "delete from carslot where FloorId=@FloorId";
                cmd.Parameters.AddWithValue("FloorId", lastFloorid);
                cmd.ExecuteNonQuery();
                cmd = SqlDatabase.CreateCommand();
                cmd.CommandText = "delete from bikeslot where FloorId=@FloorId";
                cmd.Parameters.AddWithValue("FloorId", lastFloorid);
                cmd.ExecuteNonQuery();


                cmd.CommandText = "DELETE FROM floor WHERE FloorId = @id"; //TODO ID herausfinden
                cmd.Parameters.AddWithValue("id", lastFloorid);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Last floor successfully deleted.");
                    if (floor.FloorId == lastFloorid)
                    {
                        floor = null;
                    }
                }
                else
                {
                    MessageBox.Show("No floor available for extinguishing.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error deleting floor: " + ex.Message);
                MessageBox.Show("Error deleting last floor.");
            }
            finally
            {
                SqlDatabase.Close();
            }

            dataGridViewParkingFloor.Rows.Clear();
            LoadParkingFloors();
        }

        private void buttonVehicleAdd_Click(object sender, EventArgs e)
        {
            string licensePlate = textBoxVehicleLicensePlate.Text;
            if (licensePlate.Length <= 0)
            {
                textBoxVehicleLicensePlate.Focus();
                return;
            }
            string vehicleType = comboBoxVehicleType.Text;
            if (vehicleType.Length <= 0)
            {
                comboBoxVehicleType.Focus();
                return;
            }

            // ----->> The vehicle is parked on the floor using an extra button <<-----

            //int markiertIndex = -1;
            //if (dataGridViewParkingFloor.SelectedRows.Count == 1)
            //{
            //    markiertIndex = dataGridViewParkingFloor.CurrentRow.Index;
            //}

            //if (markiertIndex == -1)
            //{
            //    return;
            //}
            //int floorId = (int)dataGridViewParkingFloor.Rows[markiertIndex].Cells["ColumnId"].Value;
            //int floorname = (int)dataGridViewParkingFloor.Rows[markiertIndex].Cells["ColumnFloorname"].Value;

            try
            {
                SqlDatabase.Open();       // Table Vehicle
                MySqlCommand command = SqlDatabase.CreateCommand();                                                 // Safe all "LicensePlate" in Upper case
                command.CommandText = "INSERT INTO `vehicle` (`VehicleId`, `LicensePlate`, `VehicleType`) VALUES (NULL, UPPER(@LicensePlate), @VehicleType)";
                command.Parameters.AddWithValue("LicensePlate", licensePlate);
                command.Parameters.AddWithValue("VehicleType", vehicleType);
                command.ExecuteNonQuery();

                int id = (int)command.LastInsertedId;

                SqlDatabase.Close();
                                                            // Add LicensePlate in Upper Case
                AddVehicleToFloor(new Vehicle(id, licensePlate.ToUpper(), vehicleType, 0, 0, 0));
            }
            //else
            //{
            //    MessageBox.Show("No free parking slots at this floor");
            //}
            catch (Exception ex)
            {
                Console.WriteLine("Error adding a vehicle: " + ex.Message);
                // Database column "LicensePlate" = unique || Shows the Exception
                MessageBox.Show("Error adding a vehicle: " + ex.Message);
            }
        }

        // Useful to implement => not wanted by village Vence
        private void buttonVehicleUpdate_Click(object sender, EventArgs e)
        {
            buttonVehicleUpdate.Visible = false;
        }

        private void buttonVehicleRemove_Click(object sender, EventArgs e)
        {
            int index = -1;

            if (dataGridViewVehicle.SelectedRows.Count == 1)
            {
                index = dataGridViewVehicle.SelectedRows[0].Index;
            }
            else if (dataGridViewVehicle.SelectedCells.Count == 1)
            {
                index = dataGridViewVehicle.SelectedCells[0].RowIndex;
            }
            if (index == -1)
            {
                return;
            }

            int vehicleId = (int)dataGridViewVehicle.Rows[index].Cells["ColumnVehicleId"].Value;
            vehicle = vehicleById[vehicleId];

            if (vehicle.SlotId == 0)
            {
                int freeSlotId = Vehicle.GetNextAviableParkSlot(vehicle.VehicleType);
                if(freeSlotId==0)
                {
                    MessageBox.Show("There are not free " + vehicle.VehicleType + " slots");
                    return;
                }
                vehicle.ParkInto(freeSlotId);
                MessageBox.Show(vehicle.VehicleType+ " "+vehicle.LicensePlate+" parked into Floor "+vehicle.Floorname+" ParkingPosition "+vehicle.ParkingPosition);
            }
            else
            {
                try
                {
                    SqlDatabase.Open();

                    MySqlCommand cmd = SqlDatabase.CreateCommand();


                    // ToDo - if + ifelse schleife = Alternative löschung aus den Slots
                    cmd = SqlDatabase.CreateCommand();
                    cmd.CommandText = "update carslot set vehicleid=null where VehicleId = @VehicleId";
                    cmd.Parameters.AddWithValue("VehicleId", vehicleId);
                    cmd.ExecuteNonQuery();
                    cmd = SqlDatabase.CreateCommand();
                    cmd.CommandText = "update bikeslot set vehicleid=null where VehicleId = @VehicleId";
                    cmd.Parameters.AddWithValue("VehicleId", vehicleId);
                    cmd.ExecuteNonQuery();


                    int rowsAffected = cmd.ExecuteNonQuery();

                    // ToDo - Fix it == rowsAffected every time 0 ALSO hits the ELSE statement (Still when vehicle parked out)
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Vehicle is parked out.");
                        vehicle.SlotId = 0;
                        vehicle.ParkingPosition = 0;
                        vehicle.Floorname = 0;
                    }
                    else
                    {
                        MessageBox.Show("No vehicle found to park out.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error deleting the vehicle: " + ex.Message);
                    MessageBox.Show("Error deleting the vehicle: " + ex.Message);
                }
                finally
                {
                    SqlDatabase.Close();
                }
                // ToDo - Ungeparkte Autos löschen können
                dataGridViewVehicle.Rows.RemoveAt(index);
            }
            //LoadParkingFloors();

            // -------------------------------------------------------------------------------------- 
        }
        // ------------"buttonSearch_Click" Anpassen an neue Logik----------------------
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string search = textBoxSearch.Text.ToUpper();
            try
            {
                bool gefunden = false;
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = "SELECT b.CarSlotId, b.FloorId, b.VehicleId,v.VehicleId, b.ParkingPosition, v.LicensePlate, v.VehicleType,f.Floorname FROM `carslot` b JOIN Vehicle v ON v.VehicleId = b.VehicleID join floor f on f.FloorId=b.FloorId WHERE v.LicensePlate = @LicensePlate";
                command.Parameters.AddWithValue("LicensePlate", search);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gefunden = true;
                    int parkingPosition = reader.GetInt32("ParkingPosition");
                    int floorname = reader.GetInt32("Floorname");
                    labelSearchResult.Text = "The car you are looking for is on the floor: " + floorname + ".\rAt parking spot: " + parkingPosition;
                    //TODO keep found vehicle as object in order to be able to unpark it
                }
                reader.Close();
                if (gefunden) return;
                command = SqlDatabase.CreateCommand();
                command.CommandText = "SELECT b.BikeSlotId, b.FloorId, b.VehicleId,v.VehicleId, b.ParkingPosition, v.LicensePlate, v.VehicleType,f.Floorname FROM `bikeslot` b JOIN Vehicle v ON v.VehicleId = b.VehicleID join floor f on f.FloorId=b.FloorId WHERE v.LicensePlate = @LicensePlate";
                command.Parameters.AddWithValue("LicensePlate", search);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gefunden = true;
                    int parkingPosition = reader.GetInt32("ParkingPosition");
                    int floorname = reader.GetInt32("Floorname");
                    labelSearchResult.Text = "The motorcycle you are looking for is on the floor: " + floorname + ".\rAt parking spot: " + parkingPosition;
                    //TODO keep found vehicle as object in order to be able to unpark it
                }
                reader.Close();
                if (gefunden) return;
                labelSearchResult.Text = "No vehicle with the license plate in the parking garage.";

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error searching for parked vehicles: " + ex.Message);
            }
            finally
            {
                SqlDatabase.Close();
            }
            textBoxSearch.Text = "<<License plate>>";
            //----------------------------------------------------------------------
        }
        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            labelSearchResult.Text = "<<Result of your search>>";
        }

        // -------------Vorrübergehende Funktionen Auslagern -> Geht nicht weil verweis auf "floorById" fehlt..?!?---------------
        internal int GetSelectedDgvFloorIndex()
        {
            // Im "Parkhouse.Designer.cs" die GUI-Elemente von "privat" auf "internal" gesetzt
            dataGridViewVehicle.Rows.Clear();

            int markiertIndex = -1;
            if (dataGridViewParkingFloor.SelectedRows.Count == 1)
            {
                markiertIndex = dataGridViewParkingFloor.CurrentRow.Index;
            }

            if (markiertIndex == -1)
            {
                //return;
            }
            DataGridViewCell cell = dataGridViewParkingFloor.Rows[markiertIndex].Cells["ColumnId"];
            if (cell.Value == null)
            {
                //return;
            }
            int id = (int)cell.Value;

            return id;
        }
        internal int GetParkedBikeByIndex(int id)
        {
            // Gibt den Index der Ausgewählten Zeile wieder
            floor = floorById[id];

            int parkedCars = 0;

            try
            {
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM vehicle WHERE FloorId =" + floor.FloorId + " AND VehicleType = 'Motorbike'"; //"SELECT Floorname FROM ParkingFloor WHERE Floorname > 0 ORDER BY Floorname ASC LIMIT 1"
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    parkedCars = Convert.ToInt32(result);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error counting parked motorcycles: " + ex.Message);
            }
            finally
            {
                SqlDatabase.Close();
            }
            return parkedCars;
        }
        internal int GetParkedCarByIndex(int id)
        {
            // Gibt den Index der Ausgewählten Zeile wieder
            floor = floorById[id];

            int parkedCars = 0;

            try
            {
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM vehicle WHERE FloorId =" + floor.FloorId + " AND VehicleType = 'Car'"; //"SELECT Floorname FROM ParkingFloor WHERE Floorname > 0 ORDER BY Floorname ASC LIMIT 1"
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    parkedCars = Convert.ToInt32(result);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error counting parked cars: " + ex.Message);
            }
            finally
            {
                SqlDatabase.Close();
            }
            return parkedCars;
        }
        // -------------Vorrübergehende Funktionen Auslagern -> Geht nicht weil verweis auf "floorById" fehlt..?!?--------------- ENDE 
        private void dataGridViewParkingFloor_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewVehicle.Rows.Clear();
            vehicleById.Clear();

            int markiertIndex = -1;
            floor = null;
            if (dataGridViewParkingFloor.SelectedRows.Count == 1)
            {
                markiertIndex = dataGridViewParkingFloor.CurrentRow.Index;
            }

            if (markiertIndex != -1)
            {
                DataGridViewCell cell = dataGridViewParkingFloor.Rows[markiertIndex].Cells["ColumnId"];
                if (cell.Value != null)
                {
                    int id = (int)cell.Value;
                    floor = floorById[id];
                }
            }

            if (floor == null)
            {
                List<Vehicle> unparked = Vehicle.GetUnparkedVehicles();
                int cars = 0;
                int bikes = 0;
                foreach (Vehicle v in unparked)
                {
                    if (v.VehicleType == "Car") ++cars; else ++bikes;
                    vehicleById[v.VehicleId] = v;
                    int i = dataGridViewVehicle.Rows.Add();
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleId"].Value = v.VehicleId;
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleLicensePlate"].Value = v.LicensePlate;
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleType"].Value = v.VehicleType;
                }
                labelFreeParkSlot.Text = "Unparked Cars: " + cars
                    + "\rUnparked Bikes:" + bikes;
                                    // Button rename
                buttonVehicleRemove.Text = "Park in";
            }
            else
            {
                List<Vehicle> parked = floor.GetParkedVehicles();
                int cars = 0;
                int bikes = 0;
                foreach (Vehicle v in parked)
                {
                    if (v.VehicleType == "Car") ++cars; else ++bikes;
                    vehicleById[v.VehicleId] = v;
                    int i = dataGridViewVehicle.Rows.Add();
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleId"].Value = v.VehicleId;
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleLicensePlate"].Value = v.LicensePlate;
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleType"].Value = v.VehicleType;
                    dataGridViewVehicle.Rows[i].Cells["ColumnVehicleParkingPosition"].Value = v.ParkingPosition;
                }
                labelFreeParkSlot.Text = "Parked Cars: " + cars
                    + "\rFree Car Slots:" + (floor.CarSlotCount - cars)
                    + "\rParked Bikes:" + bikes
                    + "\rFree Bike Slots:" + (floor.BikeSlotCount - bikes);
                                    // Button rename
                buttonVehicleRemove.Text = "Park out";
            }
           
        }
    }
}
