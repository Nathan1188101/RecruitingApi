namespace RecruitingApi.Dtos;

public record RegistrationDto(int Id, int RecruitingEventId, string Name, string Email, string? Phone); 
