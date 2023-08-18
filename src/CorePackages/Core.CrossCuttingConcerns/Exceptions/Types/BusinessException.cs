namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public BusinessException()
    {

    }

    public BusinessException(string? message) : base(message: message)
    {

    }

    public BusinessException(string? message, Exception? innerException) : base(message: message, innerException)
    {

    }
}