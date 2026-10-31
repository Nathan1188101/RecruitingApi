using RecruitingApi.Dtos; 

namespace RecruitingApi.Services; 

// stop forgetting...
/*
 *  STOP FORGETTING!!! 
 *  
 *  DTOs at the edges -> entities/models within the service implementation 
 *  
 *  
 *  So we need to make these accept and return DTOs 
 *  
 *  
 *  OMGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG
 */

public interface IRegistrationService
{
    Task<List<RegistrationDto>> GetAllAsync();

    Task<RegistrationDto?> GetByIdAsync(int id);

    Task<RegistrationDto> CreateAsync(CreateRegistrationDto dto); 
    
}