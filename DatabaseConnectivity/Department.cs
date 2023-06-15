using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int locationId { get; set; }
        public int managerId { get; set; }


        public List<Department> GetAllDepartments()
        {
            var conn = Connection.connection;
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
                        department.id = reader.GetInt32(0);
                        department.name = reader.GetString(1);
                        department.locationId = reader.GetInt32(2);
                        department.managerId = reader.GetInt32(3);

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
    }
}
