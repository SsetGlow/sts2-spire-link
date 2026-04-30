namespace SpireLink.Runtime.Content.Relics;

public sealed class ResonanceConductorRelic : SpireLinkRelic, ISpireLinkBehaviorProvider
{
    public string BehaviorId => "RESONANCE_CONDUCTOR";
    public override string LocalizationKey => BehaviorId;
    public override string DesignRole => "support-engine";
    public CardBehaviorSpec? CardBehavior => null;
    public RelicBehaviorSpec? RelicBehavior => SpireLinkBehaviorLibrary.Relics[BehaviorId];
    public EventBehaviorSpec? EventBehavior => null;
}
