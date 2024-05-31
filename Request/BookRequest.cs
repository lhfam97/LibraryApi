namespace LibraryApi.Request;

public class BookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public float Price { get; set; }
    public int Amount { get; set; }
}
