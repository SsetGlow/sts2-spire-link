using SpireLink.Runtime.Content.Cards;
using SpireLink.Runtime.Content.Events;
using SpireLink.Runtime.Content.Relics;

namespace SpireLink.Runtime.Content.Registration;

/// <summary>
/// Central place for wiring Spire Link content into the eventual BaseLib/StS2 registration flow.
/// Current stage: concrete registration inventory + sequencing shell.
/// </summary>
public static class BaseLibRegistrationFacade
{
    public static readonly System.Type[] CardTypes =
    {
        typeof(LinkedGuardCard),
        typeof(TargetMarkCard),
        typeof(ResonancePrepCard),
        typeof(EchoCircuitCard),
        typeof(ResonantStrikeCard),
        typeof(ChainRepairCard),
        typeof(OverloadRedirectCard),
        typeof(FinaleOfAccordCard)
    };

    public static readonly System.Type[] RelicTypes =
    {
        typeof(ResonanceConductorRelic),
        typeof(EchoPrismRelic),
        typeof(CommandCoreRelic)
    };

    public static readonly System.Type[] EventTypes =
    {
        typeof(AltarOfSyncEvent)
    };

    public static void RegisterAllContent()
    {
        // TODO: replace inventory-only shell with actual BaseLib pool/event registration calls
        // once the exact game-side API surface is available in the local environment.
        _ = CardTypes.Length;
        _ = RelicTypes.Length;
        _ = EventTypes.Length;
    }
}
