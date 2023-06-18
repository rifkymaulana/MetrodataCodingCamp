using System.Data;
using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;


public class Location
{
    public int Id { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public string City { get; set; }
    public string? StateProvince { get; set; }
    public string? CountryId { get; set; }


    public List<Location> GetAll()
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
                    Location location = new Location();
                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(1);
                    location.PostalCode = reader.IsDBNull(2) ? null : reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.StateProvince = reader.IsDBNull(4) ? null : reader.GetString(4);
                    location.CountryId = reader.IsDBNull(5) ? null : reader.GetString(5);

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


    public List<Location> GetById(int Id)
    {
        var conn = Connection.Conn;
        List<Location> locations = new List<Location>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_locations WHERE id = @id";

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Location location = new Location();
                    location.Id = reader.GetInt32(0);
                    location.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(1);
                    location.PostalCode = reader.IsDBNull(2) ? null : reader.GetString(2);
                    location.City = reader.GetString(3);
                    location.StateProvince = reader.IsDBNull(4) ? null : reader.GetString(4);
                    location.CountryId = reader.IsDBNull(5) ? null : reader.GetString(5);

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


    public int Insert(int Id, string StreetAddress, string PostalCode, string City, string StateProvince,
        string CountryId)
    {
        int result = 0;
        Connection.Conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Connection.Conn;
            command.CommandText = "INSERT INTO tb_m_locations" +
                                  "(id, street_address, postal_code, city, state_province, country_id)" +
                                  "VALUES" +
                                  "(@id, @street_address, @postal_code, @city, @state_province, @country_id)";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterStreetAddress = new SqlParameter();
            parameterStreetAddress.ParameterName = "@street_address";
            parameterStreetAddress.Value = StreetAddress;
            parameterStreetAddress.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterPostalCode = new SqlParameter();
            parameterPostalCode.ParameterName = "@postal_code";
            parameterPostalCode.Value = PostalCode;
            parameterPostalCode.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterCity = new SqlParameter();
            parameterCity.ParameterName = "@city";
            parameterCity.Value = City;
            parameterCity.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterStateProvince = new SqlParameter();
            parameterStateProvince.ParameterName = "@state_province";
            parameterStateProvince.Value = StateProvince;
            parameterStateProvince.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterCountryId = new SqlParameter();
            parameterCountryId.ParameterName = "@country_id";
            parameterCountryId.Value = CountryId;
            parameterCountryId.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterStreetAddress);
            command.Parameters.Add(parameterPostalCode);
            command.Parameters.Add(parameterCity);
            command.Parameters.Add(parameterStateProvince);
            command.Parameters.Add(parameterCountryId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        Connection.Conn.Close();
        return result;
    }


    public int Update(int id, string StreetAddress, string PostalCode, string City, string StateProvince,
        string CountryId)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE tb_m_locations SET " +
                                  "street_address = @street_address," +
                                  "postal_code = @postal_code," +
                                  "city = @city," +
                                  "state_province = @state_province," +
                                  "country_id = @country_id WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterStreetAddress = new SqlParameter();
            parameterStreetAddress.ParameterName = "@street_address";
            parameterStreetAddress.Value = StreetAddress;
            parameterStreetAddress.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterPostalCode = new SqlParameter();
            parameterPostalCode.ParameterName = "@postal_code";
            parameterPostalCode.Value = PostalCode;
            parameterPostalCode.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterCity = new SqlParameter();
            parameterCity.ParameterName = "@city";
            parameterCity.Value = City;
            parameterCity.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterStateProvince = new SqlParameter();
            parameterStateProvince.ParameterName = "@state_province";
            parameterStateProvince.Value = StateProvince;
            parameterStateProvince.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterCountryId = new SqlParameter();
            parameterCountryId.ParameterName = "@country_id";
            parameterCountryId.Value = CountryId;
            parameterCountryId.SqlDbType = SqlDbType.Char;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterStreetAddress);
            command.Parameters.Add(parameterPostalCode);
            command.Parameters.Add(parameterCity);
            command.Parameters.Add(parameterStateProvince);
            command.Parameters.Add(parameterCountryId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        conn.Close();
        return result;
    }


    public int Delete(int Id)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM tb_m_locations WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        conn.Close();
        return result;
    }
}
