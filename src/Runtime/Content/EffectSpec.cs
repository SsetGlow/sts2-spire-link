namespace SpireLink.Runtime.Content;

public sealed record EffectSpec(
    EffectSpecType Type,
    int Value = 0,
    int SecondaryValue = 0,
    string? Target = null,
    string? Condition = null,
    string? Payload = null
);
