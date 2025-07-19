using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibrarySystem.BLL.Helpers
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Returns all validation errors for the object based on DataAnnotations.
        /// </summary>
        public static IList<ValidationResult> ValidateObject(this object obj)
        {
            var context = new ValidationContext(obj);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(obj, context, results, validateAllProperties: true);
            return results;
        }

        /// <summary>
        /// Converts validation errors to a formatted string summary.
        /// </summary>
        public static string ToErrorSummary(this IEnumerable<ValidationResult> results)
        {
            if (results == null || !results.Any())
                return null;
            if (results.Count() == 1)
                return results.First().ErrorMessage;
            return string.Join(Environment.NewLine, results.Select(r => "- " + r.ErrorMessage));
        }

        /// <summary>
        /// Returns error summary string if invalid; otherwise returns null.
        /// </summary>
        public static string ValidateAndGetErrors(this object obj)
        {
            var results = obj.ValidateObject();
            return results.Any() ? results.ToErrorSummary() : null;
        }
    }
}
