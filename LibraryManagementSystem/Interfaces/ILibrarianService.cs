﻿using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces;

internal interface ILibrarianService
{
    Librarian? GetLibrarianById(int id);
    Librarian[] GetAllLibrarians();
    void CreateLibrarian(Librarian librarian);
    void DeleteLibrarian(int id, bool isSoftDelete = true);
}
