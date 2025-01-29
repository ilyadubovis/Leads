using Leads.Server.Data;
using Leads.Server.Models;
using Leads.Server.Repositories;
using Leads.Server.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Leads.Server.Test
{
    [TestClass]
    public class LeadServiceTest
    {
        private InMemoryDBContext? _dbContext;
        
        [TestInitialize]
        public void Initialize() 
        {
            _dbContext = new InMemoryDBContext(performInitialSeed: false);
        }
        
        [TestMethod]
        public void TestAddLead()
        { 
            var service = new LeadService(new LeadRepository(_dbContext!), Mock.Of<ILogger<LeadService>>());

            Assert.AreEqual(service.GetAllLeads().Count(), 0);
            
            var lead = service.AddLead(
                new Lead()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    PhoneNumber = "1234567890",
                    Email = "jdoe@abc.com",
                    StreetAddtress = "123 Main St",
                    City = "Los Angeles",
                    State = "CA",
                    ZipCode = "55555",
                    CanCommunicateViaEmail = true,
                    CanCommunicateViaText = true,
                    Comment = "Call after 2pm"
                });

            var leads = service.GetAllLeads().ToList();

            Assert.AreEqual(leads.Count(), 1);
            Assert.AreEqual(leads[0].Id, lead.Id);
        }

        [TestMethod]
        public void TestUpdateLead()
        {
            var service = new LeadService(new LeadRepository(_dbContext!), Mock.Of<ILogger<LeadService>>());

            Assert.AreEqual(service.GetAllLeads().Count(), 0);

            var lead = service.AddLead(
                new Lead()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    PhoneNumber = "1234567890",
                    Email = "jdoe@abc.com",
                    StreetAddtress = "123 Main St",
                    City = "Los Angeles",
                    State = "CA",
                    ZipCode = "55555",
                    CanCommunicateViaEmail = true,
                    CanCommunicateViaText = true,
                    Comment = "Call after 2pm"
                });

            var leads = service.GetAllLeads().ToList();

            Assert.AreEqual(leads.Count(), 1);

            var updatedLead = service.UpdateLead(lead.Id,
                new Lead()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    PhoneNumber = "888123456",
                    Email = "jdoe@abc.com",
                    StreetAddtress = "123 Main St",
                    City = "Los Angeles",
                    State = "CA",
                    ZipCode = "55555",
                    CanCommunicateViaEmail = true,
                    CanCommunicateViaText = true,
                    Comment = "Call after 2pm"
                });
            
            Assert.IsNotNull(updatedLead);

            Assert.AreEqual(leads.Count(), 1);

            Assert.AreEqual(leads[0].PhoneNumber, "888123456");
        }


        [TestMethod]
        public void TestDeleteLead()
        {
            var service = new LeadService(new LeadRepository(_dbContext!), Mock.Of<ILogger<LeadService>>());

            Assert.AreEqual(service.GetAllLeads().Count(), 0);

            var lead = service.AddLead(
                new Lead()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    PhoneNumber = "1234567890",
                    Email = "jdoe@abc.com",
                    StreetAddtress = "123 Main St",
                    City = "Los Angeles",
                    State = "CA",
                    ZipCode = "55555",
                    CanCommunicateViaEmail = true,
                    CanCommunicateViaText = true,
                    Comment = "Call after 2pm"
                });

            var leads = service.GetAllLeads().ToList();

            Assert.AreEqual(leads.Count(), 1);

            var result = service.DeleteLead(lead.Id);

            Assert.IsTrue(result);

            leads = service.GetAllLeads().ToList();

            Assert.AreEqual(leads.Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddLeadDuplicate()
        {
            var service = new LeadService(new LeadRepository(_dbContext!), Mock.Of<ILogger<LeadService>>());

            Assert.AreEqual(service.GetAllLeads().Count(), 0);

            var lead = service.AddLead(
                new Lead()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    PhoneNumber = "1234567890",
                    Email = "jdoe@abc.com",
                    StreetAddtress = "123 Main St",
                    City = "Los Angeles",
                    State = "CA",
                    ZipCode = "55555",
                    CanCommunicateViaEmail = true,
                    CanCommunicateViaText = true,
                    Comment = "Call after 2pm"
                });

            var leads = service.GetAllLeads().ToList();

            Assert.AreEqual(leads.Count(), 1);

            service.AddLead(
                new Lead()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    PhoneNumber = "1234567890",
                    Email = "jdoe@abc.com",
                    CanCommunicateViaEmail = true,
                    CanCommunicateViaText = true,
                });

        }
    }
}