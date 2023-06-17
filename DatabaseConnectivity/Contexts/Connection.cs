using Microsoft.Data.SqlClient;


namespace DatabaseConnectivity.Contexts;

public static class Connection
{
    private static readonly string ConnectionString = "Data Source=DESKTOP-S1VUB73;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public static readonly SqlConnection Conn = new SqlConnection(ConnectionString);
}