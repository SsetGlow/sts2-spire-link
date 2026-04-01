using SpireLink.Runtime.Content.Relics;

namespace SpireLink.Runtime.Content;

public static class ResonanceRelicRegistry
{
    public static void Register()
    {
        _ = typeof(ResonanceConductorRelic);
        _ = typeof(EchoPrismRelic);
        _ = typeof(CommandCoreRelic);
    }
}
