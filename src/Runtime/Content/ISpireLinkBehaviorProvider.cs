namespace SpireLink.Runtime.Content;

public interface ISpireLinkBehaviorProvider
{
    string BehaviorId { get; }
    CardBehaviorSpec? CardBehavior { get; }
    RelicBehaviorSpec? RelicBehavior { get; }
    EventBehaviorSpec? EventBehavior { get; }
}
