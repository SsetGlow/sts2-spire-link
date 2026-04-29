using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems.Registry;

public sealed record RegisteredRelicRuntime(
    string RelicId,
    RelicBehaviorSpec Behavior
);
