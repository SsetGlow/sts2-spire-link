using SpireLink.Runtime.Content;

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
    }
}
