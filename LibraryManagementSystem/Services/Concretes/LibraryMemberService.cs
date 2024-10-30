using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services.Concretes;

internal class LibraryMemberService : ILibraryMemberService
{
    private List<LibraryMember> _members;

    public LibraryMemberService()
    {
        _members = [];
    }

    public void CreateLibraryMember(LibraryMember libraryMember)
    {
        _members.Add(libraryMember);
    }

    public void DeleteLibraryMember(int id, bool isSoftDelete = true)
    {
        if (isSoftDelete)
        {
            for (int i = 0; i < _members.Count; i++)
                if (_members[i].Id == id) _members[i].IsSoftDelete = true;

            return;
        }

        List<LibraryMember> updatedLibrarians = [];

        for (int i = 0; i < _members.Count; i++)
        {
            if (_members[i].Id != id) updatedLibrarians.Add(_members[i]);
        }

        _members = updatedLibrarians;
    }

    public List<LibraryMember> GetAllLibraryMembers() => _members;

    public LibraryMember? GetLibraryMemberById(int id)
    {
        foreach (var member in _members)
            if (member.Id == id) return member;

        return null;
    }
}
