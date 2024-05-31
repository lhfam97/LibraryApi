using LibraryApi.Request;

namespace LibraryApi.Domain;

public class Book(BookRequest bookRequest)
{

    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = bookRequest.Title;
    public string Author { get; set; } = bookRequest.Author;
    public string Gender { get; set; } = bookRequest.Gender;
    public float Price { get; set; } = bookRequest.Price;
    public int Amount { get; set; } = bookRequest.Amount;
}
