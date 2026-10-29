using System.ComponentModel.DataAnnotations;

namespace RecruitingApi.Models; 

public class Registration
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty; // sets column and gets rid of compiler warning 

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress] 
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    // Foreign Key
    public int RecruitingEventId { get; set; } // don't need [Required] on this, int inheritnely can't be null already so the column by default will be set to NOT NULL. 

    // ref navigation property for it 
    public RecruitingEvent RecruitingEvent { get; set; } = null!; // null! tells the compiler this will be filled 



}