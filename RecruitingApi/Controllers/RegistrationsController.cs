using Microsoft.AspNetCore.Mvc;
using RecruitingApi.Dtos;
using RecruitingApi.Services;

namespace RecruitingApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistrationsController(IRegistrationService registrations) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<RegistrationDto>>> GetAll()
    {
        var results = await registrations.GetAllAsync();

        return Ok(results);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RegistrationDto>> GetById(int id)
    {
        var result = await registrations.GetByIdAsync(id);

        return result is null ? NotFound() : Ok(result);
    }

    

}