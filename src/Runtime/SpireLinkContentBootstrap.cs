using SpireLink.Runtime.Content;
using SpireLink.Runtime.Content.Registration;
using SpireLink.Runtime.Systems.Lifecycle;

namespace SpireLink.Runtime;

public static class SpireLinkContentBootstrap
{
    private static bool _registered;
    public static void RegisterAll()
    {
        if (_registered) return;
        _registered = true;
        ResonanceCardRegistry.Register();
        ResonanceRelicRegistry.Register();
        ResonanceEventRegistry.Register();
        SpireLinkRegistrationBridge.RegisterIntoBaseLib();
        SpireLinkLifecycleCoordinator.Initialize();
    }
}
