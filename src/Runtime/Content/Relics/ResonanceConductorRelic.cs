using BaseLib.Utils;
using SpireLink.Runtime.Content.Pools;

namespace SpireLink.Runtime.Content.Relics;

[Pool(typeof(SpireLinkSharedRelicPool))]
public sealed class ResonanceConductorRelic : SpireLinkRelic, ISpireLinkBehaviorProvider
{
    public string BehaviorId => "RESONANCE_CONDUCTOR";
    public override string LocalizationKey => BehaviorId;
    public override string DesignRole => "support-engine";
    public CardBehaviorSpec? CardBehavior => null;
    public RelicBehaviorSpec? RelicBehavior => SpireLinkBehaviorLibrary.Relics[BehaviorId];
    public EventBehaviorSpec? EventBehavior => null;
}
