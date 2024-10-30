namespace LibraryManagementSystem.Models;

internal abstract class LibraryItem
{
    private static int _counter = 0;
    public int Id { get; }
    public string Title { get; set; }
    public DateTime? PublicationYear { get; set; }

    public bool IsSoftDelete { get; set; }

    protected LibraryItem(string title, DateTime? publicationYear)
    {
        Id = _counter++;
        Title = title;
        PublicationYear = publicationYear;
    }

    public abstract void DisplayInfo();
}
