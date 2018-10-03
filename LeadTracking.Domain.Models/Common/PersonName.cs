using System;

namespace LeadTracking.Domain.Models.Common
{
    public sealed class PersonName
    {
     

        public PersonName(string first, string last)
        {
            if (String.IsNullOrEmpty(first))
                throw new ArgumentNullException(nameof(first));
            if (string.IsNullOrEmpty(last))
                throw new ArgumentNullException(nameof(last));
            First = first;
            Last = last;
        }
        public string First {get;}

        public string Last { get; }

        public override string ToString()
        {
            return $"{First} {Last}";
        }

        public static bool TryCreate(string first, string last, out PersonName personName)
        {
            personName = default(PersonName);
            if (!(!string.IsNullOrWhiteSpace(first) & !string.IsNullOrWhiteSpace(last))) return false;
            personName = new PersonName(first, last);
            return true;
        }
    }
}