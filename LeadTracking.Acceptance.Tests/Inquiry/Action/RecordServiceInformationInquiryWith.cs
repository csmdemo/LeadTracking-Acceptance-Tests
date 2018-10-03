using System;
using LeadTracking.Core.Data;
using LeadTracking.Data.Entities;
using LeadTracking.Domain.Models;
using LeadTracking.Domain.Models.Mappers;
using TechTalk.SpecFlow;

namespace LeadTracking.Acceptance.Tests.Inquiry.Action
{
    [Binding]
    public class InquiryCreationSteps
    {
        [When(@"I record the service inquiry")]
        public void WhenIRecordTheServiceInquiry()
        {
            var serviceInquiryInformation =
                ScenarioContext.Current.Get<dynamic>("person_service_inquiry_information");
            NewInquiry record = NewInquiry.Create(
                serviceInquiryInformation.FirstName, 
                serviceInquiryInformation.LastName,
                serviceInquiryInformation.EmailAddress, 
                serviceInquiryInformation.OrganizationName,
                serviceInquiryInformation.Inquiry, 
                serviceInquiryInformation.PhoneNumber);
            var repo = ScenarioContext.Current.Get<IRepository<ServiceInquiry, Guid>>("service_inquiry_repository");
            var newServiceInquiry = record.MapFrom();
            repo.Insert(newServiceInquiry);
            ScenarioContext.Current.Add("inserted_service_inquiry", newServiceInquiry);
        }
    }
}
