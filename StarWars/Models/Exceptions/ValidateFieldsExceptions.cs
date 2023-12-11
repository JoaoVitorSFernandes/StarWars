namespace StarWars.Models.Exceptions;

public class ValidateFieldsExceptions : ApplicationException
{
    public ValidateFieldsExceptions(string message) : base(message) { }
}