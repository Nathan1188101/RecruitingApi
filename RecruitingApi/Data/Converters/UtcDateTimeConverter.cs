using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RecruitingApi.Data.Converters;

public class UtcDateTimeConverter() : ValueConverter<DateTime, DateTime>(
    // constructor? 
    toDb => toDb,
    fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc) // will come out 'Unspecified' and not format correctly for front end and so on if not doing this here 
    );