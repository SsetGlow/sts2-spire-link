namespace SpireLink.Runtime.Systems;

public static class SpireLinkSystemFacade
{
    public static CardBehaviorExecutor Cards { get; } = new();
    public static RelicBehaviorExecutor Relics { get; } = new();
    public static EventBehaviorExecutor Events { get; } = new();
    public static LinkResolver Links { get; } = new();
}
