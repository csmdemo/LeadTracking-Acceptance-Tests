using LeadTracking.Tests.Core.Data;
using TechTalk.SpecFlow;

namespace LeadTracking.Acceptance.Tests.Inquiry.Context
{
    [Binding]
    public class GivenServiceInquiryRepositorySetAt
    {
        [Given(@"I have a service inquiry repository")]
        public void GivenIHaveAServiceInquiryRepository()
        {
            var serviceInquiryList = TestData.GetServiceInquiries();
            var serviceInquiryRepository = TestData.GetMockServiceInquiryRepository(serviceInquiryList);
            ScenarioContext.Current.Add("service_inquiries", serviceInquiryList);
            ScenarioContext.Current.Add("service_inquiry_repository", serviceInquiryRepository);
        }
    }
}
