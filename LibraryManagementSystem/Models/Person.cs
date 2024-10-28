namespace LibraryManagementSystem.Models;

internal abstract class Person
{
    private static int _counter = 0;
    public int Id { get; set; }
    public string Name { get; set; }

    protected Person(string name)
    {
        Id = _counter++;
        Name = name;
    }
}
