using RecruitingApi.Dtos;

namespace RecruitingApi.Services; 

public interface IOccupationService
{
    Task<List<OccupationDto>> GetAllAsync(bool? fullTime); 
    Task<OccupationDto?> GetByIdAsync(int id);
    Task<List<OccupationDto?>> GetAllFullTimeAsync(); 

}