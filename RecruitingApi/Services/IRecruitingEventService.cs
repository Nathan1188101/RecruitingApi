namespace RecruitingApi.Services; 
using RecruitingApi.Models;
using RecruitingApi.Dtos; 



// interface memebers are public by default 
public interface IRecruitingEventService
{
    // define the things the service will be doing 

    Task<List<RecruitingEventDto>> GetAllAsync(); 
    Task<RecruitingEventDto?> GetRecruitingEventById(int Id);
    
}