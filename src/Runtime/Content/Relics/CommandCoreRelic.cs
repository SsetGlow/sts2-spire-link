using BaseLib.Utils;
using SpireLink.Runtime.Content.Pools;

namespace SpireLink.Runtime.Content.Relics;

[Pool(typeof(SpireLinkSharedRelicPool))]
public sealed class CommandCoreRelic : SpireLinkRelic, ISpireLinkBehaviorProvider
{
    public string BehaviorId => "COMMAND_CORE";
    public override string LocalizationKey => BehaviorId;
    public override string DesignRole => "spender-support";
    public CardBehaviorSpec? CardBehavior => null;
    public RelicBehaviorSpec? RelicBehavior => SpireLinkBehaviorLibrary.Relics[BehaviorId];
    public EventBehaviorSpec? EventBehavior => null;
}
