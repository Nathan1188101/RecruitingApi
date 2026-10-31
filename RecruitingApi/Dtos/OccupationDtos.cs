using System.ComponentModel.DataAnnotations;

namespace RecruitingApi.Dtos;
public record OccupationDto(int Id, string Title, string Category, bool IsFullTime);

// DTO for creation (POST) 
public record CreateOccupationDto(
    [Required, MaxLength(100)] string Title,
    [Required, MaxLength(100)] string Category,
    bool IsFullTime
    );

