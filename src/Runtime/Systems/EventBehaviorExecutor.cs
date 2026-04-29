using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems;

public sealed class EventBehaviorExecutor
{
    private readonly EffectExecutor _effectExecutor = new();

    public ExecutionContext Execute(string eventId, string optionId, string sourcePlayerId)
    {
        var context = new ExecutionContext(SpireLinkRuntimeState.CurrentBattle, eventId, sourcePlayerId, null, false);
        var spec = SpireLinkBehaviorLibrary.Events[eventId];
        foreach (var effect in spec.Options[optionId])
        {
            _effectExecutor.Execute(effect, context);
        }
        return context;
    }
}
