using System.Collections.Generic;
using SpireLink.Runtime.Content.Registration;
using SpireLink.Runtime.Systems.Registry;

namespace SpireLink.Runtime.Systems.Preview;

public static class RegistrationSnapshotBuilder
{
    public static RegistrationSnapshot Build()
    {
        SpireLinkRuntimeRegistry.Rebuild();
        IReadOnlyList<string> lines = RegistrationPreviewReporter.BuildPreviewLines();
        return new RegistrationSnapshot(
            SpireLinkRuntimeRegistry.Cards.Count,
            SpireLinkRuntimeRegistry.Relics.Count,
            SpireLinkRuntimeRegistry.Events.Count,
            lines
        );
    }
}
