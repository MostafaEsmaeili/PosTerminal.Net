
using PosTerminal.Net.Application.Common.Interfaces;

namespace PosTerminal.Net.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
