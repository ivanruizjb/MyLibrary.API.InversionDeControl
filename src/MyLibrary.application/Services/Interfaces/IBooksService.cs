using MyLibrary.Application.DTOs;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Application.Services.interfaces;

public interface IBooksService
{
    Book AddBook(BookDTO bookDTO);

    List<Book> GetBooks();

    Book? GetBookById(Guid id);

    Book? UpdateBook(Guid id, BookDTO bookDTO);

    bool DeleteBook(Guid id);
}