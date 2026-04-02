namespace SpireLink.Runtime.Content;

public sealed record EventDescriptor(
    string Id,
    string LocalizationKey,
    string EventType,
    string DesignRole
);
