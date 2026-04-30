using BaseLib.Utils;
using SpireLink.Runtime.Content.Pools;

namespace SpireLink.Runtime.Content.Relics;

[Pool(typeof(SpireLinkSharedRelicPool))]
public sealed class EchoPrismRelic : SpireLinkRelic, ISpireLinkBehaviorProvider
{
    public string BehaviorId => "ECHO_PRISM";
    public override string LocalizationKey => BehaviorId;
    public override string DesignRole => "link-enhancer";
    public CardBehaviorSpec? CardBehavior => null;
    public RelicBehaviorSpec? RelicBehavior => SpireLinkBehaviorLibrary.Relics[BehaviorId];
    public EventBehaviorSpec? EventBehavior => null;
}
