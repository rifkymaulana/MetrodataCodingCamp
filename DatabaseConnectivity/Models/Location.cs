using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;

public class Location
{
    public int Id { get; set; }
    public string StreetAddress { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string StateProvince { get; set; } = string.Empty;
    public string CountryId { get; set; } = string.Empty;


    public List<Location> GetAllLocations()
    {
        var conn = Connection.Conn;
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
                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.GetString(1);
                    location.PostalCode = reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.StateProvince = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    location.CountryId = reader.GetString(5);

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