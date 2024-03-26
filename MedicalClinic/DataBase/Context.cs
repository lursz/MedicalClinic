using MedicalClinic.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic.DataBase;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    private readonly string _connectionString;

    public Context(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}