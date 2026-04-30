using System.Collections.Generic;
using SpireLink.Runtime.Content.Registration;

namespace SpireLink.Runtime.Systems.Preview;

public sealed record RegistrationSnapshot(
    int CardCount,
    int RelicCount,
    int EventCount,
    IReadOnlyList<string> PreviewLines,
    BaseLibRegistrationSnapshot BaseLibSnapshot
);
