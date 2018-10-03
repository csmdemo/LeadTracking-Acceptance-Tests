using System;
using LeadTracking.Core.Data;
using LeadTracking.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace LeadTracking.Acceptance.Tests.Inquiry.Consequence
{
    [Binding]
    public class ServiceInquiryExitsInDatabase
    {
        [Then(@"Record is saved in database")]
        public void ThenRecordIsSavedInDatabase()
        {
            var repo = ScenarioContext.Current.Get<IRepository<ServiceInquiry, Guid>>("service_inquiry_repository");
            var serviceInquiry = ScenarioContext.Current.Get<ServiceInquiry>("inserted_service_inquiry");
            var key = serviceInquiry.Key;
            var record = repo.GetByKey(key);
            Assert.IsInstanceOfType(record, typeof(ServiceInquiry));
        }
    }
}
