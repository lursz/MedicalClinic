using MedicalClinic.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DataBase;

public class Context : DbContext
{
    private readonly string _connectionString;

    public Context(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}