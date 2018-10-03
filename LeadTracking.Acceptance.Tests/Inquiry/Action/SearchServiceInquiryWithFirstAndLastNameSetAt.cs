using System;
using System.Linq;
using LeadTracking.Core.Data;
using LeadTracking.Data.Entities;
using TechTalk.SpecFlow;

namespace LeadTracking.Acceptance.Tests.Inquiry.Action
{
    [Binding]
    public class SearchServiceInquiryWithFirstAndLastNameSetAt
    {
        [When(@"I perform a service inquiry search where first name is (.*) and last name is (.*)")]
        public void WhenIPerformAServiceInquirySearchWhereFirstNameIsAndLastNameIs(string p0, string p1)
        {
            var repo = ScenarioContext.Current.Get<IRepository<ServiceInquiry, Guid>>("service_inquiry_repository");
            var actual = repo.FindAll(x => x.FirstName == p0 && x.LastName == p1).ToList();
            ScenarioContext.Current.Add("service_iniquiry_search_results", actual);
        }
    }
}
