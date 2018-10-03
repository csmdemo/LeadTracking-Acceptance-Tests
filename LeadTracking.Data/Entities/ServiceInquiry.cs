using System;
using LeadTracking.Core.Data;

namespace LeadTracking.Data.Entities
{
    public class ServiceInquiry:EntityBase<Guid>,IAuditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Inquiry { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastUpdateOnUtc { get; set; }
    }
}
