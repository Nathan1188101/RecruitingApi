using RecruitingApi.Dtos;

namespace RecruitingApi.Services; 

public interface IOccupationService
{
    Task<List<OccupationDto>> GetAllAsync(); 
    Task<OccupationDto?> GetByIdAsync(int id);
    Task<List<OccupationDto?>> GetAllFullTimeAsync(); 

}