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
    private IntRequirement Id { get; } = new();
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

        foreach (Match match in intMatches)
            try
            {
                var key = match.Groups[1].Value;

                var lowerExists = match.Groups[2].Success;
                Console.WriteLine(match.Groups[2].Value);
                var lower = lowerExists ? int.Parse(match.Groups[2].Value) : 0;

                var upperExists = match.Groups[3].Success;
                var upper = upperExists ? int.Parse(match.Groups[3].Value) : 0;

                switch (key)
                {
                    case "Id":
                        Id = new IntRequirement(lower, upper);
                        break;
                }
            }
            catch
            {
            }
    }


    public bool Check(Patient patient)
    {
        if (!Id.Check(patient.Id)) return false;
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




internal class IntRequirement
{
    public IntRequirement(int lower, int upper)
    {
        Lower = lower;
        Upper = upper;
        LowerExists = 1;
        UpperExists = 1;
    }

    public IntRequirement()
    {
        LowerExists = 0;
        UpperExists = 0;

        Lower = 0;
        Upper = 0;
    }

    public int LowerExists { get; set; }
    public int Lower { get; set; }
    public int UpperExists { get; set; }
    public int Upper { get; set; }

    public bool Check(int value)
    {
        if (LowerExists == 1 && value < Lower) return false;

        if (UpperExists == 1 && value > Upper) return false;

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

