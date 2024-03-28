using System.Text.RegularExpressions;
using MedicalClinic.DataBase.Models;

namespace MedicalClinic;

public class SearchSystem
{
    private SearchRequirements Requirements;

    public void SetRequirements(string query)
    {
        Requirements = new SearchRequirements(query);
    }

    public List<Patient> Search(List<Patient> patients)
    {
        return patients.Where(patient => Requirements.Check(patient)).ToList();
    }
}



internal class SearchRequirements
{
    private StringRequirement Id { get; } = new();
    private StringRequirement FirstName { get; } = new();
    private StringRequirement LastName { get; } = new();
    private StringRequirement PESEL { get; } = new();
    private StringRequirement Gender { get; } = new();
    private StringRequirement Email { get; } = new();
    private StringRequirement City { get; } = new();
    private StringRequirement Street { get; } = new();
    private StringRequirement ZipCode { get; } = new();
    
    
    public SearchRequirements(string query)
    {
        // Format: string_key1:{regex1} int_key1:lower{lower1}:upper{upper1} string_key2:{regex2}

        // detects key:{value} for strings
        var stringRequirementRegex = new Regex(@"(\w+) *: *{(|.*?[^\\])}");
        // detects key:{value} for ints
        var intRequirementRegex = new Regex(@"(\w+)(?: *: *(?:lower *{(-?\d+)}|upper *{(-?\d+)})){1,2}");

        var stringMatches = stringRequirementRegex.Matches(query);
        var intMatches = intRequirementRegex.Matches(query);

        foreach (Match match in stringMatches)
            try
            {
                var key = match.Groups[1].Value;
                var value = match.Groups[2].Value.Replace("\\}", "}");

                switch (key)
                {
                    case "FirstName":
                        FirstName = new StringRequirement(value);
                        break;
                    case "LastName":
                        LastName = new StringRequirement(value);
                        break;
                    case "PESEL":
                        PESEL = new StringRequirement(value);
                        break;
                    case "Gender":
                        Gender = new StringRequirement(value);
                        break;
                    case "Email":
                        Email = new StringRequirement(value);
                        break;
                    case "City":
                        City = new StringRequirement(value);
                        break;
                    case "Street":
                        Street = new StringRequirement(value);
                        break;
                    case "ZipCode":
                        ZipCode = new StringRequirement(value);
                        break;
                }
            }
            catch
            {
            }
        
    }


    public bool Check(Patient patient)
    {
        if (!Id.Check(patient.Id.ToString())) return false;
        if (!FirstName.Check(patient.FirstName)) return false;
        if (!LastName.Check(patient.LastName)) return false;
        if (!PESEL.Check(patient.PESEL)) return false;
        if (!Gender.Check(patient.Gender)) return false;
        if (!Email.Check(patient.Email)) return false;
        if (!City.Check(patient.City)) return false;
        if (!Street.Check(patient.Street)) return false;
        if (!ZipCode.Check(patient.ZipCode)) return false;

        return true;
    }
}




internal class StringRequirement
{
    public StringRequirement(string value)
    {
        Value = value;
        Exists = 1;
    }

    public StringRequirement()
    {
        Exists = 0;
        Value = "";
    }

    public string Value { get; set; }
    public int Exists { get; set; }

    public bool Check(string value)
    {
        var regex = new Regex(Value);

        return regex.IsMatch(value);
    }
}

