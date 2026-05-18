using SpireLink.Runtime.Content;
using SpireLink.Runtime.Content.Registration;
using SpireLink.Runtime.Systems.Lifecycle;

namespace SpireLink.Runtime;

public static class SpireLinkContentBootstrap
{
    private static bool _registered;
    public static RegistrationExecutionReport? LastRegistrationReport { get; private set; }

    public static void RegisterAll()
    {
        if (_registered) return;
        _registered = true;
        ResonanceCardRegistry.Register();
        ResonanceRelicRegistry.Register();
        ResonanceEventRegistry.Register();
        LastRegistrationReport = BaseLibRegistrationFacade.RegisterAllContent(RegistrationExecutionMode.RealCandidate);
        SpireLinkLifecycleCoordinator.Initialize();
    }
}
