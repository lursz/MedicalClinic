using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;

namespace MedicalClinic.Core;

public class PatientLogic
{
    internal static void AddRandomPatientPrompt()
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

}



public class PatientEdit
{
    internal Patient Patient { get; }
    internal Patient Other { get; }

    public PatientEdit(Patient patient, Patient other)
    {
        Patient = patient;
        Other = other;
        Edit();
    }
    
    public Patient Edit()
    {
        Patient.FirstName = Other.FirstName ?? Patient.FirstName;
        Patient.LastName = Other.LastName ?? Patient.LastName;
        Patient.PESEL = Other.PESEL ?? Patient.PESEL;
        Patient.Email = Other.Email ?? Patient.Email;
        Patient.City = Other.City ?? Patient.City;
        Patient.Street = Other.Street ?? Patient.Street;
        Patient.ZipCode = Other.ZipCode ?? Patient.ZipCode;
        
        return Patient;
    }
    
}