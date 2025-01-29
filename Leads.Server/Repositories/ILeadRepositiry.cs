using Leads.Server.Models;

namespace Leads.Server.Repositories;

public interface ILeadRepositiry
{
    public IEnumerable<Lead> GetAllLeads();

    public Lead? GetLeadById(Guid leadId);

    public Lead AddLead(Lead lead);

    public Lead? UpdateLead(Guid leadId, Lead lead);

    public bool DeleteLead(Guid leadId);
}
