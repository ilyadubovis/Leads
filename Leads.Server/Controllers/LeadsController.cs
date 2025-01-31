using AutoMapper;
using Leads.Server.Models;
using Leads.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Leads.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeadsController(ILeadService leadService, IMapper mapper, LeadSignalRHub leadHub) : Controller
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateLead([FromBody] LeadInputViewModel leadInputViewModel)
    {
        try
        {
            var lead = mapper.Map<Lead>(leadInputViewModel);
            lead.Id = Guid.NewGuid();
            var createdLead = leadService.AddLead(lead);

            leadService.SendTextMessage(createdLead, "Welcome. An agent will call you soon.");
            leadService.SendEmail(createdLead, "Welcome", "An agent will call you soon.");

            await leadHub.LeadCreated(createdLead.Id);

            return CreatedAtAction("CreateLead", new { id = createdLead.Id }, createdLead);
        }
        catch (ArgumentException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Lead>> UpdateLead(Guid id, [FromBody] LeadInputViewModel leadInputViewModel)
    {
        var lead = mapper.Map<Lead>(leadInputViewModel);
        var updatedLead = leadService.UpdateLead(id, lead);
        if (updatedLead is null)
        {
            return BadRequest($"A lead with the Id {id} does not exist.");
        }

        await leadHub.LeadUpdated(updatedLead.Id);

        return Ok(updatedLead);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteLead(Guid id)
    {
        if (leadService.DeleteLead(id))
        {
            await leadHub.LeadDeleted(id);
            return Ok();
        }

        return BadRequest($"A lead with the Id {id} does not exist.");
    }
}
