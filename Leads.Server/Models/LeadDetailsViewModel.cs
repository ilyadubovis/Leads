namespace Leads.Server.Models;

/// <summary>
/// Detailed Lead properties
/// Model to communicate an individual lead details
/// </summary>
public class LeadDetailsViewModel : LeadViewModel
{
    public string? Email { get; set; }

    public string StreetAddtress { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;

    public bool CanCommunicateViaEmail { get; set; }

    public bool CanCommunicateViaText { get; set; }
}
