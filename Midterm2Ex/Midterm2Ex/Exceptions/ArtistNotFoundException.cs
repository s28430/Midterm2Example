using System.Runtime.Serialization;

namespace Midterm2Ex.Exceptions;

public class ArtistNotFoundException : Exception
{
    public ArtistNotFoundException()
    {
    }

    protected ArtistNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ArtistNotFoundException(string? message) : base(message)
    {
    }

    public ArtistNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}