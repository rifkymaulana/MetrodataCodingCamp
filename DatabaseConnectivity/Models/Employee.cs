using System.Data;
using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;


public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public int? Salary { get; set; }
    public decimal? CommissionPct { get; set; }
    public int? ManagerId { get; set; }
    public string JobId { get; set; } = string.Empty;
    public int DepartmentId { get; set; }

    public List<Employee> GetAll()
    {
        var conn = Connection.GetConnection();
        List<Employee> employees = new List<Employee>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_employees";

            conn.Open();

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.IsDBNull(6) ? null : reader.GetInt32(6);
                    employee.CommissionPct = reader.IsDBNull(7) ? null : reader.GetDecimal(7);
                    employee.ManagerId = reader.IsDBNull(8) ? null : reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartmentId = reader.GetInt32(10);
                    employee.Password = $"{employee.Id}{employee.JobId}";

                    employees.Add(employee);
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
        return employees;
    }


    public List<Employee> GetById(int Id)
    {
        var conn = Connection.GetConnection();
        List<Employee> employees = new List<Employee>();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_employees WHERE id = @id";

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
                    Employee employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.Password = $"{reader.GetInt32(0)}{reader.GetInt32(9)}";
                    employee.PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.IsDBNull(6) ? null : reader.GetInt32(6);
                    employee.CommissionPct = reader.IsDBNull(7) ? null : reader.GetDecimal(7);
                    employee.ManagerId = reader.IsDBNull(8) ? null : reader.GetInt32(8);
                    employee.JobId = reader.GetString(9);
                    employee.DepartmentId = reader.GetInt32(10);

                    employees.Add(employee);
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
        return employees;
    }


    public int Insert(int Id, string FirstName, string LastName, string Email, string PhoneNumber,
        DateTime HireDate, int Salary, decimal CommissionPct, int ManagerId, string JobId, int DepartmentId)
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
                "INSERT INTO tb_m_employees (id, first_name, last_name, email, phone_number, hire_date, salary, comission_pct, manager_id, job_id, department_id) VALUES (@id, @first_name, @last_name, @email, @phone_number, @hire_date, @salary, @commission_pct, @manager_id, @job_id, @department_id)";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterFirstName = new SqlParameter();
            parameterFirstName.ParameterName = "@first_name";
            parameterFirstName.Value = FirstName;
            parameterFirstName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterLastName = new SqlParameter();
            parameterLastName.ParameterName = "@last_name";
            parameterLastName.Value = LastName;
            parameterLastName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterEmail = new SqlParameter();
            parameterEmail.ParameterName = "@email";
            parameterEmail.Value = Email;
            parameterEmail.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterPhoneNumber = new SqlParameter();
            parameterPhoneNumber.ParameterName = "@phone_number";
            parameterPhoneNumber.Value = PhoneNumber;
            parameterPhoneNumber.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterHireDate = new SqlParameter();
            parameterHireDate.ParameterName = "@hire_date";
            parameterHireDate.Value = HireDate;
            parameterHireDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterSalary = new SqlParameter();
            parameterSalary.ParameterName = "@salary";
            parameterSalary.Value = Salary;
            parameterSalary.SqlDbType = SqlDbType.Int;

            SqlParameter parameterCommissionPct = new SqlParameter();
            parameterCommissionPct.ParameterName = "@commission_pct";
            parameterCommissionPct.Value = CommissionPct;
            parameterCommissionPct.SqlDbType = SqlDbType.Decimal;

            SqlParameter parameterManagerId = new SqlParameter();
            parameterManagerId.ParameterName = "@manager_id";
            parameterManagerId.Value = ManagerId;
            parameterManagerId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterJobId = new SqlParameter();
            parameterJobId.ParameterName = "@job_id";
            parameterJobId.Value = JobId;
            parameterJobId.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterDepartmentId = new SqlParameter();
            parameterDepartmentId.ParameterName = "@department_id";
            parameterDepartmentId.Value = DepartmentId;
            parameterDepartmentId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterFirstName);
            command.Parameters.Add(parameterLastName);
            command.Parameters.Add(parameterEmail);
            command.Parameters.Add(parameterPhoneNumber);
            command.Parameters.Add(parameterHireDate);
            command.Parameters.Add(parameterSalary);
            command.Parameters.Add(parameterCommissionPct);
            command.Parameters.Add(parameterManagerId);
            command.Parameters.Add(parameterJobId);
            command.Parameters.Add(parameterDepartmentId);

            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            transaction.Rollback();
        }

        conn.Close();
        return result;
    }


    public int Update(int Id, string FirstName, string LastName, string Email, string Password, string PhoneNumber,
        DateTime HireDate, int Salary, decimal CommissionPct, int ManagerId, string JobId, int DepartmentId)
    {
        var conn = Connection.GetConnection();
        int result = 0;
        conn.Open();

        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE tb_m_employees SET " +
                                  "first_name = @first_name," +
                                  "last_name = @last_name," +
                                  "email = @email," +
                                  "password = @password," +
                                  "phone_number = @phone_number," +
                                  "hire_date = @hire_date," +
                                  "salary = @salary," +
                                  "commission_pct = @commission_pct," +
                                  "manager_id = @manager_id," +
                                  "job_id = @job_id," +
                                  "department_id = @department_id " +
                                  "WHERE id = @id";
            command.Transaction = transaction;

            SqlParameter parameterId = new SqlParameter();
            parameterId.ParameterName = "@id";
            parameterId.Value = Id;
            parameterId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterFirstName = new SqlParameter();
            parameterFirstName.ParameterName = "@first_name";
            parameterFirstName.Value = FirstName;
            parameterFirstName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterLastName = new SqlParameter();
            parameterLastName.ParameterName = "@last_name";
            parameterLastName.Value = LastName;
            parameterLastName.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterEmail = new SqlParameter();
            parameterEmail.ParameterName = "@email";
            parameterEmail.Value = Email;
            parameterEmail.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterPassword = new SqlParameter();
            parameterPassword.ParameterName = "@password";
            parameterPassword.Value = Password;
            parameterPassword.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterPhoneNumber = new SqlParameter();
            parameterPhoneNumber.ParameterName = "@phone_number";
            parameterPhoneNumber.Value = PhoneNumber;
            parameterPhoneNumber.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterHireDate = new SqlParameter();
            parameterHireDate.ParameterName = "@hire_date";
            parameterHireDate.Value = HireDate;
            parameterHireDate.SqlDbType = SqlDbType.DateTime;

            SqlParameter parameterSalary = new SqlParameter();
            parameterSalary.ParameterName = "@salary";
            parameterSalary.Value = Salary;
            parameterSalary.SqlDbType = SqlDbType.Int;

            SqlParameter parameterCommissionPct = new SqlParameter();
            parameterCommissionPct.ParameterName = "@commission_pct";
            parameterCommissionPct.Value = CommissionPct;
            parameterCommissionPct.SqlDbType = SqlDbType.Decimal;

            SqlParameter parameterManagerId = new SqlParameter();
            parameterManagerId.ParameterName = "@manager_id";
            parameterManagerId.Value = ManagerId;
            parameterManagerId.SqlDbType = SqlDbType.Int;

            SqlParameter parameterJobId = new SqlParameter();
            parameterJobId.ParameterName = "@job_id";
            parameterJobId.Value = JobId;
            parameterJobId.SqlDbType = SqlDbType.VarChar;

            SqlParameter parameterDepartmentId = new SqlParameter();
            parameterDepartmentId.ParameterName = "@department_id";
            parameterDepartmentId.Value = DepartmentId;
            parameterDepartmentId.SqlDbType = SqlDbType.Int;

            command.Parameters.Add(parameterId);
            command.Parameters.Add(parameterFirstName);
            command.Parameters.Add(parameterLastName);
            command.Parameters.Add(parameterEmail);
            command.Parameters.Add(parameterPassword);
            command.Parameters.Add(parameterPhoneNumber);
            command.Parameters.Add(parameterHireDate);
            command.Parameters.Add(parameterSalary);
            command.Parameters.Add(parameterCommissionPct);
            command.Parameters.Add(parameterManagerId);
            command.Parameters.Add(parameterJobId);
            command.Parameters.Add(parameterDepartmentId);

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
            command.CommandText = "DELETE FROM tb_m_employees WHERE id = @id";
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
