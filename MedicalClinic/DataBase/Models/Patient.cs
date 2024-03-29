using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Terminal.Gui;

namespace MedicalClinic.DataBase.Models;

public class Patient
{
    
    public Patient(string firstName, string lastName, string pesel, string email, string city, string street,
        string zipCode)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(pesel) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) ||
            string.IsNullOrEmpty(zipCode))
        {
            MessageBox.ErrorQuery("Null fields", "Some fields are nulls", "Ok");
            return;
        }
        
        FirstName = firstName;
        LastName = lastName;
        Pesel = CheckPesel(pesel) ? pesel : throw new ArgumentException("Invalid PESEL format");
        Email = CheckEmail(email) ? email : throw new ArgumentException("Invalid email format");
        City = city;
        Street = street;
        ZipCode = CheckZipCode(zipCode) ? zipCode : throw new ArgumentException("Invalid zip code format");
        Gender = Pesel[9] % 2 == 0 ? "Female" : "Male";
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] public string Pesel { get; set; }

    public string Gender { get; set; }

    [Required] public string Email { get; set; }

    [Required] public string City { get; set; }

    [Required] public string Street { get; set; }

    [Required] public string ZipCode { get; set; }


    public override string ToString()
    {
        return
            $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, PESEL: {Pesel}, Gender: {Gender}, Email: {Email}, City: {City}, Street: {Street}, ZipCode: {ZipCode}";
    }

    public string ToNewLineString()
    {
        return
            $"Id: {Id}\nFirstName: {FirstName}\nLastName: {LastName}\nPESEL: {Pesel}\nGender {Gender} \nEmail: {Email}\nCity: {City}\nStreet: {Street}\nZipCode: {ZipCode}";
    }

    private bool CheckZipCode(string zipCode)
    {
        var pattern = @"^\d{2}-\d{3}$";
        return Regex.IsMatch(zipCode, pattern);
    }

    private bool CheckPesel(string pesel)
    {
        var pattern = @"^\d{11}$";
        return Regex.IsMatch(pesel, pattern);
    }

    private bool CheckEmail(string email)
    {
        var pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        return Regex.IsMatch(email, pattern);
    }
    
    public static List<String> ReturnNamesOfAllColumns()
    {
        return new List<string>
            { "Id", "FirstName", "LastName ", "PESEL", "Gender", "Email", "City", "Street", "ZipCode" };
    }
}