using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class ChainRepairCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Ally), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "CHAIN_REPAIR";
    public override string LocalizationKey => BehaviorId;
    public override string[] Keywords => ["LINK", "GUARD_LINK"];
    public override string DesignRole => "rescue-support";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["CHAIN_REPAIR"].BaseEffects).ToArray();
}
