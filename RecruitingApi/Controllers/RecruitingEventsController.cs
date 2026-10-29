using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using RecruitingApi.Dtos;
using RecruitingApi.Services;

/*
 *  The class is grouping together related endpoints. 
 *  
 *  each method inside the class is an endpoint. 
 * 
 */

namespace RecruitingApi.Controllers;

[Route("api/[controller]")]
[ApiController] // gives automatic model validation with 400 responses, body binding inference, and API explorer visibility for OpenApi
public class RecruitingEventsController(IRecruitingEventService RecruitingEvents) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RecruitingEventDto>>> GetAll() //ActionResult<> lets us return http codes and or raw data types 
    {
        var events = await RecruitingEvents.GetAllAsync();

        return Ok(events); // even if no events, will return empty list which isn't null 
        
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecruitingEventDto>> GetById(int id)
    {
        var RecruitingEvent = await RecruitingEvents.GetRecruitingEventById(id);

        // single liner 
        return RecruitingEvent is null ? NotFound() : Ok(RecruitingEvent);
    }
}

