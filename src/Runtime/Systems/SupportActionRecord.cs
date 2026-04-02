namespace SpireLink.Runtime.Systems;

public sealed record SupportActionRecord(
    string SourcePlayerId,
    string TargetPlayerId,
    string SourceCardId,
    SupportActionType ActionType,
    int Value
);
