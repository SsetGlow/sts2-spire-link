using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems;

public sealed class EffectExecutor
{
    private readonly RuntimeMutationService _mutationService = new();

    public void Execute(EffectSpec spec, ExecutionContext context)
    {
        if (!ConditionEvaluator.Evaluate(spec.Condition, context))
        {
            context.AddLog($"Skip {spec.Type} because condition failed: {spec.Condition}");
            return;
        }

        switch (spec.Type)
        {
            case EffectSpecType.GainResonance:
                _mutationService.GainResonance(context, spec.Value);
                break;
            case EffectSpecType.SpendResonance:
                _mutationService.SpendResonance(context, spec.Value);
                break;
            case EffectSpecType.QueueLink:
                _mutationService.QueueLink(context, new LinkPayload(
                    context.SourceId,
                    context.SourcePlayerId,
                    TargetResolver.Resolve(spec.Target, context),
                    ParsePayloadType(spec.Payload),
                    ParseTargetRule(spec.Target),
                    spec.Value,
                    context.BattleState.GetTurn(context.SourcePlayerId) + 1,
                    spec.Payload ?? "link"
                ));
                break;
            case EffectSpecType.CleanseTeammate:
                _mutationService.RecordSupport(context, new SupportActionRecord(context.SourcePlayerId, TargetResolver.Resolve(spec.Target, context), context.SourceId, SupportActionType.CleanseDebuff, spec.Value));
                context.SetFlag("cleanse_success", true);
                break;
            case EffectSpecType.GainBlock:
                _mutationService.RecordSupport(context, new SupportActionRecord(context.SourcePlayerId, TargetResolver.Resolve(spec.Target, context), context.SourceId, SupportActionType.GrantBlock, spec.Value));
                break;
            case EffectSpecType.DrawCards:
                _mutationService.RecordSupport(context, new SupportActionRecord(context.SourcePlayerId, TargetResolver.Resolve(spec.Target, context), context.SourceId, SupportActionType.GrantDraw, spec.Value));
                break;
            case EffectSpecType.ReduceNextCardCost:
                _mutationService.RecordSupport(context, new SupportActionRecord(context.SourcePlayerId, TargetResolver.Resolve(spec.Target, context), context.SourceId, SupportActionType.ReduceCost, spec.Value));
                break;
            case EffectSpecType.GrantAttackBonus:
                _mutationService.RecordSupport(context, new SupportActionRecord(context.SourcePlayerId, TargetResolver.Resolve(spec.Target, context), context.SourceId, SupportActionType.GrantAttackBonus, spec.Value));
                break;
            default:
                context.AddLog($"Declared effect {spec.Type} value={spec.Value} target={spec.Target} payload={spec.Payload}");
                break;
        }
    }

    private static LinkPayloadType ParsePayloadType(string? payload) => payload switch
    {
        "block" => LinkPayloadType.Block,
        "draw" => LinkPayloadType.Draw,
        "cost_reduction" => LinkPayloadType.CostReduction,
        "attack_bonus" => LinkPayloadType.AttackBonus,
        _ => LinkPayloadType.Block
    };

    private static LinkTargetRule ParseTargetRule(string? target) => target switch
    {
        "next_teammate" => LinkTargetRule.NextTeammate,
        "random_teammate" => LinkTargetRule.RandomTeammate,
        _ => LinkTargetRule.ExplicitTeammate
    };
}
