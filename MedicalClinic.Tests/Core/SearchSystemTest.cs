using System;
using JetBrains.Annotations;
using MedicalClinic;
using MedicalClinic.DataBase.Models;
using Xunit;

namespace MedicalClinic.Tests.Core;

[TestSubject(typeof(SearchSystem))]
public class SearchSystemTest : IDisposable
{
    public SearchSystemTest()
    {
    }

    [Fact]
    public void Test_Check1()
    {
        SearchRequirements searchRequirements1 = new SearchRequirements("FirstName: {jan}");
        new SearchRequirements("FirstName: {jan} LastName: {kowalski} Pesel: {12345678901}");

        Patient patient1 = new Patient("jan", "kowalski", "12345678901", "elo@gmail.com", "Warsaw", "Marszalkowska",
            "00-000");


        Assert.True(searchRequirements1.Check(patient1));
    }

    [Fact]
    public void Test_Check2()
    {
        SearchRequirements searchRequirements2 = new SearchRequirements("LastName: {kowalski}");

        Patient patient2 = new Patient("jan", "kowalski", "12345678901", "elo@gmail.com", "Warsaw", "Marszalkowska",
            "00-000");
        Assert.True(searchRequirements2.Check(patient2));
    }

    [Fact]
    public void Test_Check3()
    {
        SearchRequirements searchRequirements3 = new SearchRequirements("FirstName: {jan} LastName: {kowalski}");
        Patient patient3 = new Patient("jan", "kowalski", "12345678901", "elo@gmail.com", "Warsaw", "Marszalkowska",
            "00-000");
        Assert.True(searchRequirements3.Check(patient3));
    }

    [Fact]
    public void Test_Check4()
    {
        SearchRequirements searchRequirements4 =
            new SearchRequirements("FirstName: {jan} LastName: {kowalski} Pesel: {12345678901}");
        Patient patient4 = new Patient("jan", "kowalski", "12345000001", "elo@gmail.com", "Warsaw", "Marszalkowska",
            "00-000");
        Assert.True(searchRequirements4.Check(patient4));
    }


    public void Dispose()
    {
    }
}