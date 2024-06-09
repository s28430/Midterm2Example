using System.Runtime.Serialization;

namespace GagoExampleTest.Exceptions;

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException()
    {
    }

    protected ClientNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ClientNotFoundException(string? message) : base(message)
    {
    }

    public ClientNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}