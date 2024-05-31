namespace LibraryApi.Exceptions;

public class BookAlreadyExistsException : Exception
{
    public BookAlreadyExistsException() { }

    public BookAlreadyExistsException(string message)
        : base(message) { }

    public BookAlreadyExistsException(string message, Exception inner)
        : base(message, inner) { }
}
