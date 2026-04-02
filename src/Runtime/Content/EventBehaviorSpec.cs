using System.Collections.Generic;

namespace SpireLink.Runtime.Content;

public sealed record EventBehaviorSpec(
    string EventId,
    IReadOnlyDictionary<string, IReadOnlyList<EffectSpec>> Options
);
