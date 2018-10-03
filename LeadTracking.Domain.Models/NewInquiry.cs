using System;
using LeadTracking.Domain.Models.Common;

namespace LeadTracking.Domain.Models
{
    public class NewInquiry
    {
        public NewInquiry(PersonName inquiredBy, ValidEmailAddress emailAddress, string organizationName, string inquiryDescription, string bestPhoneNumber,string officePhoneNumber=null,string homePhoneNumber=null)
        {

            InquiredBy = inquiredBy ?? throw new ArgumentNullException(nameof(inquiredBy));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            if (string.IsNullOrWhiteSpace(organizationName))
                throw new ArgumentNullException(nameof(organizationName));
            if (string.IsNullOrWhiteSpace(inquiryDescription))
                throw new ArgumentNullException(inquiryDescription);
            if(string.IsNullOrWhiteSpace(bestPhoneNumber))
                throw new ArgumentNullException(nameof(bestPhoneNumber));
            OrganizationName = organizationName;
            InquiryDescription = inquiryDescription;
            BestPhoneNumber = bestPhoneNumber;
            OfficePhoneNumber = officePhoneNumber;
            HomePhoneNumber = homePhoneNumber;

        }
        public PersonName InquiredBy { get; }
        public string BestPhoneNumber { get; }
        public string OfficePhoneNumber {get;}
        public string HomePhoneNumber { get; }
        public ValidEmailAddress EmailAddress { get; }
        public string OrganizationName { get; }
        public string InquiryDescription { get; }

        public static NewInquiry Create(string firstName, string lastName, string emailAdress, string organizationName,
            string inquiryDescription, string bestPhoneNumber,string officePhoneNumber=null,string homePhoneNumber=null )
        {
            var personName = new PersonName(firstName, lastName);
            var validEmailAddress = new ValidEmailAddress(emailAdress);
            return new NewInquiry(personName, validEmailAddress, organizationName, inquiryDescription, bestPhoneNumber,
                homePhoneNumber);
        }
    
    }
}