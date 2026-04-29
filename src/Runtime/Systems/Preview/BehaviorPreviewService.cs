using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems.Preview;

public sealed class BehaviorPreviewService
{
    public BehaviorPreviewResult PreviewCard(CardBehaviorSpec behavior, string sourcePlayerId, bool upgraded = false, string? explicitTarget = null)
    {
        SpireLinkRuntimeState.StartBattle();
        var context = SpireLinkSystemFacade.Cards.Execute(behavior.CardId, sourcePlayerId, explicitTarget, upgraded);
        var battle = SpireLinkRuntimeState.CurrentBattle;
        return new BehaviorPreviewResult(behavior.CardId, context.Log, battle.Resonance.Current, battle.PendingLinks.Count, battle.SupportActions.Count);
    }

    public BehaviorPreviewResult PreviewRelic(RelicBehaviorSpec behavior, string sourcePlayerId)
    {
        SpireLinkRuntimeState.StartBattle();
        var context = SpireLinkSystemFacade.Relics.Execute(behavior.RelicId, sourcePlayerId);
        var battle = SpireLinkRuntimeState.CurrentBattle;
        return new BehaviorPreviewResult(behavior.RelicId, context.Log, battle.Resonance.Current, battle.PendingLinks.Count, battle.SupportActions.Count);
    }

    public BehaviorPreviewResult PreviewEvent(EventBehaviorSpec behavior, string optionId, string sourcePlayerId)
    {
        SpireLinkRuntimeState.StartBattle();
        var context = SpireLinkSystemFacade.Events.Execute(behavior.EventId, optionId, sourcePlayerId);
        var battle = SpireLinkRuntimeState.CurrentBattle;
        return new BehaviorPreviewResult(behavior.EventId + ":" + optionId, context.Log, battle.Resonance.Current, battle.PendingLinks.Count, battle.SupportActions.Count);
    }
}
