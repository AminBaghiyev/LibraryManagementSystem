using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services.Interfaces;

internal interface ILibraryMemberService
{
    LibraryMember? GetLibraryMemberById(int id);
    List<LibraryMember> GetAllLibraryMembers();
    void CreateLibraryMember(LibraryMember libraryMember);
    void DeleteLibraryMember(int id, bool isSoftDelete = true);
}
