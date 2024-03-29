using System;
using JetBrains.Annotations;
using MedicalClinic.DataBase.Models;
using Xunit;

namespace MedicalClinic.Tests.DataBase.Models;

[TestSubject(typeof(Patient))]
public class PatientTest
{

    [Fact]
    public void test_NullFirstName()
    {
        Assert.Throws<NullReferenceException>(() =>
            new Patient(null, "Doe", "12345678901", null, "Warsaw", "Marszalkowska", "00-000"));
    }
    
    [Fact]
    public void test_EmailRegex()
    {
        Assert.Throws<ArgumentException>(() =>
            new Patient("John", "Doe", "12345678901", "wrongemail", "Warsaw", "Marszalkowska", "00-000"));
    }

    [Fact]
    public void test_PESELRegex()
    {
        Assert.Throws<ArgumentException>(() =>
            new Patient("John", "Doe", "1234567890", "email@gmail.com", "Warsaw", "Marszalkowska", "00-000"));
    }

    [Fact]
    public void test_ZipCodeRegex()
    {
        Assert.Throws<ArgumentException>(() =>
            new Patient("John", "Doe", "12345678901", "mail@gmail.com", "Warsaw", "Marszalkowska", "00000"));
    }

    [Fact]
    public void test_GenderChecker()
    {
        var testPatient = new Patient("John", "Doe", "12345678901", "mail@email.com", "Warsaw", "Marszalkowska", "00-000");
        Assert.Equal("Male", testPatient.Gender);
    }
    

}