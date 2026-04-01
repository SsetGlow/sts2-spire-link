using SpireLink.Runtime.Content.Cards;

namespace SpireLink.Runtime.Content;

public static class ResonanceCardRegistry
{
    public static void Register()
    {
        _ = typeof(LinkedGuardCard);
        _ = typeof(TargetMarkCard);
        _ = typeof(ResonancePrepCard);
        _ = typeof(EchoCircuitCard);
        _ = typeof(ResonantStrikeCard);
        _ = typeof(ChainRepairCard);
        _ = typeof(OverloadRedirectCard);
        _ = typeof(FinaleOfAccordCard);
    }
}
