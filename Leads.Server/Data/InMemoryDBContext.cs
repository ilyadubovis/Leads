using Leads.Server.Models;

namespace Leads.Server.Data;

public class InMemoryDBContext
{
    public HashSet<Lead> Leads { get; set; } = [];

    public InMemoryDBContext(bool performInitialSeed = true)
    {
        // simulate existing leads
        if (performInitialSeed && Leads.Count == 0)
        {
            SeedLeads();
        }
    }

    private void SeedLeads()
    {
        Leads = [
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
            },
            new Lead()
            {
                Id = Guid.NewGuid(),
                Name = "Mary Smith",
                PhoneNumber = "8888888888",
                StreetAddtress = "456 3rd Ave",
                City = "New York",
                State = "NY",
                ZipCode = "11111",
                CanCommunicateViaEmail = false,
                CanCommunicateViaText = true
            },
            new Lead()
            {
                Id = Guid.NewGuid(),
                Name = "Joe Smith",
                PhoneNumber = "9999999999",
                ZipCode = "22222-0002",
                CanCommunicateViaEmail = false,
                CanCommunicateViaText = true,
                Comment = "Service is needed ASAP"
            }
        ];
    }
}
