using System.Collections.Generic;
using LeadTracking.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace LeadTracking.Acceptance.Tests.Inquiry.Consequence
{
    [Binding]
    public class ServiceInquirySearchResultsHasCountGreaterThan
    {
        [Then(@"Search results has count greater than (.*)")]
        public void ThenSearchResultsHasCountGreaterThan(int p0)
        {
            var searchResults = ScenarioContext.Current.Get<List<ServiceInquiry>>("service_iniquiry_search_results");
            Assert.IsTrue(searchResults.Count > p0);
        }
    }
}
