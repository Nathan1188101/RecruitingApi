using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RecruitingApi.Data.Converters;
using RecruitingApi.Models;

namespace RecruitingApi.Data; 

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)   // don't forget constructor on appdbcontext itself. Without it we can't register and set it up in program.cs, also lose the whole DI aspect lol
{
    // DbSet<T> is a table 
    public DbSet<RecruitingEvent> RecruitingEvents => Set<RecruitingEvent>();
    public DbSet<Occupation> Occupations => Set<Occupation>();
    public DbSet<Registration> Registrations => Set<Registration>();


    // global EF rule to handle loss of timezone label (Kind label, 3 options = Utc, Local, or Unspecified)
    // this ensures that any DateTime in any table is automatically treated as UTC when EF fetches it
    // from tables to API fetches 
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // will add on the UTC tag at the end of a DateTime once in memory because in the db it loses that.
        configurationBuilder.Properties<DateTime>().HaveConversion<UtcDateTimeConverter>(); //
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
 
}