namespace MedicalClinic.Exceptions;

internal class InputException : Exception
{
    public InputException(string message) : base(message)
    {
    }
}