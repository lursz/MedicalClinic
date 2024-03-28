using MedicalClinic.DataBase.Connection;
using MedicalClinic.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DataBase;

public static class DbHandler
{
    private static readonly Context _context = new(ConnString.DbConnectionString);

    public static void MigrateDB()
    {
        _context.Database.Migrate();
    }

    public static bool EnsureCreatedDB()
    {
        return _context.Database.EnsureCreated();
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

    public static T Get<T>(int id) where T : class
    {
        return _context.Set<T>().Find(id);
    }

    public static void Clear()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public static List<int> GetAllIds()
    {
        return _context.Patients.Select(p => p.Id).ToList();
    }
    
    public static List<Patient> GetPatients()
    {
        return _context.Patients.ToList();
    }
    
}