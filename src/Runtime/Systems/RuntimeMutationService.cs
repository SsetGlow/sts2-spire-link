namespace SpireLink.Runtime.Systems;

public sealed class RuntimeMutationService
{
    public void GainResonance(ExecutionContext context, int amount)
    {
        var gained = context.BattleState.Resonance.Gain(amount, context.SourceId);
        context.AddLog($"GainResonance +{gained}");
    }

    public int SpendResonance(ExecutionContext context, int amount)
    {
        var spent = context.BattleState.Resonance.Spend(amount, context.SourceId);
        context.SetFlag("spent_resonance", spent);
        context.AddLog($"SpendResonance -{spent}");
        return spent;
    }

    public void QueueLink(ExecutionContext context, LinkPayload payload)
    {
        context.BattleState.EnqueueLink(payload);
        context.SetFlag("link_applied", true);
        context.AddLog($"QueueLink {payload.PayloadType} -> {payload.TargetRule}");
    }

    public void RecordSupport(ExecutionContext context, SupportActionRecord record)
    {
        context.BattleState.RecordSupport(record);
        context.SetFlag("helped_teammate", true);
        context.AddLog($"Support {record.ActionType} -> {record.TargetPlayerId}");
    }

    public void TriggerLink(ExecutionContext context)
    {
        context.BattleState.IncrementLinkTriggeredThisTurn();
        context.AddLog("LinkTriggered");
    }
}
