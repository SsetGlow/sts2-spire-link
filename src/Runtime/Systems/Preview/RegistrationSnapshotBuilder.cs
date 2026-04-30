using System.Collections.Generic;
using SpireLink.Runtime.Content.Registration;
using SpireLink.Runtime.Systems.Registry;

namespace SpireLink.Runtime.Systems.Preview;

public static class RegistrationSnapshotBuilder
{
    public static RegistrationSnapshot Build()
    {
        SpireLinkRuntimeRegistry.Rebuild();
        IReadOnlyList<string> lines = Content.Registration.RegistrationPreviewReporter.BuildPreviewLines();
        var baseLibSnapshot = BaseLibRegistrationFacade.BuildSnapshot();
        var bindingProbe = BaseLibRegistrationFacade.ProbeBindings();
        return new RegistrationSnapshot(
            SpireLinkRuntimeRegistry.Cards.Count,
            SpireLinkRuntimeRegistry.Relics.Count,
            SpireLinkRuntimeRegistry.Events.Count,
            lines,
            baseLibSnapshot,
            bindingProbe
        );
    }
}
