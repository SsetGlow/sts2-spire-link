using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed record ApiBindingPlan(
    IReadOnlyList<ApiBindingTarget> CardBindings,
    IReadOnlyList<ApiBindingTarget> RelicBindings,
    IReadOnlyList<ApiBindingTarget> EventBindings,
    IReadOnlyList<ApiBindingTarget> LifecycleBindings
);
