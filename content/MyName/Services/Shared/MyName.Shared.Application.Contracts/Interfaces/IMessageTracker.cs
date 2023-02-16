using MyName.Shared.Application.Contracts.Enums;

namespace MyName.Shared.Application.Contracts.Interfaces;

public interface IMessageTracker
{
    TrackerKind Kind { get; }
    Task<bool> HasProcessedAsync(long eventId, string trackerName);
    Task MarkAsProcessedAsync(long eventId, string trackerName);
}