// implementation of the interface 
using RecruitingApi.Models;
using RecruitingApi.Data;
using RecruitingApi.Dtos; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace RecruitingApi.Services;

// DTOs at the edges, entities accessed within the services (implementations) 

public class RecruitingEventService(AppDbContext db) : IRecruitingEventService
{
    public async Task<List<RecruitingEventDto>> GetAllAsync()
    {

        //var events = await db.RecruitingEvents.ToListAsync();
        var events = await db.RecruitingEvents.Select(e =>
                            new RecruitingEventDto(e.Id, e.EventTitle, e.Location, e.Date, e.Capacity)).ToListAsync(); 

        // convert result qeury list into DTO list 
        var list = new List<RecruitingEventDto>();
        foreach (var e in events)
        {
            list.Add(new RecruitingEventDto(e.Id, e.EventTitle, e.Location, e.Date, e.Capacity));
        }

        return events; 

    }

    public async Task<RecruitingEventDto?> GetRecruitingEventById(int Id)
    {
        var result = await db.RecruitingEvents.FirstOrDefaultAsync(t => t.Id == Id);

        if (result == null)
            return null; 

        var dto = new RecruitingEventDto(result.Id, result.EventTitle, result.Location, result.Date, result.Capacity);


        return dto; 
    }

}