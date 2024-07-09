using System.Diagnostics.CodeAnalysis;
using Project4.Application.Interfaces.Services;

namespace Project4.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}
