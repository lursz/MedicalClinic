
using MedicalClinic.DataBase.Connection;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic;

static class Program
{
    public static void Main(string[] args)
    {
        var context = new DataBase.Context(ConnString.DbConnectionString);
        context.Database.EnsureCreated();
        
        
        context.Database.Migrate();
    }
}