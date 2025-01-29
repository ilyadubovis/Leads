namespace Leads.Server.Models;

public class Lead : LeadInputViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public override bool Equals(object? other)
    {
        var otherLead = other as Lead;
        if(otherLead is null) return false;
        
        // try to compare emails first
        if (Email is not null)
        {
            return Email.Equals(otherLead.Email);
        }

        // if email comparison is impossible, compare phone numbers
        return PhoneNumber.Equals(otherLead.PhoneNumber);
    }

    public override int GetHashCode() =>
        Email?.GetHashCode() ?? PhoneNumber.GetHashCode();
}

