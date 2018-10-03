using LeadTracking.Data.Entities;

namespace LeadTracking.Domain.Models.Mappers
{
    public static class ServiceInquiryMappers
    {
        public static ServiceInquiry MapFrom(this NewInquiry source)
        {
            var result = new ServiceInquiry();
            result.CreatedOnUtc = System.DateTime.UtcNow;
            result.EmailAddress = source.EmailAddress.Value;
            result.HomePhoneNumber = source.HomePhoneNumber;
            result.FirstName = source.InquiredBy.First;
            result.LastName = source.InquiredBy.Last;
            result.OfficePhoneNumber = source.OfficePhoneNumber;
            result.PrimaryPhoneNumber = source.BestPhoneNumber;
            return result;
        }
    }
}
