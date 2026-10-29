// implementation of the interface 

namespace RecruitingApi.Services;

using RecruitingApi.Models;
using RecruitingApi.Data;

public class RecruitingEventService : IRecruitingEventService
{
    public Task<RecruitingEvent[]> GetAllAsync()
    {
        // just return all the RecruitingEvents 
        // oh I need actual data, will set up migrations (dbcontext yatta yatta, soon)

        var events = SeedData.RecruitingEvents;

        return Task.FromResult(events); // need to wrap this in a completed task to satifsfy return type for now (we have data synchronsly for now so)

    }

    public Task<RecruitingEvent> GetRecruitingEventById(int Id)
    {
        var thing = SeedData.RecruitingEvents.FirstOrDefault(t => t.Id == Id);

        return Task.FromResult(thing); 
    }
}