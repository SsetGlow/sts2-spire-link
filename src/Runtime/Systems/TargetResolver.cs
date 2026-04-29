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
            "teammate" => context.ExplicitTargetId ?? "next_teammate",
            "next_teammate" => "next_teammate",
            "fallback_teammate" => context.ExplicitTargetId ?? "next_teammate",
            "teammate_or_block_fallback" => context.ExplicitTargetId ?? "next_teammate",
            "spender" => context.SourcePlayerId,
            "random_teammate" => "random_teammate",
            _ => target
        };
    }
}
