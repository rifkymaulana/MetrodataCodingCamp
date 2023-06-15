using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    internal class Employee
    {
        public int id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public DateTime hireDate { get; set; }
        public int salary { get; set; }
        public decimal commisionPct { get; set; }
        public int managerId { get; set; }
        public string jobId { get; set; } = string.Empty;
        public int departmentId { get; set; }


        public List<Employee> GetAllEmployees()
        {
            var conn = Connection.connection;
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
                        var employee = new Employee();
                        employee.id = reader.GetInt32(0);
                        employee.firstName = reader.GetString(1);
                        employee.lastName = reader.GetString(2);
                        employee.email = reader.GetString(3);
                        employee.phoneNumber = reader.GetString(4);
                        employee.hireDate = reader.GetDateTime(5);
                        employee.salary = reader.GetInt32(6);
                        employee.commisionPct = reader.GetDecimal(7);
                        employee.managerId = reader.GetInt32(8);
                        employee.jobId = reader.GetString(9);
                        employee.departmentId = reader.GetInt32(10);
                        employee.password = $"{employee.id}{employee.jobId}";

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
}
