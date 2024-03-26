namespace MedicalClinic.Exceptions;

public class PatientDatabaseException : Exception
{
    public PatientDatabaseException(string message) : base(message)
    {
    }
}