using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkingGarageReRoll
{
    public class Floor
    {
        public int FloorId { get; set; }
        public int FloorName { get; set; }
        public int CarSlotCount { get; set; }
        public int BikeSlotCount { get; set; }
        public Floor(int parkingFloorId, int floorName, int carNumber, int bikeNumber)
        {
            FloorId = parkingFloorId;
            FloorName = floorName;
            CarSlotCount = carNumber;
            BikeSlotCount = bikeNumber;
        }
        // Static funktioniert nicht
        public static int GetNextAvailableFloorname()
        {
            int nextFloorname = 0;

            SqlDatabase.Open();
            MySqlCommand command = SqlDatabase.CreateCommand();
            command.CommandText = "SELECT MAX(Floorname) FROM floor";
            object result = command.ExecuteScalar();
            if (result != null && result != DBNull.Value)
            {
                nextFloorname = Convert.ToInt32(result)+1;
            }
            SqlDatabase.Close();

            //if(result != DBNull.Value)
            //{
            //    nextAviableFloorname = Convert.ToInt32(result);
            //}

            return nextFloorname;
        }

        public List<Vehicle> GetParkedVehicles()
        {
            List<Vehicle> parked = new List<Vehicle>();
            try
            {
                SqlDatabase.Open();
                MySqlCommand command = SqlDatabase.CreateCommand();
                command.CommandText = "SELECT b.CarSlotId, b.FloorId, b.VehicleId, b.ParkingPosition, v.LicensePlate, v.VehicleType FROM `carslot` b JOIN Vehicle v ON v.VehicleId = b.VehicleID WHERE b.FloorId = '"+this.FloorId + "' AND b.VehicleId IS NOT NULL";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    parked.Add(new Vehicle(reader.GetInt32("VehicleId"), reader.GetString("LicensePlate"), reader.GetString("VehicleType"), reader.GetInt32("CarSlotId"),this.FloorId,this.FloorName));
                }
                reader.Close();
                command.CommandText = "SELECT b.BikeSlotId, b.FloorId, b.VehicleId, b.ParkingPosition, v.LicensePlate, v.VehicleType FROM `bikeslot` b JOIN Vehicle v ON v.VehicleId = b.VehicleID WHERE b.FloorId = '" + this.FloorId + "' AND b.VehicleId IS NOT NULL";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    parked.Add(new Vehicle(reader.GetInt32("VehicleId"), reader.GetString("LicensePlate"), reader.GetString("VehicleType"), reader.GetInt32("BikeSlotId"), this.FloorId, this.FloorName));
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
            return parked;
        }
    }
}
