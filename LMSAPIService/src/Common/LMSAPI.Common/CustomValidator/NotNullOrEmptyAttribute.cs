using System;
using System.ComponentModel.DataAnnotations;

namespace LMSAPI.Common.CustomValidator
{
    public class NotNullOrEmptyAttribute : RequiredAttribute
    {
        public readonly string _message;
        public NotNullOrEmptyAttribute(string message)
        {
            _message = message;
        }
        public override bool IsValid(object value)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(value)))
            {
                return true;
                //return ValidationResult.Success;
            }
            return false;
        }
    }
}
