using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LeadTracking.Acceptance.Tests.Inquiry.Context
{
    [Binding]
    public class PersonServiceInquiryInformationWith
    {
        [Given(@"I have an inquiry about services from a person")]
        public void GivenIHaveAnInquiryAboutServicesFromAPerson(Table table)
        {
            dynamic personInquiryInformation = table.CreateDynamicInstance();
            ScenarioContext.Current.Add("person_service_inquiry_information", personInquiryInformation);
        }
    }
}
