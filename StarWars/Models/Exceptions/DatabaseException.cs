namespace StarWars.Models.Exceptions;

public class DatabaseException : ApplicationException
{
    public DatabaseException(string message) : base(message) { }
}