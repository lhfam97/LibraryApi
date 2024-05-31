using LibraryApi.Domain;
using LibraryApi.Exceptions;
using LibraryApi.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{

    public static Library library = new Library(id: "1", name: "Book Store");

    // GET: api/<BookController>
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok(library.Books);
    }

    // GET api/<BookController>/5
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        Book? selectedBook = library.Books.Find(book => book.Id == id);
        if (selectedBook != null)
        {
            return Ok(selectedBook);
        }

        return NotFound("");
    }

    // POST api/<BookController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] BookRequest bookRequest)
    {
        // Check if book exists by title and author
        bool bookExists = library.Books.Exists(book => bookRequest.Title.Equals(book.Title) && bookRequest.Author.Equals(book.Author));
        if (bookExists)
        {
            return BadRequest(new BookAlreadyExistsException("Book Already Exists"));
        }

        Book newBook = new Book(bookRequest);

        library.Books.Add(newBook);

        return Created(newBook.Id, newBook);
    }

    //// PUT api/<BookController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put(string id, BookRequest bookRequest)
    {
        Book? selectedBook = library.Books.Find(book => id.Equals(book.Id));
        if (selectedBook != null)
        {
            selectedBook.Author = bookRequest.Author;
            selectedBook.Title = bookRequest.Title;
            selectedBook.Gender = bookRequest.Gender;
            selectedBook.Price = bookRequest.Price;
            selectedBook.Amount = bookRequest.Amount;
            return Ok(selectedBook);
        }

        return NotFound();

    }

    // DELETE api/<BookController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(string id)
    {
        Book? selectedBook = library.Books.Find(book => id.Equals(book.Id));
        if (selectedBook != null)
        {
            library.Books.Remove(selectedBook);
            return NoContent();
        }

        return NotFound();
    }
}
