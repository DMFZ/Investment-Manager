using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Manager.Helpers
{
    internal sealed class ValidateObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result;
            if (value != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(value, null, null);

                result = Validator.TryValidateObject(value, context, results, true) ?
                    ValidationResult.Success :
                    new CompositeValidationResult(validationContext.DisplayName, results);
            }
            else
            {
                result = ValidationResult.Success;
            }

            return result;
        }

        private sealed class CompositeValidationResult : ValidationResult
        {
            private readonly IEnumerable<ValidationResult> _results;
            private readonly string _propertyName;

            public CompositeValidationResult(string propertyName, IEnumerable<ValidationResult> results)
                : base(string.Format("The {0} field is invalid.", propertyName))
            {
                _propertyName = propertyName;
                _results = results;
            }

            public override string ToString()
            {
                string nestedMessages = string.Join(Environment.NewLine, _results.Select(result => result.ToString()));
                return "The " + _propertyName + " field is invalid {" + Environment.NewLine + nestedMessages + " }";
            }
        }
    }
}