using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services.Concretes;

internal class LibrarianService : ILibrarianService
{
    private List<Librarian> _librarians;

    public LibrarianService()
    {
        _librarians = [];
    }

    public void CreateLibrarian(Librarian librarian)
    {
        _librarians.Add(librarian);
    }

    public void DeleteLibrarian(int id, bool isSoftDelete = true)
    {
        if (isSoftDelete)
        {
            for (int i = 0; i < _librarians.Count; i++)
                if (_librarians[i].Id == id) _librarians[i].IsSoftDelete = true;

            return;
        }

        List<Librarian> updatedLibrarians = [];

        for (int i = 0; i < _librarians.Count; i++)
        {
            if (_librarians[i].Id != id) updatedLibrarians.Add(_librarians[i]);
        }

        _librarians = updatedLibrarians;
    }

    public List<Librarian> GetAllLibrarians() => _librarians;

    public Librarian? GetLibrarianById(int id)
    {
        foreach (var librarian in _librarians)
            if (librarian.Id == id) return librarian;

        return null;
    }
}
