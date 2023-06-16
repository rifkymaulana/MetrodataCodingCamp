using Microsoft.Data.SqlClient;
using System.Data;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;

public class Region
{
    public int Id { get; set; }
    public string? Name { get; set; }


    public List<Region> GetAllRegions()
    {
        var conn = Connection.Conn;
        List<Region> regions = new List<Region>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_regions";

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var region = new Region();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);

                    regions.Add(region);
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
        return regions;
    }


    public List<Region> GetRegionById(int id)
    {
        var conn = Connection.Conn;
        List<Region> regions = new List<Region>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_regions WHERE id = @id";

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = id;
            parameterId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var region = new Region();
                    region.Id = reader.GetInt32(0);
                    region.Name = reader.GetString(1);

                    regions.Add(region);
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
        return regions;
    }


    public int InsertRegion(string name)
    {
        int result = 0;
        Connection.Conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Connection.Conn;
            command.CommandText = "INSERT INTO tb_m_regions (name) VALUES (@region_name)";
            command.Transaction = transaction;

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@region_name";
            parameterName.Value = name;
            parameterName.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(parameterName);

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


    public int UpdateRegionById(int id, string name)
    {
        int result = 0;
        Connection.Conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Connection.Conn;
            command.CommandText = "UPDATE tb_m_regions SET name = @name WHERE id = @id";
            command.Transaction = transaction;


            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@name";
            parameterName.Value = name;
            parameterName.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterName);

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


    public int DeleteRegionById(int id)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM tb_m_regions WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = id;
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