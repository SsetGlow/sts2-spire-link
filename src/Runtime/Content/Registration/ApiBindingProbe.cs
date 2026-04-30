using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public static class ApiBindingProbe
{
    public static ApiBindingProbeResult ProbeCurrentEnvironment()
    {
        var plan = ApiBindingPlanBuilder.Build();
        var diagnostics = ReflectionBindingHelper.Probe(plan);
        var missing = new List<string>
        {
            "StS2 runtime assemblies not validated in current host",
            "dotnet build environment unavailable in current host",
            "Godot export environment unavailable in current host"
        };

        return new ApiBindingProbeResult(
            EnvironmentReady: false,
            MissingCapabilities: missing,
            Plan: plan,
            Diagnostics: diagnostics
        );
    }
}
