namespace SpireLink.Runtime.Systems;

public static class TargetResolver
{
    public static string Resolve(string? target, ExecutionContext context)
    {
        return target switch
        {
            null => context.SourcePlayerId,
            "self" => context.SourcePlayerId,
            "enemy" => context.ExplicitTargetId ?? "enemy",
            "teammate" => context.ExplicitTargetId ?? context.BattleState.ResolveNextTeammate(context.SourcePlayerId),
            "next_teammate" => context.BattleState.ResolveNextTeammate(context.SourcePlayerId),
            "fallback_teammate" => context.ExplicitTargetId ?? context.BattleState.ResolveNextTeammate(context.SourcePlayerId),
            "teammate_or_block_fallback" => context.ExplicitTargetId ?? context.BattleState.ResolveNextTeammate(context.SourcePlayerId),
            "spender" => context.SourcePlayerId,
            "random_teammate" => context.BattleState.ResolveNextTeammate(context.SourcePlayerId),
            _ => target
        };
    }
}
