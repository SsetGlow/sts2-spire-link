using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems.Registry;

public sealed record RegisteredEventRuntime(
    string EventId,
    EventBehaviorSpec Behavior
);
