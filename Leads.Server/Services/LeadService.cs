using Leads.Server.Models;
using Leads.Server.Repositories;

namespace Leads.Server.Services;

public class LeadService(ILeadRepositiry repository, ILogger<LeadService> logger) : ILeadService
{
    public IEnumerable<Lead> GetAllLeads() =>
        repository.GetAllLeads();

    public Lead? GetLeadById(Guid leadId) =>
        repository.GetLeadById(leadId);

    public Lead AddLead(Lead lead) =>
        repository.AddLead(lead);

    public Lead? UpdateLead(Guid id, Lead lead) =>
        repository.UpdateLead(id, lead);

    public bool DeleteLead(Guid leadId) =>
        repository.DeleteLead(leadId);

    public bool SendEmail(Lead lead, string subject, string body)
    {
        if(lead.Email is not null && lead.CanCommunicateViaEmail)
        {
            logger.LogInformation($"Email with subject {subject} and body {body} has been sent to {lead.Email}.");
            return true;
        }
        return false;
    }

    public bool SendTextMessage(Lead lead, string message)
    {
        if (lead.CanCommunicateViaText)
        {
            logger.LogInformation($"Text message {message} has been sent to {lead.PhoneNumber}.");
            return true;
        }
        return false;
    }
}
