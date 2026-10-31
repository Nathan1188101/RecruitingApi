using Microsoft.AspNetCore.Mvc.Formatters;
using RecruitingApi.Models;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace RecruitingApi.Data
{
    /*
     *  Remember: 
     *  
     *  Static = can't instantiate an object of it
     *              just refer to it
     * 
     */
    public static class SeedData
    {
        // makes fixed size array (use List<T> if you want dynamic one)
        public static Occupation[] Occupations = [
            new() // classic is new Occupation(...), but new() is implicit this case (actually called target-typed)
            {
                Id = 1,
                Title = "Software Engineer",
                Category = "IT",
                IsFullTime = true,
            },
            new()
            {
                Id = 2,
                Title = "Backend Engineer",
                Category = "It",
                IsFullTime = true,

            },
            new()
            {
                Id = 3,
                Title = "Data Analyst",
                Category = "IT",
                IsFullTime = true,
            },
            new()
            {
                Id = 4,
                Title = "Janator",
                Category = "Maintenance",
                IsFullTime = true
            },
            new()
            {
                Id = 5,
                Title = "Marketing Agent",
                Category = "Marking",
                IsFullTime = true,
            },
            new()
            {
                Id = 6,
                Title = "Painter",
                Category = "Maintenance",
                IsFullTime = false,
            }
        ];

        public static Registration[] Registrations = [
            new() {Id = 1, RecruitingEventId = 1, Name = "Nathan", Email = "Nathan@test.com", Phone = null },
            new() {Id = 2, RecruitingEventId = 2, Name = "Bob", Email = "bob@bob.com", Phone = "705-123-1234"},
            new() {Id = 3, RecruitingEventId = 3, Name = "Ferb", Email = "Ferb@Ferb.com", Phone = null },
            new() {Id = 4, RecruitingEventId = 4, Name = "Tim", Email = "Tim@fart.com", Phone = null },
            new() {Id = 5, RecruitingEventId = 5, Name = "Bran", Email = "wineteriscoming@got.com", Phone = "123-456-7890"},
            new() {Id = 6, RecruitingEventId = 1, Name = "Mario", Email = "mario@mario&luigi.com", Phone = "127-742-7508" },
            new() {Id = 7, RecruitingEventId = 1, Name = "Link", Email = "link@hyrule.com", Phone = "742-723-8403" },
            new() {Id = 8, RecruitingEventId = 5, Name = "Bowser", Email = "bowser@koopa.ca", Phone = "234-840-9374" },
            new() {Id = 9, RecruitingEventId = 5, Name= "Wario", Email = "mario@mario&luigi.com", Phone = "748-838-2341" }, // duplicate email here (for testing) 
            new() {Id = 10, RecruitingEventId = 3, Name = "Patrick Jane", Email = "jane@wedabest.com", Phone = "7057483937" }
        ];

        public static RecruitingEvent[] RecruitingEvents = [
            new()
            {
                Id = 1,
                EventTitle = "HR Thing",
                Location = "Huntsville",
                Date = new DateTime(2026, 11, 15),
                Capacity = 5,
            },
            new()
            {
                Id = 2,
                EventTitle = "Corperate Jargon",
                Location = "Toronto",
                Date = new DateTime(2026, 11, 20),
                Capacity = 10,
            },
            new()
            {
                Id = 3,
                EventTitle = "Join the Military Now!",
                Location = "Barrie",
                Date =new DateTime(2026, 11, 21),
                Capacity = 22,
            },
            new()
            {
                Id = 4,
                EventTitle = "Stuff and Things",
                Location = "Missisauga",
                Date = new DateTime(2026, 11, 27),
                Capacity = 45,
            },
            new()
            {
                Id = 5,
                EventTitle = "Why you should Join.",
                Location = "Bracebridge",
                Date = new DateTime(2026, 11, 15),
                Capacity = 51,
            },
        ];

    }
}
