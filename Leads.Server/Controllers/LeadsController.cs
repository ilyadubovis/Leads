using AutoMapper;
using Leads.Server.Models;
using Leads.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Leads.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeadsController(ILeadService leadService, IMapper mapper) : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<LeadViewModel>> GetAllLeads() =>
        Ok(leadService.GetAllLeads().Select(x => mapper.Map<LeadViewModel>(x)));

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<LeadDetailsViewModel> GetLeadById(Guid id)
    {
        var lead = leadService.GetLeadById(id);
        if (lead is null)
        {
            return NotFound($"The lead with id {id} was not found.");
        }

        return Ok(mapper.Map<LeadDetailsViewModel>(lead));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult CreateLead([FromBody] LeadInputViewModel leadInputViewModel)
    {
        try
        {
            var lead = mapper.Map<Lead>(leadInputViewModel);
            lead.Id = Guid.NewGuid();
            var createdLead = leadService.AddLead(lead);

            leadService.SendTextMessage(createdLead, "Welcome. An agent will call you soon.");
            leadService.SendEmail(createdLead, "Welcome", "An agent will call you soon.");

            return CreatedAtAction("CreateLead", new { id = createdLead.Id }, createdLead);
        }
        catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Lead> UpdateLead(Guid id, [FromBody] LeadInputViewModel leadInputViewModel)
    {
        var lead = mapper.Map<Lead>(leadInputViewModel);
        var updatedLead = leadService.UpdateLead(id, lead);
        if (updatedLead is null)
        {
            return BadRequest($"A lead with the Id {id} does not exist.");
        }

        return Ok(updatedLead);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult DeleteLead(Guid id)
    {
        if (leadService.DeleteLead(id))
        {
            return Ok();
        }

        return BadRequest($"A lead with the Id {id} does not exist.");
    }
}
