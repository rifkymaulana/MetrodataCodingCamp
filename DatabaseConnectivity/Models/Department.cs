using System.Data;
using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;


public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LocationId { get; set; }
    public int? ManagerId { get; set; }


    public List<Department> GetAll()
    {
        var conn = Connection.GetConnection();
        List<Department> departments = new List<Department>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_departments";

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var department = new Department();
                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.IsDBNull(3) ? null : reader.GetInt32(3);

                    departments.Add(department);
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
        return departments;
    }


    public List<Department> GetById(int Id)
    {
        var conn = Connection.GetConnection();
        List<Department> departments = new List<Department>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_departments WHERE id = @id";

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
                    Department department = new Department();
                    department.Id = reader.GetInt32(0);
                    department.Name = reader.GetString(1);
                    department.LocationId = reader.GetInt32(2);
                    department.ManagerId = reader.IsDBNull(3) ? null : reader.GetInt32(3);

                    departments.Add(department);
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
        return departments;
    }


    public int Insert(int Id, string Name, int LocationId, int ManagerId)
    {
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText =
                "INSERT INTO tb_m_departments (id, name, location_id, manager_id) VALUES (@id, @name, @location_id, @manager_id)";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@name";
            parameterName.Value = Name;
            parameterName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterLocationId = new SqlParameter();
            parameterLocationId.ParameterName = "@location_id";
            parameterLocationId.Value = LocationId;
            parameterLocationId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterManagerId = new SqlParameter();
            parameterManagerId.ParameterName = "@manager_id";
            parameterManagerId.Value = ManagerId;
            parameterManagerId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterLocationId);
            command.Parameters.Add(parameterManagerId);

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


    public int Update(int Id, string Name, int LocationId, int ManagerId)
    {
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText =
                "UPDATE tb_m_departments SET name = @name, location_id = @location_id, manager_id = @manager_id WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterName = new SqlParameter();
            parameterName.ParameterName = "@name";
            parameterName.Value = Name;
            parameterName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterLocationId = new SqlParameter();
            parameterLocationId.ParameterName = "@location_id";
            parameterLocationId.Value = LocationId;
            parameterLocationId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterManagerId = new SqlParameter();
            parameterManagerId.ParameterName = "@manager_id";
            parameterManagerId.Value = ManagerId;
            parameterManagerId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterName);
            command.Parameters.Add(parameterLocationId);
            command.Parameters.Add(parameterManagerId);

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
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM tb_m_departments WHERE id = @id";
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
