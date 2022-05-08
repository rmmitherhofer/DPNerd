using System.Text.RegularExpressions;

namespace DPNerd.Core.DomainObjects.ValueObjects;

public class Email
{
    public const int EmailAddressMaxLength = 254;
    public const int EmailAddressMinLength = 5;
    public string EmailAddress { get; private set; }

    // Construtor Entity Framework
    protected Email() { }

    public Email(string email)
    {
        if (!IsValid(email)) throw new DomainException("E-mail Inválido");
        EmailAddress = email;
    }

    public static bool IsValid(string email)
    {
        var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        return regexEmail.IsMatch(email);
    }
}
