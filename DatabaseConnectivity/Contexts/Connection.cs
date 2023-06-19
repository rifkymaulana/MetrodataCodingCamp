using Microsoft.Data.SqlClient;

namespace DatabaseConnectivity.Contexts;


public static class Connection
{
    private static string ConnectionString = "Data Source=DESKTOP-S1VUB73;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    private static SqlConnection? Conn;
    public static SqlConnection GetConnection()
    {
        if (Conn == null)
        {
            Conn = new SqlConnection(ConnectionString);
        }
        return Conn;
    }
}
