namespace SpireLink.Runtime.Content.Relics;

public sealed class CommandCoreRelic : SpireLinkRelic, ISpireLinkBehaviorProvider
{
    public string BehaviorId => "COMMAND_CORE";
    public CardBehaviorSpec? CardBehavior => null;
    public RelicBehaviorSpec? RelicBehavior => SpireLinkBehaviorLibrary.Relics[BehaviorId];
    public EventBehaviorSpec? EventBehavior => null;
}
