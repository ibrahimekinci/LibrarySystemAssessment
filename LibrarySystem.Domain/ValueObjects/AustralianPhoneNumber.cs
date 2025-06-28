using System;
using System.Text.RegularExpressions;

namespace LibrarySystem.Domain.ValueObjects
{
    public class AustralianPhoneNumber
    {
        public string Value { get; private set; }

        public AustralianPhoneNumber(string value)
        {
            Value = value;
        }

        public ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                return ValidationResult.Failure("Phone number cannot be empty.");

            // Accepts formats like 0412345678, +61412345678
            if (!Regex.IsMatch(Value, @"^(\+614|04)\d{8}$"))
                return ValidationResult.Failure("Invalid Australian mobile phone number.");

            return ValidationResult.Success();
        }

        public override string ToString() => Value;
    }
}
