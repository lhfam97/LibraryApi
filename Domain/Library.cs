namespace LibraryApi.Domain;

public class Library(string id, string name)
{
    public string Id { get; set; } = id;

    public string Name { get; set; } = name;

    public List<Book> Books { get; set; } = [];
}
