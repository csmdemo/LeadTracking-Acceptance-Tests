using System;
using System.Collections.Generic;
using System.Linq;
using LeadTracking.Core.Data;
using LeadTracking.Data.Entities;
using Moq;

namespace LeadTracking.Tests.Core.Data
{
    public class TestData
    {
        public static List<ServiceInquiry> GetServiceInquiries()
        {
            var result = new List<ServiceInquiry>();
            var rand = new Random();
            for (var i = 0; i < 20; i++)
            {
                var item = new ServiceInquiry();
                item.CreatedOnUtc = DateTime.UtcNow.AddDays(i*-1);
                item.FirstName = $"FirstName{i}";
                item.LastName = $"LastName{i}";
                item.EmailAddress = $"{item.FirstName}.{item.LastName}@donotresolve.com";
                item.Inquiry = $"New Inquiry {i}";
                item.PrimaryPhoneNumber = $"{rand.Next(100, 999)}-{rand.Next(1000, 9990)}-{rand.Next(1000, 9990)}";
                if(i%3==0)
                    item.OfficePhoneNumber = $"{rand.Next(100, 999)}-{rand.Next(1000, 9990)}-{rand.Next(1000, 9990)}";
                if(i%6==0)
                    item.HomePhoneNumber = $"{rand.Next(100, 999)}-{rand.Next(1000, 9990)}-{rand.Next(1000, 9990)}";
                item.Key = Guid.NewGuid();
                result.Add(item);
            }
            return result;
        }

        public static IRepository<ServiceInquiry, Guid> GetMockServiceInquiryRepository(List<ServiceInquiry> backingCollection)
        {
            var mockRepo = new Mock<IRepository<ServiceInquiry, Guid>>();
            mockRepo.Setup(r => r.GetByKey(It.IsAny<Guid>()))
                .Returns((Guid id) => backingCollection.SingleOrDefault(x => x.Key == id));
            mockRepo.Setup(r => r.Insert(It.IsAny<ServiceInquiry>())).Callback((ServiceInquiry s) =>
            {
                s.Key = Guid.NewGuid();
                backingCollection.Add(s);
            });
            mockRepo.Setup(r => r.FindAll(It.IsAny<Predicate<ServiceInquiry>>()))
                .Returns((Predicate<ServiceInquiry> s) => backingCollection.FindAll(s));
            return mockRepo.Object;
        }
    }
}
