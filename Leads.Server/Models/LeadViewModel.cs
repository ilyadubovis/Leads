namespace Leads.Server.Models;

/// <summary>
/// Basic lead properties
/// Model to communicate basic lead properties (for bulk lead response)
/// </summary>
public class LeadViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

}
