using System.ComponentModel.DataAnnotations;

namespace RecruitingApi.Dtos;

public record RegistrationDto (int Id, int RecruitingEventId, string Name, string Email, string? Phone);

/*
 * The are Validation Attributes on each field 
 * 
 * [ApiController] uses these for the incoming request DTO
 * 
 * So if there is a bad request, automatic 400 before the method runs 
 * 
 * remeber that the CreateDto should only include what the user chooses, so no Id because we don't want them touching or messing with that. DB will handle that itself 
 * 
 *
 */
public record CreateRegistrationDto (
    [Range(1, int.MaxValue)] int RecruitingEventId,
    [Required, MaxLength(100)] string Name,
    [Required, EmailAddress] string Email,
    [Phone] string? Phone
    );
