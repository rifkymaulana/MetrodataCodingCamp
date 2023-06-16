using Microsoft.Data.SqlClient;
using DatabaseConnectivity.Contexts;

namespace DatabaseConnectivity.Models;

public class Job
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }


    public List<Job> GetAllJobs()
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
                    /*
                    public string id { get; set; }
                    public string title { get; set; }
                    public int minSalary { get; set; }
                    public int maxSalary { get; set; }
                     */
                    var job = new Job();
                    job.Id = reader.GetString(0);
                    job.Title = reader.GetString(1);
                    job.MinSalary = reader.GetInt32(2);
                    job.MaxSalary = reader.GetInt32(3);

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