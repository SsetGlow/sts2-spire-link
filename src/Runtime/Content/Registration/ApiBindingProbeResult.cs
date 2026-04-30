using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed record ApiBindingProbeResult(
    bool EnvironmentReady,
    IReadOnlyList<string> MissingCapabilities,
    ApiBindingPlan Plan
);
