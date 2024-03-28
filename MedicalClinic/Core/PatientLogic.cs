using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;

namespace MedicalClinic.Core;

public class PatientLogic
{
    internal static void AddRandomPatient()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";

        Random random = new();
        var randomName = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        var randomEmail = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
        var randomNumbers =
            new string(Enumerable.Repeat(numbers, 11).Select(s => s[random.Next(s.Length)]).ToArray());
        var patient = new Patient(randomName, randomName, randomNumbers, $"{randomEmail}@{randomEmail}.com", "city",
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
        // loop through each if not "" then set to new value, if "" then keep old value
        var patient = DbHandler.Get<Patient>(id);
        patient.FirstName = firstName != "" ? firstName : patient.FirstName;
        patient.LastName = lastName != "" ? lastName : patient.LastName;
        patient.PESEL = pesel != "" ? pesel : patient.PESEL;
        patient.Email = email != "" ? email : patient.Email;
        patient.City = city != "" ? city : patient.City;
        patient.Street = street != "" ? street : patient.Street;
        patient.ZipCode = zipCode != "" ? zipCode : patient.ZipCode;
        
        DbHandler.Update(patient);
    }
    

    // DbHandler.Update(patient);
        
    

}