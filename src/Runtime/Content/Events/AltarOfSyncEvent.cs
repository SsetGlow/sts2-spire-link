namespace SpireLink.Runtime.Content.Events;

public sealed class AltarOfSyncEvent : ISpireLinkBehaviorProvider
{
    public const string EventId = "ALTAR_OF_SYNC";
    public string BehaviorId => EventId;
    public string LocalizationKey => EventId;
    public string DesignRole => "risk-reward-synchronization";
    public CardBehaviorSpec? CardBehavior => null;
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => SpireLinkBehaviorLibrary.Events[EventId];
}
