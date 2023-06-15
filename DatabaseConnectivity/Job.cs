using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    internal class Job
    {
        public string id { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public int minSalary { get; set; }
        public int maxSalary { get; set; }


        public List<Job> GetAllJobs()
        {
            var conn = Connection.connection;
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
                        /*
                        public string id { get; set; }
                        public string title { get; set; }
                        public int minSalary { get; set; }
                        public int maxSalary { get; set; }
                         */
                        var job = new Job();
                        job.id = reader.GetString(0);
                        job.title = reader.GetString(1);
                        job.minSalary = reader.GetInt32(2);
                        job.maxSalary = reader.GetInt32(3);

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
    }
}
