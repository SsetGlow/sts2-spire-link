using System.Collections.Generic;

namespace SpireLink.Runtime.Systems.Preview;

public sealed record RegistrationSnapshot(
    int CardCount,
    int RelicCount,
    int EventCount,
    IReadOnlyList<string> PreviewLines
);
