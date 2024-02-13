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
    public class SqlLoadTables
    {
        static public List<Floor> LoadParkingFloors()
        {
            List<Floor> floors=new List<Floor>();
            try
            {
                SqlDatabase.Open();
                MySqlCommand cmd = SqlDatabase.CreateCommand();
                cmd.CommandText = "SELECT FloorId, Floorname, CarSlotCount, BikeSlotCount FROM floor";
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int floorName = reader.GetInt32(1);
                    int carNumber = reader.GetInt32(2);
                    int bikeNumber = reader.GetInt32(3);

                    floors.Add(new Floor(id, floorName, carNumber, bikeNumber));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error loading parking floors: " + ex.Message);
                MessageBox.Show("Error loading parking floors from the database.");
            }
            finally
            {
                SqlDatabase.Close();
            }
            return floors;
        }
    }
}
