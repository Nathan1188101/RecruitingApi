using RecruitingApi.Validation;
using System.ComponentModel.DataAnnotations;

namespace RecruitingApi.Dtos;

public record RecruitingEventDto(int Id, string EventTitle, string Location, DateTime Date, int Capacity);

// DTO for create 
public record CreateRecruitingEventDto(
    [Required, MaxLength(100)] string EventTitle,
    [Required, MaxLength(100)] string Location,
    [Required, FutureDate] DateTime? Date,          // added ? to make it possible for a Date to be nullable, and FutureDate is custom validation attribute
    [Range(1, 1000)] int Capacity
    ); 

