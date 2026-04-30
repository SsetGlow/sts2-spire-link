using System.Collections.Generic;
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

    public static RegistrationPlan BuildPlan() => RegistrationPlanBuilder.Build();

    public static BaseLibRegistrationSnapshot BuildSnapshot()
    {
        var plan = BuildPlan();
        var steps = new List<string>();
        steps.Add($"Register cards: {plan.Cards.Count}");
        steps.Add($"Register relics: {plan.Relics.Count}");
        steps.Add($"Register events: {plan.Events.Count}");
        foreach (var card in plan.Cards) steps.Add($"CARD {card.Id} role={card.DesignRole} type={card.RuntimeType.Name}");
        foreach (var relic in plan.Relics) steps.Add($"RELIC {relic.Id} role={relic.DesignRole} type={relic.RuntimeType.Name}");
        foreach (var ev in plan.Events) steps.Add($"EVENT {ev.Id} role={ev.DesignRole} type={ev.RuntimeType.Name}");
        return new BaseLibRegistrationSnapshot(plan.Cards.Count, plan.Relics.Count, plan.Events.Count, steps);
    }

    public static void RegisterAllContent()
    {
        var snapshot = BuildSnapshot();
        _ = snapshot.CardCount;
        _ = snapshot.RelicCount;
        _ = snapshot.EventCount;
        // TODO: replace inventory-only shell with actual BaseLib pool/event registration calls
        // once the exact game-side API surface is available in the local environment.
    }
}
