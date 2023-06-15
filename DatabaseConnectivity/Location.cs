using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Location
    {
        public int id { get; set; }
        public string streetAddress { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string stateProvince { get; set; } = string.Empty;
        public string countryId { get; set; } = string.Empty;


        public List<Location> GetAllLocations()
        {
            var conn = Connection.connection;
            List<Location> locations = new List<Location>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_locations";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var location = new Location();
                        location.id = reader.GetInt32(0);
                        location.streetAddress = reader.GetString(1);
                        location.postalCode = reader.GetString(2);
                        location.city = reader.GetString(3);
                        location.stateProvince = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        location.countryId = reader.GetString(5);

                        locations.Add(location);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return locations;
        }
    }
}
