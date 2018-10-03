using System;
using System.Collections.Generic;
using System.Linq;
using LeadTracking.Core.Data;
using LeadTracking.Data.Entities;
using LeadTracking.Domain.Models;
using LeadTracking.Domain.Models.Mappers;
using LeadTracking.Tests.Core.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LeadTracking.Acceptance.Tests.Features
{
    [Binding]
    public class InquiryCreationSteps
    {
        /// <summary>
        /// Get a mock repository with data, assign it to kvp collection for test context
        /// </summary>
        [Given(@"I have a service inquiry repository")]
        public void GivenIHaveAServiceInquiryRepository()
        {
            var serviceInquiryList = TestData.GetServiceInquiries();
            var serviceInquiryRepository = TestData.GetMockServiceInquiryRepository(serviceInquiryList);
            ScenarioContext.Current.Add("service_inquiries", serviceInquiryList);
            ScenarioContext.Current.Add("service_inquiry_repository", serviceInquiryRepository);
        }
        /// <summary>
        /// Add table (step parameter) of inquiry information to context kvp. 
        /// </summary>
        /// <param name="table">Table (parameter) of personal information and inquiry defined in InquiryCreateFeature.feature</param>
        [Given(@"I have an inquiry about services from a person")]
        public void GivenIHaveAnInquiryAboutServicesFromAPerson(Table table)
        {
            dynamic personInquiryInformation = table.CreateDynamicInstance();
            ScenarioContext.Current.Add("person_service_inquiry_information", personInquiryInformation);
        }
        /// <summary>
        /// Uses the dynamic parameter representing inquiry information table, to create a NewInquiry record object.
        /// Inserts record into our mock repository
        /// </summary>
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

        /// <summary>
        /// Using "Well Known" string parameters representing firstname and lastname properties
        /// of a NewInquiry object that we created (that exists),
        /// find record in mock repository and save in context KVP
        /// </summary>
        /// <param name="p0">Represents FirstName</param>
        /// <param name="p1">Represents LastName</param>
        [When(@"I perform a service inquiry search where first name is ""(.*)"" and last name is ""(.*)""")]
        public void WhenIPerformAServiceInquirySearchWhereFirstNameIsAndLastNameIs(string p0, string p1)
        {
            var repo = ScenarioContext.Current.Get<IRepository<ServiceInquiry, Guid>>("service_inquiry_repository");
            var actual = repo.FindAll(x => x.FirstName == p0 && x.LastName == p1).ToList();
            ScenarioContext.Current.Add("service_iniquiry_search_results", actual);
        }
        /// <summary>
        /// Get a record from the mock repository using a key stored in our context
        /// representing record id, and assert that it exists.
        /// </summary>
        [Then(@"Record is saved in database")]
        public void ThenRecordIsSavedInDatabase()
        {
            var repo = ScenarioContext.Current.Get<IRepository<ServiceInquiry, Guid>>("service_inquiry_repository");
            var serviceInquiry = ScenarioContext.Current.Get<ServiceInquiry>("inserted_service_inquiry");
            var key = serviceInquiry.Key;
            var record = repo.GetByKey(key);
            Assert.IsInstanceOfType(record, typeof(ServiceInquiry));
        }
        /// <summary>
        /// Asserts that our mock repository contains data
        /// </summary>
        /// <param name="p0">Represents an integer for expected count of records in repository</param>
        [Then(@"Search results has count greater than (.*)")]
        public void ThenSearchResultsHasCountGreaterThan(int p0)
        {
            var searchResults = ScenarioContext.Current.Get<List<ServiceInquiry>>("service_iniquiry_search_results");
            Assert.IsTrue(searchResults.Count > p0);
        }
    }
}
