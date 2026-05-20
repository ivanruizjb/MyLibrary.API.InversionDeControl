using MyLibrary.Domain.Entities;
using MyLibrary.Application.DTOs;
using MyLibrary.Application.Services.interfaces;

namespace MyLibrary.Application.Services;

public class BooksService : IBooksService
{
    private List<Book> _books = new();

    public BooksService()
    {
        _books = new List<Book>();
    }

    // POST
    public Book AddBook(BookDTO bookDTO)
    {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = bookDTO.Title,
            Author = bookDTO.Author
        };

        _books.Add(book);

        return book;
    }

    // GET
    public List<Book> GetBooks()
    {
        return _books;
    }

    // GET con filtro
    public Book? GetBookById(Guid id)
    {
        return _books.FirstOrDefault(x => x.Id == id);
    }

    // PUT
    public Book? UpdateBook(Guid id, BookDTO bookDTO)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);

        if (book == null)
            return null;

        book.Title = bookDTO.Title;
        book.Author = bookDTO.Author;

        return book;
    }

    // DELETE
    public bool DeleteBook(Guid id)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);

        if (book == null)
            return false;

        _books.Remove(book);

        return true;
    }
}