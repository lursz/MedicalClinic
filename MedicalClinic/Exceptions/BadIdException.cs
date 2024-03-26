namespace MedicalClinic.Exceptions;

public class BadIdException : Exception
{
    public BadIdException(string message) : base(message)
    {
    }
}