using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;
using MedicalClinic.Exceptions;

namespace MedicalClinic.Core;

internal static class PromptHub
{
    internal static void AddNewPatientPrompt()
    {
        Console.WriteLine("Enter patient first name: ");
        var firstName = Console.ReadLine();
        Console.WriteLine("Enter patient last name: ");
        var lastName = Console.ReadLine();
        Console.WriteLine("Enter patient PESEL: ");
        var pesel = Console.ReadLine();
        Console.WriteLine("Enter patient email: ");
        var email = Console.ReadLine();
        Console.WriteLine("Enter patient city: ");
        var city = Console.ReadLine();
        Console.WriteLine("Enter patient street: ");
        var street = Console.ReadLine();
        Console.WriteLine("Enter patient zip code: ");
        var zipCode = Console.ReadLine();

        var patient = new Patient(firstName, lastName, pesel, email, city, street, zipCode);
        DbHandler.Create(patient);
    }

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


    internal static void EditPatientPrompt()
    {
        Console.WriteLine("Enter patient id to edit: ");
        var id = Console.ReadLine();
        if (id == null) throw new InputException("Id cannot be empty");

        try
        {
            var patientId = int.Parse(id);
            var patient = DbHandler.Get<Patient>(patientId);
            var inputKey = ' ';
            do
            {
                Console.WriteLine("Edit patient menu");
                Console.WriteLine("[n] First Name");
                Console.WriteLine("[m] Last Name");
                Console.WriteLine("[p] PESEL");
                Console.WriteLine("[e] Email");
                Console.WriteLine("[c] City");
                Console.WriteLine("[s] Street");
                Console.WriteLine("[z] Zip code");
                Console.WriteLine("[q] Quit and save patient");
                inputKey = Console.ReadKey().KeyChar;
                switch (inputKey)
                {
                    case 'n':
                        Console.WriteLine("Enter new first name: ");
                        patient.FirstName = Console.ReadLine();
                        break;
                    case 'm':
                        Console.WriteLine("Enter new last name: ");
                        patient.LastName = Console.ReadLine();
                        break;
                    case 'p':
                        Console.WriteLine("Enter new PESEL: ");
                        patient.PESEL = Console.ReadLine();
                        break;
                    case 'e':
                        Console.WriteLine("Enter new email: ");
                        patient.Email = Console.ReadLine();
                        break;
                    case 'c':
                        Console.WriteLine("Enter new city: ");
                        patient.City = Console.ReadLine();
                        break;
                    case 's':
                        Console.WriteLine("Enter new street: ");
                        patient.Street = Console.ReadLine();
                        break;
                    case 'z':
                        Console.WriteLine("Enter new zip code: ");
                        patient.ZipCode = Console.ReadLine();
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (inputKey != 'q');

            DbHandler.Update(patient);
        }
        catch (FormatException)
        {
            throw new InputException("Id must be a number");
        }
        catch (PatientDatabaseException)
        {
            throw new InputException("Patient with id " + id + " does not exist");
        }
    }


    internal static void DeletePatientPrompt()
    {
        Console.WriteLine("Enter patient id to delete: ");
        var id = Console.ReadLine();

        if (id == null) throw new InputException("Id cannot be empty");

        try
        {
            var patientId = int.Parse(id);
            var patient = DbHandler.Get<Patient>(patientId);
            DbHandler.Delete(patient);
        }
        catch (FormatException)
        {
            throw new InputException("Id must be a number");
        }
        catch (PatientDatabaseException)
        {
            throw new InputException("Patient with id " + id + " does not exist");
        }
    }

    internal static void ChangePatientId(Patient patient)
    {
        Console.WriteLine("Enter id: ");
        var input_id = Console.ReadLine();

        if (input_id == null) throw new InputException("Id cannot be empty");

        try
        {
            patient.Id = int.Parse(input_id);
        }
        catch (FormatException)
        {
            throw new InputException("Id must be a number");
        }
    }

    internal static void SearchForPatient(Patient patient)
    {
        Console.WriteLine("Enter patient id to search for: ");
        var id = Console.ReadLine();

        if (id == null) throw new InputException("Id cannot be empty");

        try
        {
            var patientId = int.Parse(id);
            var foundPatient = DbHandler.Get<Patient>(patientId);
            Console.WriteLine(foundPatient);
        }
        catch (FormatException)
        {
            throw new InputException("Id must be a number");
        }
        catch (PatientDatabaseException)
        {
            throw new InputException("Patient with id " + id + " does not exist");
        }
    }

    internal static void ListAllPatients()
    {
        foreach (var patientId in DbHandler.GetAllIds()) Console.WriteLine(DbHandler.Get<Patient>(patientId));
    }
}