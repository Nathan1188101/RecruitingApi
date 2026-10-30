using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using RecruitingApi.Dtos;
using RecruitingApi.Services;

namespace RecruitingApi.Controllers;

[Route("api/[controller]")] //'controller' gets filled by class name of the controller (minus 'controller')
[ApiController]
public class OccupationsController(IOccupationService occupations) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OccupationDto>>> GetAll()
    {
        var jobs = await occupations.GetAllAsync();

        return Ok(jobs); // will always return (even if no jobs, should still return an empty list which still is success) 
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OccupationDto>> GetById(int id)
    {
        var job = await occupations.GetByIdAsync(id);

        return job is null ? NotFound() : job; 
    }

    [HttpGet("fulltime")]
    public async Task<ActionResult<List<OccupationDto>>> GetAllFullTime()
    {
        var jobs = await occupations.GetAllFullTimeAsync(); 

        return Ok(jobs);
    }

}