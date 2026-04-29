using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems;

public sealed class RelicBehaviorExecutor
{
    private readonly EffectExecutor _effectExecutor = new();

    public ExecutionContext Execute(string relicId, string sourcePlayerId)
    {
        var context = new ExecutionContext(SpireLinkRuntimeState.CurrentBattle, relicId, sourcePlayerId, null, false);
        var spec = SpireLinkBehaviorLibrary.Relics[relicId];
        foreach (var effect in spec.Effects)
        {
            _effectExecutor.Execute(effect, context);
        }
        return context;
    }
}
