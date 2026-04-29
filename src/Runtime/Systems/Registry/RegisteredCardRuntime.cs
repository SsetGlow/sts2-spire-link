using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems.Registry;

public sealed record RegisteredCardRuntime(
    string CardId,
    CardBehaviorSpec Behavior,
    string[] BehaviorSummary
);
