using System.Text.RegularExpressions;

namespace GMAO.Domain.ValueObjects;

public sealed record Email
{
    private static readonly Regex EmailRegex = new(
        "^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required", nameof(email));
        if (!EmailRegex.IsMatch(email))
            throw new ArgumentException("Invalid email format", nameof(email));
        return new Email(email);
    }

    public override string ToString() => Value;
}
