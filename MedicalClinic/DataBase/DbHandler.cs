using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DataBase;

public static class DbHandler
{
    private static Context _context = new Context(Connection.ConnString.DbConnectionString);
    public static void MigrateDB()
    {
        _context.Database.Migrate();
    }

    public static void EnsureCreatedDB()
    {
        _context.Database.EnsureCreated();
    }

    public static void Create<T>(T obj) where T : class
    {
        _context.Set<T>().Add(obj);
        _context.SaveChanges();
    }
    
    public static void Update<T>(T obj) where T : class
    {
        _context.Set<T>().Update(obj);
        _context.SaveChanges();
    }
    
    public static void Delete<T>(T obj) where T : class
    {
        _context.Set<T>().Remove(obj);
        _context.SaveChanges();
    }
    
    

}