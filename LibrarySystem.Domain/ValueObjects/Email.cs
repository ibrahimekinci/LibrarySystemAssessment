using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            Value = value;
        }

        public ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                return ValidationResult.Failure("Email cannot be empty.");

            if (!Regex.IsMatch(Value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return ValidationResult.Failure("Invalid email format.");

            return ValidationResult.Success();
        }

        public override string ToString() => Value;
    }
}
