using Microsoft.EntityFrameworkCore;
using RecruitingApi.Data;
using RecruitingApi.Dtos;
using RecruitingApi.Models; 

namespace RecruitingApi.Services; 

public class OccupationService(AppDbContext db) : IOccupationService
{
    public async Task<List<OccupationDto>> GetAllAsync()
    {
        var occupations = await db.Occupations.Select(o =>
                            new OccupationDto(o.Id, o.Title, o.Category, o.IsFullTime)).ToListAsync();


        return occupations; 
    }

    public async Task<OccupationDto?> GetByIdAsync(int id)
    {
        var occupation = await db.Occupations.FirstOrDefaultAsync(o => o.Id == id);

        if (occupation == null)
        {
            return null; 
        }

        var dto = new OccupationDto(occupation.Id, occupation.Title, occupation.Category, occupation.IsFullTime);

        return dto; 

    }


    public async Task<List<OccupationDto>> GetAllFullTimeAsync()
    {
        var fulltime = await db.Occupations
            .Where(o => o.IsFullTime == true) // filter
            .Select(o => new OccupationDto(   // map to DTO
                o.Id,
                o.Title,
                o.Category,
                o.IsFullTime
                ))
            .ToListAsync();                   // run query 

        return fulltime;

    }


}