using System.ComponentModel.DataAnnotations;

namespace RecruitingApi.Models;

public class RecruitingEvent
{
    public int Id { get; set; }

    [Required]
    public string EventTitle { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public DateTime Date { get; set; }

    // making the relationship between the two bidirectional 
    public List<Registration> Registrations = []; // remember this just effects the C# side of things (doesn't change db tables in anyway...)

}

