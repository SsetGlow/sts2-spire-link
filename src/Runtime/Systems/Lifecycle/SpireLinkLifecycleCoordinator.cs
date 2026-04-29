using SpireLink.Runtime.Content.Registration;
using SpireLink.Runtime.Systems.Preview;
using SpireLink.Runtime.Systems.Registry;

namespace SpireLink.Runtime.Systems.Lifecycle;

public static class SpireLinkLifecycleCoordinator
{
    public static bool Initialized { get; private set; }
    public static RegistrationSnapshot? LastSnapshot { get; private set; }

    public static void Initialize()
    {
        if (Initialized) return;
        Initialized = true;
        SpireLinkRuntimeRegistry.Rebuild();
        LastSnapshot = RegistrationSnapshotBuilder.Build();
    }

    public static void ResetBattle() => SpireLinkRuntimeState.EndBattle();
    public static void StartBattle() => SpireLinkRuntimeState.StartBattle();
}
