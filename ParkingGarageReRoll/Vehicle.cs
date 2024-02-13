using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingGarageReRoll
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleType { get; set; }
        public int SlotId { get; set; }
        public int Floorname { get; set; }
        public int ParkingPosition {  get; set; }
        public Vehicle(int vehicleId, string licensePlate, string vehicleType, int slotId, int floorname,int parkingPosition)
        {
            VehicleId = vehicleId;
            LicensePlate = licensePlate;
            VehicleType = vehicleType;
            SlotId = slotId;
            Floorname = floorname;
            ParkingPosition = parkingPosition;
        }

        public static List<Vehicle> GetUnparkedVehicles()
        {
            List<Vehicle> unparked = new List<Vehicle>();
            try
            {
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = "SELECT VehicleId, LicensePlate, VehicleType FROM `vehicle` v WHERE NOT EXISTS (SELECT * FROM bikeslot b WHERE b.VehicleId = v.VehicleId) AND NOT EXISTS(select * from carslot c where c.VehicleId=v.VehicleId)";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    unparked.Add(new Vehicle(reader.GetInt32("VehicleId"), reader.GetString("LicensePlate"), reader.GetString("VehicleType"),0,0,0));
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error counting parked bikes: " + ex.Message);
            }
            finally
            {
                SqlDatabase.Close();
            }
            return unparked;
        }

        public static int GetNextAviableParkSlot(string vehicleType)
        {
            int freeParkSlotId = 0;
            try
            {
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = vehicleType == "Car" ? "SELECT BikeSlotId FROM `carslot` v WHERE VehicleId IS NULL" : "SELECT BikeSlotId FROM `bikeslot` v WHERE VehicleId IS NULL";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    freeParkSlotId = reader.GetInt32("BikeSlotID");
                    break;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error found free park slot: " + ex.Message);
            }
            finally
            {
                SqlDatabase.Close();
            }
            return freeParkSlotId;
        }
        public void ParkInto(int slotId)
        {
            try
            {
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = VehicleType == "Car" ? "UPDATE `carslot` set VehicleId=@VehicleId WHERE CarSLotId=@Id" : "UPDATE `bikeslot` set VehicleId=@VehicleId WHERE BikeSLotId=@Id";
                command.Parameters.AddWithValue("VehicleId", this.VehicleId);
                command.Parameters.AddWithValue("Id", slotId);
                command.ExecuteNonQuery();
                SlotId= slotId;

                //We still must get the slot infos
                command = SqlDatabase.CreateCommand();
                command.CommandText = VehicleType == "Motorcycle" ? "SELECT s.ParkingPosition, f.Floorname from `carslot` s JOINT floor f on f.FloorId=s.FloorId WHERE CarSLotId = @Id" :
                   "SELECT s.ParkingPosition, f.Floorname from `bikeslot` s JOINT floor f on f.FloorId = s.FloorId WHERE BikeSLotId = @Id";
                command.Parameters.AddWithValue("Id", slotId);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.ParkingPosition = reader.GetInt32("ParkingPosition");
                    this.Floorname= reader.GetInt32("Floorname");
                    break;
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error found free park slot: " + ex.Message);
            }
            finally
            {
                SqlDatabase.Close();
            }
        }
    }
}
