using Microsoft.Data.SqlClient;
using System.Data;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;


public class Country
{
    public string Id { set; get; }
    public string Name { set; get; }
    public int RegionId { set; get; }


    public List<Country> GetAll()
    {
        var conn = Connection.GetConnection();
        List<Country> countries = new List<Country>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_countries";

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Country country = new Country();
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);

                    countries.Add(country);
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
        return countries;
    }

    public List<Country> GetById(string Id)
    {
        var conn = Connection.GetConnection();
        List<Country> countries = new List<Country>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(parameterId);

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var country = new Country();
                    country.Id = reader.GetString(0);
                    country.Name = reader.GetString(1);
                    country.RegionId = reader.GetInt32(2);

                    countries.Add(country);
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
        return countries;
    }


    public int Insert(string Id, string Name, int RegionId)
    {
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "INSERT INTO tb_m_countries (id, name, region_id) VALUES (@id, @name, @region_id)";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@name";
            parameterName.Value = Name;
            parameterName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterRegionId = new SqlParameter();
            parameterRegionId.ParameterName = "@region_id";
            parameterRegionId.Value = RegionId;
            parameterRegionId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterRegionId);

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


    public int Update(string Id, string Name, int RegionId)
    {
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE tb_m_countries SET " +
                                  "id = @id," +
                                  "name = @name," +
                                  "region_id = @region_id " +
                                  "WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Char;

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@name";
            parameterName.Value = Name;
            parameterName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterIdRegion = new SqlParameter();
            parameterIdRegion.ParameterName = "@region_id";
            parameterIdRegion.Value = RegionId;
            parameterIdRegion.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterIdRegion);

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

    public int Delete(string Id)
    {
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM tb_m_countries WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Char;

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
