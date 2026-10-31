using Microsoft.EntityFrameworkCore;
using RecruitingApi.Data;
using RecruitingApi.Dtos;
using RecruitingApi.Models;
using System.Reflection;

namespace RecruitingApi.Services;

public class RegistrationService(AppDbContext db) : IRegistrationService
{
    public async Task<List<RegistrationDto>> GetAllAsync()
    {
        var regs = await db.Registrations
            .Select(r => new RegistrationDto(r.Id, r.RecruitingEventId, r.Name, r.Email, r.Phone))
            .ToListAsync();

        return regs; 
    }

    public async Task<RegistrationDto?> GetByIdAsync(int id)
    {
        var reg = await db.Registrations.FirstOrDefaultAsync(r => r.Id == id);

        if (reg == null)
            return null;

        var dto = new RegistrationDto(reg.Id, reg.RecruitingEventId, reg.Name, reg.Email, reg.Phone); 

        return dto; 


    }

    public async Task<RegistrationDto> CreateAsync(CreateRegistrationDto dto)
    {
        var registration = new Registration
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone, 
            RecruitingEventId = dto.RecruitingEventId,

        }

        db.Registrations.Add(registration);

        await db.SaveChangesAsync();          // the database assigns the Id here

        return new OccupationDto(registration.Id, registration.Title, registration.Category, registration.IsFullTime); // we return this to check it? Does the controller use this?
    }

}