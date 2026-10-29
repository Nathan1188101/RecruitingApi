namespace RecruitingApi.Models;

/*
 *  this is an Entity - EF Core will map this class to a db table
 *  
 *  every public property becomes a column.
 *  
 *  attributes can be  added to fields as well
 *  
 *  SIDE NOTE: 
 *  - Seed data should use Models, not DTOs cause the seed data is going in the db, so they should match defs basically
 */

public class Occupation
{
    public int Id { get; set; }       // primary key 

    public string Title { get; set; } = string.Empty; // must provide non null value for compiler. We've stated in the first part of the variable def that it will never be null, but then we never gave it a value. So we give it a starting non null value. Makes the warning go away 

    public string Category { get; set; } = string.Empty; // Another reason this is important is for migrations/schema. This decides/tells what the database column is going to be. This would be like "Category navchar(max) NOT NULL 

    public bool IsFullTime { get; set; }

    

}

