using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DataBase;

public static class DbHandler
{
    public static void MigrateDB()
    {
        using var context = new Context(Connection.ConnString.DbConnectionString);
        context.Database.Migrate();
    }
    
}