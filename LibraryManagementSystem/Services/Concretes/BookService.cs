using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services.Concretes;

internal class BookService : IBookService
{
    private List<Book> _books;

    public BookService()
    {
        _books = [];
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void DeleteBook(int id, bool isSoftDelete = true)
    {
        if (isSoftDelete)
        {
            for (int i = 0; i < _books.Count; i++)
                if (_books[i].Id == id) _books[i].IsSoftDelete = true;

            return;
        }

        List<Book> updatedBooks = [];

        for (int i = 0; i < _books.Count; i++)
        {
            if (_books[i].Id != id) updatedBooks.Add(_books[i]);
        }

        _books = updatedBooks;
    }

    public List<Book> GetAllBooks() => _books;

    public Book? GetBookById(int id)
    {
        foreach (var book in _books)
            if (book.Id == id) return book;

        return null;
    }
}
