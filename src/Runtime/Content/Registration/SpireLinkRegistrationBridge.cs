using System.Collections.Generic;
using SpireLink.Runtime.Content.Cards;
using SpireLink.Runtime.Content.Events;
using SpireLink.Runtime.Content.Relics;

namespace SpireLink.Runtime.Content.Registration;

public static class SpireLinkRegistrationBridge
{
    public static IReadOnlyList<ISpireLinkBehaviorProvider> AllProviders { get; } = new ISpireLinkBehaviorProvider[]
    {
        new LinkedGuardCard(),
        new TargetMarkCard(),
        new ResonancePrepCard(),
        new EchoCircuitCard(),
        new ResonantStrikeCard(),
        new ChainRepairCard(),
        new OverloadRedirectCard(),
        new FinaleOfAccordCard(),
        new ResonanceConductorRelic(),
        new EchoPrismRelic(),
        new CommandCoreRelic(),
        new AltarOfSyncEvent()
    };
}
