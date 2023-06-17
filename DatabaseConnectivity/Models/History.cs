using System.Data;
using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;

public class History
{
    public DateTime StartDate { get; set; }
    public int EmployeeId { get; set; }
    public DateTime? EndDate { get; set; }
    public int DepartmentId { get; set; }
    public string JobId { get; set; }


    public List<History> GetAll()
    {
        var conn = Connection.Conn;
        List<History> histories = new List<History>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_tr_histories";

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var history = new History();
                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);

                    histories.Add(history);
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
        return histories;
    }


    public List<History> GetByEmployeeId(int EmployeeId)
    {
        var conn = Connection.Conn;
        List<History> histories = new List<History>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_histories WHERE employee_id = @employee_id";

            SqlParameter parameterEmployeeId = new SqlParameter();
            parameterEmployeeId.ParameterName = "@employee_id";
            parameterEmployeeId.Value = EmployeeId;
            parameterEmployeeId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterEmployeeId);

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Location location = new Location();
                    var history = new History();
                    history.StartDate = reader.GetDateTime(0);
                    history.EmployeeId = reader.GetInt32(1);
                    history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                    history.DepartmentId = reader.GetInt32(3);
                    history.JobId = reader.GetString(4);

                    histories.Add(history);
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
        return histories;
    }


    public int Insert(DateTime StartDate, int EmployeeId, DateTime? EndDate, int DepartmentId, string JobId)
    {
        int result = 0;
        Connection.Conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Connection.Conn;
            command.CommandText = "INSERT INTO tb_m_histories" +
                                  "(start_date, employee_id, end_date, department_id, job_id)" +
                                  "VALUES" +
                                  "(@start_date, @employee_id, @end_date, @department_id, @job_id)";
            command.Transaction = transaction;

            SqlParameter parameterStartDate = new SqlParameter();
            parameterStartDate.ParameterName = "@start_date";
            parameterStartDate.Value = StartDate;
            parameterStartDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterEmployeeId = new SqlParameter();
            parameterEmployeeId.ParameterName = "@employee_id";
            parameterEmployeeId.Value = EmployeeId;
            parameterEmployeeId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterEndDate = new SqlParameter();
            parameterEndDate.ParameterName = "@end_date";
            parameterEndDate.Value = EndDate;
            parameterEndDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterDepartmentId = new SqlParameter();
            parameterDepartmentId.ParameterName = "@department_id";
            parameterDepartmentId.Value = DepartmentId;
            parameterDepartmentId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterJobId = new SqlParameter();
            parameterJobId.ParameterName = "@job_id";
            parameterJobId.Value = JobId;
            parameterJobId.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(parameterStartDate);
            command.Parameters.Add(parameterEmployeeId);
            command.Parameters.Add(parameterEndDate);
            command.Parameters.Add(parameterDepartmentId);
            command.Parameters.Add(parameterJobId);

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


    public int Update(DateTime StartDate, int EmployeeId, DateTime? EndDate, int DepartmentId, string JobId)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = Connection.Conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE tb_m_histories SET " +
                                  "start_date = @start_date," +
                                  "employee_id = @employee_id," +
                                  "end_date = @end_date," +
                                  "department_id = @department_id," +
                                  "job_id = @job_id WHERE start_date = @start_date AND employee_id = @employee_id";
            command.Transaction = transaction;

            SqlParameter parameterStartDate = new SqlParameter();
            parameterStartDate.ParameterName = "@start_date";
            parameterStartDate.Value = StartDate;
            parameterStartDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterEmployeeId = new SqlParameter();
            parameterEmployeeId.ParameterName = "@employee_id";
            parameterEmployeeId.Value = EmployeeId;
            parameterEmployeeId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterEndDate = new SqlParameter();
            parameterEndDate.ParameterName = "@end_date";
            parameterEndDate.Value = EndDate;
            parameterEndDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterDepartmentId = new SqlParameter();
            parameterDepartmentId.ParameterName = "@department_id";
            parameterDepartmentId.Value = DepartmentId;
            parameterDepartmentId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterJobId = new SqlParameter();
            parameterJobId.ParameterName = "@job_id";
            parameterJobId.Value = JobId;
            parameterJobId.SqlDbType = SqlDbType.VarChar;

            command.Parameters.Add(parameterStartDate);
            command.Parameters.Add(parameterEmployeeId);
            command.Parameters.Add(parameterEndDate);
            command.Parameters.Add(parameterDepartmentId);
            command.Parameters.Add(parameterJobId);

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


    public int Delete(DateTime StartDate, int EmployeeId)
    {
        var conn = Connection.Conn;
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM tb_m_locations WHERE start_date = @start_date AND employee_id = @employee_id";
            command.Transaction = transaction;

            SqlParameter parameterStartDate = new SqlParameter();
            parameterStartDate.ParameterName = "@start_date";
            parameterStartDate.Value = StartDate;
            parameterStartDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterEmployeeId = new SqlParameter();
            parameterEmployeeId.ParameterName = "@employee_id";
            parameterEmployeeId.Value = EmployeeId;
            parameterEmployeeId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterStartDate);
            command.Parameters.Add(parameterEmployeeId);

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