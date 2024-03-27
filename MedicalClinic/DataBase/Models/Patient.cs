using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace MedicalClinic.DataBase.Models;

public class Patient
{
    public Patient()
    {
    }


    public Patient(string firstName, string lastName, string pesel, string email, string city, string street,
        string zipCode)
    {
        // Id = id;
        FirstName = firstName;
        LastName = lastName;
        PESEL = checkPESEL(pesel) ? pesel : throw new ArgumentException("Invalid PESEL format");
        Email = checkEmail(email) ? email : throw new ArgumentException("Invalid email format");
        City = city;
        Street = street;
        ZipCode = checkZipCode(zipCode) ? zipCode : throw new ArgumentException("Invalid zip code format");
        Gender = PESEL[10] % 2 == 0 ? "Female" : "Male";
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] public string PESEL { get; set; }

    public string Gender { get; set; }

    [Required] public string Email { get; set; }

    [Required] public string City { get; set; }

    [Required] public string Street { get; set; }

    [Required] public string ZipCode { get; set; }


    public override string ToString()
    {
        return
            $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, PESEL: {PESEL}, Gender: {Gender}, Email: {Email}, City: {City}, Street: {Street}, ZipCode: {ZipCode}";
    }

    private bool checkZipCode(string zipCode)
    {
        var pattern = @"^\d{2}-\d{3}$";
        return Regex.IsMatch(zipCode, pattern);
    }

    private bool checkPESEL(string pesel)
    {
        var pattern = @"^\d{11}$";
        return Regex.IsMatch(pesel, pattern);
    }

    private bool checkEmail(string email)
    {
        var pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        return Regex.IsMatch(email, pattern);
    }
    
    public static List<String> returnNamesOfAllColumns()
    {
        return new List<string>
            { "Id", "FirstName", "LastName ", "PESEL", "Gender", "Email", "City", "Street", "ZipCode" };
    }
}