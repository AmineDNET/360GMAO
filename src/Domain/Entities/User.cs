using GMAO.Domain.Enums;
using GMAO.Domain.ValueObjects;

namespace GMAO.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public FullName Name { get; private set; }
    public Email Email { get; private set; }
    public UserRole Role { get; private set; }

    private User() { }

    private User(Guid id, FullName name, Email email, UserRole role)
    {
        Id = id;
        Name = name;
        Email = email;
        Role = role;
    }

    public static User Create(Guid id, FullName name, Email email, UserRole role)
        => new(id, name, email, role);
}
