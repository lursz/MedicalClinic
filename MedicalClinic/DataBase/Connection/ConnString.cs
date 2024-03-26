using System.Text.Json;

namespace MedicalClinic.DataBase.Connection;

public class ConnString
{
    private const string _path = "DataBase/Connection/db.json";
    public static string DbConnectionString { get; private set; }


    static ConnString()
    {
        InitializeConnectionStringList();
    }

    private static void InitializeConnectionStringList()
    {
        try
        {
            var jsonContent = File.ReadAllText(_path);
            var config = JsonSerializer.Deserialize<DBConfiguration>(jsonContent);
            DbConnectionString = config.DBConnectionString;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}



public class DBConfiguration
{
    public string DBConnectionString { get; set; }
}