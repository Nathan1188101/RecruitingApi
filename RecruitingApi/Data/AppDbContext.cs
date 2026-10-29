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


    // apparently this is optional. EF Core will still build your tables from your models 
    // only use this for things the conventions can't work out, or changing what they decided...
    /*
    * a good habit: 
    * 
    * everytime you change something here you should run a new migration. 
    * 
    * for bigger projects: 
    * 
    * - you'll see each entities configuration put into it's own class that implements IEntityTypeConfiguration<T>
    *   then load them all using modelBuilder.ApplyConfigurationsFromAssembly(...). 
    * - this keeps OnModelCreate short
    * 
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // main reason we need it right now is for the seed data 

        modelBuilder.Entity<Occupation>().HasData(SeedData.Occupations);
        modelBuilder.Entity<RecruitingEvent>().HasData(SeedData.RecruitingEvents);
        modelBuilder.Entity<Registration>().HasData(SeedData.Registrations);

        // optional extras, good to know 
        modelBuilder.Entity<Occupation>()
            .Property(o => o.EventTitle)
            .HasMaxLength(200);             // nvarchar(200) instead of nvarchar(max) which is default (wasteful) 


        modelBuilder.Entity<Registration>()
            .HasIndex(r => new {r.Email, r.RecruitingEventId}) // building composite index (pre-sroted list of combined columns for fast look ups)
            .IsUnique();       


    }
 
}