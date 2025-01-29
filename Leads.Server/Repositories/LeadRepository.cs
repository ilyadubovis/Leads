using Leads.Server.Data;
using Leads.Server.Models;

namespace Leads.Server.Repositories;

public class LeadRepository(InMemoryDBContext dbContext) : ILeadRepositiry
{
    public IEnumerable<Lead> GetAllLeads() =>
        [.. dbContext.Leads];


    public Lead? GetLeadById(Guid leadId) =>
        dbContext.Leads.SingleOrDefault(x => x.Id == leadId);

    public Lead AddLead(Lead lead)
    {
        if (dbContext.Leads.Add(lead))
        {
            return lead;
        }
        throw new Exception("A lead with the given email and/or phone number already exists.");
    }

    public Lead? UpdateLead(Guid leadId, Lead lead)
    {
        var existingLead = GetLeadById(leadId);
        if(existingLead is not null)
        {
            existingLead.Name = lead.Name;
            existingLead.PhoneNumber = lead.PhoneNumber;
            existingLead.Email = lead.Email;
            existingLead.ZipCode = lead.ZipCode;
            existingLead.CanCommunicateViaText = lead.CanCommunicateViaText;
            existingLead.CanCommunicateViaEmail = lead.CanCommunicateViaEmail;
        }
        return existingLead;
    }

    public bool DeleteLead(Guid leadId) =>
        dbContext.Leads.RemoveWhere(x => x.Id == leadId) > 0;
}
