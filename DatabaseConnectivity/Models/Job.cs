using System.Data;
using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;

public class Job
{
    public string Id { get; set; }
    public string Title { get; set; }
    public int? MinSalary { get; set; }
    public int? MaxSalary { get; set; }


    public List<Job> GetAll()
    {
        var conn = Connection.Conn;
        List<Job> jobs = new List<Job>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_jobs";

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var job = new Job();
                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.MinSalary = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                    job.MaxSalary = reader.IsDBNull(3) ? null : reader.GetInt32(3);

                    jobs.Add(job);
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
        return jobs;
    }


    public List<Job> GetById(int Id)
    {
        var conn = Connection.Conn;
        List<Job> jobs = new List<Job>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_jobs WHERE id = @id";

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
                    Job job = new Job();
                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.MinSalary = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                    job.MaxSalary = reader.IsDBNull(3) ? null : reader.GetInt32(3);

                    jobs.Add(job);
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
        return jobs;
    }


    public int Insert(string Id, string Title, int? MinSalary, int? MaxSalary)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "INSERT INTO tb_m_jobs" +
                                  "(id, title, min_salary, max_salary)" +
                                  "VALUES" +
                                  "(@id, @title, @min_salary, @max_salary)";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterTitle = new SqlParameter();
            parameterTitle.ParameterName = "@title";
            parameterTitle.Value = Title;
            parameterTitle.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterMinSalary = new SqlParameter();
            parameterMinSalary.ParameterName = "@min_salary";
            parameterMinSalary.Value = MinSalary;
            parameterMinSalary.SqlDbType = SqlDbType.Int;

            SqlParameter parameterMaxSalary = new SqlParameter();
            parameterMaxSalary.ParameterName = "@max_salary";
            parameterMaxSalary.Value = MaxSalary;
            parameterMaxSalary.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterTitle);
            command.Parameters.Add(parameterMinSalary);
            command.Parameters.Add(parameterMaxSalary);

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


    public int Update(string Id, string Title, int? MinSalary, int? MaxSalary)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE tb_m_jobs SET " +
                                  "title = @title," +
                                  "min_salary = @min_salary," +
                                  "max_salary = @max_salary WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterTitle = new SqlParameter();
            parameterTitle.ParameterName = "@title";
            parameterTitle.Value = Title;
            parameterTitle.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterMinSalary = new SqlParameter();
            parameterMinSalary.ParameterName = "@min_salary";
            parameterMinSalary.Value = MinSalary;
            parameterMinSalary.SqlDbType = SqlDbType.Int;

            SqlParameter parameterMaxSalary = new SqlParameter();
            parameterMaxSalary.ParameterName = "@max_salary";
            parameterMaxSalary.Value = MaxSalary;
            parameterMaxSalary.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterTitle);
            command.Parameters.Add(parameterMinSalary);
            command.Parameters.Add(parameterMaxSalary);

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
            command.CommandText = "DELETE FROM tb_m_jobs WHERE id = @id";
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