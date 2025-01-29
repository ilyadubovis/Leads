using System.ComponentModel.DataAnnotations;

namespace Leads.Server.Models;

/// <summary>
/// Lead model expected at LeadsController end points
/// </summary>
public class LeadInputViewModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string ZipCode { get; set; } = string.Empty;

    [Required]
    public bool CanCommunicateViaEmail { get; set; }

    [Required]
    public bool CanCommunicateViaText { get; set; }

    // optional properties

    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(50)]
    public string StreetAddtress { get; set; } = string.Empty;

    [MaxLength(20)]
    public string City { get; set; } = string.Empty;

    [MaxLength(20)]
    public string State { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Comment { get; set; } = string.Empty;
}

