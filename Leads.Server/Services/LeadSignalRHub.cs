using Microsoft.AspNetCore.SignalR;

namespace Leads.Server.Services;

public class LeadSignalRHub : Hub
{
    public async Task LeadCreated(Guid leadId) =>
        await Clients.All.SendAsync("LeadCreated", leadId);

    public async Task LeadUpdated(Guid leadId) =>
        await Clients.All.SendAsync("LeadUpdated", leadId);

    public async Task LeadDeleted(Guid leadId) =>
        await Clients.All.SendAsync("LeadDeleted", leadId);
}
