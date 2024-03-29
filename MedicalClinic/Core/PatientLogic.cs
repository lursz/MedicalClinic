using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;

namespace MedicalClinic.Core;

public static class PatientLogic
{
    internal static void AddRandomPatient()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";

        Random random = new();
        var randomName = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        var randomEmail = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());
        var randomNumbers =
            new string(Enumerable.Repeat(numbers, 11).Select(s => s[random.Next(s.Length)]).ToArray());
        var patient = new Patient(randomName, randomName, randomNumbers, $"{randomEmail}@gmail.com", "city",
            "street", "12-456");

        DbHandler.Create(patient);
    }
    
    internal static void AddPatient(Patient patient)
    {
        DbHandler.Create(patient);
    }

    internal static void EditPatient(int id, String firstName, String lastName, String pesel, String email, String city,
        String street, String zipCode)
    {
        var patient = DbHandler.Get<Patient>(id);
        patient.FirstName = firstName != "" ? firstName : patient.FirstName;
        patient.LastName = lastName != "" ? lastName : patient.LastName;
        patient.Pesel = pesel != "" ? pesel : patient.Pesel;
        patient.Email = email != "" ? email : patient.Email;
        patient.City = city != "" ? city : patient.City;
        patient.Street = street != "" ? street : patient.Street;
        patient.ZipCode = zipCode != "" ? zipCode : patient.ZipCode;
        
        DbHandler.Update(patient);
    }

    internal static void AddFewGuys()
    {
        DbHandler.Create(new Patient("John", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
        DbHandler.Create(new Patient("Fred", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
        DbHandler.Create(new Patient("Barny", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
        DbHandler.Create(new Patient("Wilson", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
    }
    

}