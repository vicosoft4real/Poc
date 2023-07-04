namespace Core.Entity;

public class Title: EntityBase<Guid>
{
    public Title(string name) : base(Guid.NewGuid())
    {
        Name = name;
    }
    private Title() : base(Guid.NewGuid())
    { }

    public string Name { get; private set; } = null!;

    public ICollection<Teacher> Teachers { get; private set; } = new List<Teacher>();
}