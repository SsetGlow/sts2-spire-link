using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems;

public sealed class CardBehaviorExecutor
{
    private readonly EffectExecutor _effectExecutor = new();

    public ExecutionContext Execute(string cardId, string sourcePlayerId, string? explicitTargetId, bool upgraded)
    {
        var battle = SpireLinkRuntimeState.CurrentBattle;
        var context = new ExecutionContext(battle, cardId, sourcePlayerId, explicitTargetId, upgraded);
        var spec = SpireLinkBehaviorLibrary.Cards[cardId];
        var effects = upgraded ? spec.UpgradedEffects : spec.BaseEffects;

        foreach (var effect in effects)
        {
            _effectExecutor.Execute(effect, context);
        }

        return context;
    }
}
