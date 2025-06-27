
using System.Net.Mail;
using ddd_object_calisthenics_web_api.shared.exceptions;

namespace ddd_object_calisthenics_web_api.domain.primitives;

public sealed class Email
{
    public string Address { get; }

    private Email(string address)
    {
        Address = address;
    }

     public static Email Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            throw new BadRequestException("invalid email");

        try
        {
            var addr = new MailAddress(address);
            if (!addr.Address.Equals(address.Trim(), StringComparison.OrdinalIgnoreCase))
                throw new BadRequestException("invalid email");
        }
        catch
        {
            throw new BadRequestException("invalid email");
        }

        var normalized = address.Trim().ToLowerInvariant();
        return new Email(normalized);
    }

    public override bool Equals(object? obj) =>
        obj is Email email && Address == email.Address;

    public override int GetHashCode() => Address.GetHashCode();

    public override string ToString() => Address;

    public static implicit operator string(Email email) => email.Address;
}
