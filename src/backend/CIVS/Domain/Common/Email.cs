using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Domain.Common;

public readonly record struct Email
{
    private readonly string _value;

    public string Value
    {
        get => _value;
        init
        {
            if (!IsValidEmail(value))
                throw new InvalidDataException();
            _value = value;
        }
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return MailAddress.TryCreate(email, out _);
    }

    public override string ToString() => _value;

    public static Email None => new Email { Value = "none@none.none" };
}