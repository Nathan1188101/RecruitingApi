namespace RecruitingApi.Services; 
using RecruitingApi.Models;



// interface memebers are public by default 
public interface IRecruitingEventService
{
    // define the things the service will be doing 

    Task<RecruitingEvent[]> GetAllAsync();
    Task<RecruitingEvent?> GetRecruitingEventById(int Id);


}