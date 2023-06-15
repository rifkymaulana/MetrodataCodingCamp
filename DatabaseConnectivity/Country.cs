using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity
{
    public class Country
    {
        public string? id { set; get; }
        public string? name { set; get; }
        public int regionId { set; get; }


        public List<Country> GetAllCountries()
        {
            var conn = Connection.connection;
            List<Country> countries = new List<Country>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_countries";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.id = reader.GetString(0);
                        country.name = reader.GetString(1);
                        country.regionId = reader.GetInt32(2);

                        countries.Add(country);
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
            return countries;
        }

        public List<Country> GetCountryById(string id)
        {
            var conn = Connection.connection;
            List<Country> countries = new List<Country>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE id = @id";

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(parameterId);

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.id = reader.GetString(0);
                        country.name = reader.GetString(1);
                        country.regionId = reader.GetInt32(2);

                        countries.Add(country);
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
            return countries;
        }


        public int InsertCountry(string id, string name, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "INSERT INTO tb_m_countries (id, name, region_id) VALUES (@id, @name, @region_id)";
                command.Transaction = transaction;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.VarChar;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@name";
                parameterName.Value = name;
                parameterName.SqlDbType = SqlDbType.VarChar;

                SqlParameter parameterRegionId = new SqlParameter();
                parameterRegionId.ParameterName = "@region_id";
                parameterRegionId.Value = region_id;
                parameterRegionId.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameterId);
                command.Parameters.Add(parameterName);
                command.Parameters.Add(parameterRegionId);

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
            Connection.connection.Close();
            return result;
        }


        public int UpdateRegionById(string id, string name, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "UPDATE tb_m_countries SET id = @id, name = @name, region_id = @region_id WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.VarChar;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@name";
                parameterName.Value = name;
                parameterName.SqlDbType = SqlDbType.VarChar;

                SqlParameter parameterIdRegion = new SqlParameter();
                parameterIdRegion.ParameterName = "@region_id";
                parameterIdRegion.Value = region_id;
                parameterIdRegion.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameterId);
                command.Parameters.Add(parameterName);
                command.Parameters.Add(parameterIdRegion);

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
            Connection.connection.Close();
            return result;
        }

        public static int DeleteRegionById(int id)
        {
            var conn = Connection.connection;
            int result = 0;
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "DELETE FROM tb_m_countries WHERE id = @id";
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
}
