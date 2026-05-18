namespace SpireLink.Runtime.Systems;

public sealed class LinkResolver
{
    public ExecutionContext TriggerTurnStartLinks(string playerId)
    {
        var battle = SpireLinkRuntimeState.CurrentBattle;
        battle.IncrementTurn(playerId);
        battle.ResetTurnScopedCounters();

        var context = new ExecutionContext(battle, "TURN_START_LINKS", playerId, playerId, false);
        foreach (var payload in battle.DequeueLinksForTurnStart(playerId))
        {
            var record = ToSupportAction(payload, playerId);
            battle.RecordSupport(record);
            battle.IncrementLinkTriggeredThisTurn();
            context.AddLog($"TriggerLink {payload.PayloadType} from {payload.SourcePlayerId} -> {playerId} value={payload.Value}");
        }

        return context;
    }

    private static SupportActionRecord ToSupportAction(LinkPayload payload, string targetPlayerId)
    {
        return new SupportActionRecord(
            payload.SourcePlayerId,
            targetPlayerId,
            payload.CardId,
            ToSupportActionType(payload.PayloadType),
            payload.Value
        );
    }

    private static SupportActionType ToSupportActionType(LinkPayloadType payloadType)
    {
        return payloadType switch
        {
            LinkPayloadType.Block => SupportActionType.GrantBlock,
            LinkPayloadType.Draw => SupportActionType.GrantDraw,
            LinkPayloadType.CostReduction => SupportActionType.ReduceCost,
            LinkPayloadType.AttackBonus => SupportActionType.GrantAttackBonus,
            LinkPayloadType.Cleanse => SupportActionType.CleanseDebuff,
            LinkPayloadType.TeamBlock => SupportActionType.Protect,
            _ => SupportActionType.GrantBlock
        };
    }
}
