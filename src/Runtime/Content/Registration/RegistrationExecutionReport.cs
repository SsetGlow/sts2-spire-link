using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed record RegistrationExecutionReport(
    int CardCount,
    int RelicCount,
    int EventCount,
    IReadOnlyList<string> Steps
);
