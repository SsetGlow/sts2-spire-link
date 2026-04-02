using System.Collections.Generic;

namespace SpireLink.Runtime.Content;

public sealed record RelicBehaviorSpec(
    string RelicId,
    string Trigger,
    IReadOnlyList<EffectSpec> Effects
);
