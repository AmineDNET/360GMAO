namespace GMAO.Domain.Entities;

public class Supplier
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? ContactEmail { get; private set; }

    private Supplier() { }

    private Supplier(Guid id, string name, string? email)
    {
        Id = id;
        Name = name;
        ContactEmail = email;
    }

    public static Supplier Create(Guid id, string name, string? email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        return new Supplier(id, name, email);
    }
}
