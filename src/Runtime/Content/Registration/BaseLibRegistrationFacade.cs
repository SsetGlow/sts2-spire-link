using SpireLink.Runtime.Content.Cards;
using SpireLink.Runtime.Content.Events;
using SpireLink.Runtime.Content.Relics;

namespace SpireLink.Runtime.Content.Registration;

/// <summary>
/// Central place for wiring Spire Link content into the eventual BaseLib/StS2 registration flow.
/// Current stage: concrete registration inventory + sequencing shell + dry-run executor.
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
        var dryRunAdapter = new DryRunBaseLibRegistrationAdapter();
        var report = BaseLibRegistrationExecutor.Execute(plan, dryRunAdapter);
        return new BaseLibRegistrationSnapshot(report.CardCount, report.RelicCount, report.EventCount, dryRunAdapter.Steps);
    }

    public static RegistrationExecutionReport RegisterAllContent(IBaseLibRegistrationAdapter? adapter = null)
    {
        var plan = BuildPlan();
        var effectiveAdapter = adapter ?? new DryRunBaseLibRegistrationAdapter();
        return BaseLibRegistrationExecutor.Execute(plan, effectiveAdapter);
    }
}
