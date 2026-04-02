namespace SpireLink.Runtime.Systems;

public sealed record LinkPayload(
    string CardId,
    string SourcePlayerId,
    string? TargetPlayerId,
    LinkPayloadType PayloadType,
    LinkTargetRule TargetRule,
    int Value,
    int ExpireTurn,
    string Description
);
