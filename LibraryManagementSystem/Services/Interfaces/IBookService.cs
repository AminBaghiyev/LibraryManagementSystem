using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.Interfaces;

internal interface IBookService
{
    Book? GetBookById(int id);
    List<Book> GetAllBooks();
    void AddBook(Book book);
    void DeleteBook(int id, bool isSoftDelete = true);
}
