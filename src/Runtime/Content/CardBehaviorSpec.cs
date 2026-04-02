using System.Collections.Generic;

namespace SpireLink.Runtime.Content;

public sealed record CardBehaviorSpec(
    string CardId,
    IReadOnlyList<EffectSpec> BaseEffects,
    IReadOnlyList<EffectSpec> UpgradedEffects
);
