using System;
using JetBrains.Annotations;
using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;
using Xunit;

namespace MedicalClinic.Tests.DataBase;

public class DbHandlerTest : IDisposable
{
    public DbHandlerTest()
    {
        DbHandler.EnsureCreatedDB();
        DbHandler.MigrateDB();
    }

    [Fact]
    public void test_EnsureDbGetsCreated()
    {
        Assert.True(DbHandler.EnsureCreatedDB());
    }
    
    [Fact]
    public void test_Create()
    {
        var testPatient1 = new Patient ("John", "Doe", "12345678901", "john@sdd.com", "Warsaw", "Marszalkowska", "00-000");
        var testPatient2 = new Patient("Fred", "Doe", "12345678123", "fred@sdd.com", "Warsaw", "Marszalkowska", "00-000");
        
        DbHandler.Create(testPatient1);
        DbHandler.Create(testPatient2);
        
        var testPatient1FromDb = DbHandler.GetPatients().Find(p => p.PESEL == "12345678901");
        var testPatient2FromDb = DbHandler.GetPatients().Find(p => p.PESEL == "12345678123");
        
        Assert.Equal(testPatient1, testPatient1FromDb);
        Assert.Equal(testPatient2, testPatient2FromDb);
    }

    [Fact]
    public void test_Update()
    {
        var testPatient = new Patient("Barney", "Johnson", "12444478123", "barny@gmail.com", "Warsaw", "Marszalkowska",
            "00-000");
        DbHandler.Create(testPatient);

        testPatient.FirstName = "Adam";
        testPatient.LastName = "Smith";
        DbHandler.Update(testPatient);

        var testPatientFromDb = DbHandler.GetPatients().Find(p => p.PESEL == "12444478123");
        Assert.Equal("Adam", testPatientFromDb.FirstName);
        Assert.Equal("Smith", testPatientFromDb.LastName);
    }
    
    [Fact]
    public void test_Delete()
    {
        var testPatient = new Patient("Delete", "Me", "12000008123", "deleteme@gamil.com", "Warsaw", "Marszalkowska", "00-000");
        DbHandler.Create(testPatient);
        DbHandler.Delete(testPatient);
        Assert.DoesNotContain(testPatient, DbHandler.GetPatients());
    }
        






    public void Dispose() {}
}