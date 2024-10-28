using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Models;

internal class LibrarianService : ILibrarianService
{
    private Librarian[] _librarians;

    public LibrarianService()
    {
        _librarians = [];
    }

    public void CreateLibrarian(Librarian librarian)
    {
        Array.Resize(ref _librarians, _librarians.Length + 1);
        _librarians[^1] = librarian;
    }

    public void DeleteLibrarian(int id, bool isSoftDelete = true)
    {
        if (isSoftDelete)
        {
            for (int i = 0; i < _librarians.Length; i++)
                if (_librarians[i].Id == id) _librarians[i].IsSoftDelete = true;

            return;
        }
        
        Librarian[] updatedLibrarians = new Librarian[_librarians.Length - 1];
        int count = 0;

        for (int i = 0; i < _librarians.Length; i++)
        {
            if (_librarians[i].Id != id) updatedLibrarians[count++] = _librarians[i];
        }

        _librarians = updatedLibrarians;
    }

    public Librarian[] GetAllLibrarians() => _librarians;

    public Librarian? GetLibrarianById(int id)
    {
        foreach (var librarian in _librarians)
            if (librarian.Id == id) return librarian;

        return null;
    }
}
