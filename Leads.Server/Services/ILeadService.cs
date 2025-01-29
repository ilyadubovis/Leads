using Leads.Server.Models;

namespace Leads.Server.Services;

public interface ILeadService
{
    public IEnumerable<Lead> GetAllLeads();

    public Lead? GetLeadById(Guid leadId);

    public Lead AddLead(Lead lead);

    public Lead? UpdateLead(Guid leadId, Lead lead);

    public bool DeleteLead(Guid leadId);

    public bool SendEmail(Lead lead, string subject, string body);

    public bool SendTextMessage(Lead lead, string message);
}
