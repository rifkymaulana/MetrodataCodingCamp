using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public int Salary { get; set; }
    public decimal CommisionPct { get; set; }
    public int ManagerId { get; set; }
    public string JobId { get; set; } = string.Empty;
    public int DepartmentId { get; set; }

    public List<Employee> GetAllEmployees()
    {
        var conn = Connection.Conn;
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
                    employee.LastName = reader.GetString(2);
                    employee.Email = reader.GetString(3);
                    employee.PhoneNumber = reader.GetString(4);
                    employee.HireDate = reader.GetDateTime(5);
                    employee.Salary = reader.GetInt32(6);
                    employee.CommisionPct = reader.IsDBNull(7) ? 0.0m : reader.GetDecimal(7);
                    employee.ManagerId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                    employee.JobId = reader.IsDBNull(9) ? "" : reader.GetString(9);
                    employee.DepartmentId = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
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
}