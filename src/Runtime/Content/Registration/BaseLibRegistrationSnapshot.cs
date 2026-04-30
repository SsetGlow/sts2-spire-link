using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed record BaseLibRegistrationSnapshot(
    int CardCount,
    int RelicCount,
    int EventCount,
    IReadOnlyList<string> PlannedSteps
);
