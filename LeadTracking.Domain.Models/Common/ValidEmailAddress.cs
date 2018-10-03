using System;
using System.Text.RegularExpressions;

namespace LeadTracking.Domain.Models.Common
{
    public sealed class ValidEmailAddress
    {
        public string Value { get; }

        public ValidEmailAddress(string value)
        {
            if (!Regex.IsMatch(value,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase))
                throw new FormatException("Invalid email address");
            Value = value;
        }
    }
}
