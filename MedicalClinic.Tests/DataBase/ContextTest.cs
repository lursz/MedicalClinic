using System.Linq;
using JetBrains.Annotations;
using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Connection;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MedicalClinic.Tests.DataBase;

public class ContextTest
{
    public ContextTest()
    {
        DbHandler.EnsureCreatedDB();
    }

    [Fact]
    public void test_ConnectToDb()
    {
        var context = new Context(ConnString.DbConnectionString);
        Assert.NotNull(context);
    }
    
    [Fact]
    public void test_EnsureDbGetsCreated()
    {
        var context = new Context(ConnString.DbConnectionString);
        Assert.False(context.Database.EnsureCreated()); //returns false if db already exists
    }
    
    [Fact]
    public void test_MigrateDb()
    {
        var context = new Context(ConnString.DbConnectionString);
        context.Database.Migrate();
        
        Assert.True(context.Database.GetPendingMigrations().Count() == 0);
    }
    
    
}