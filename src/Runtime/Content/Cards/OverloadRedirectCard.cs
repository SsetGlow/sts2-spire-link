using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Content.Pools;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

[Pool(typeof(SpireLinkSharedCardPool))]
public sealed class OverloadRedirectCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "OVERLOAD_REDIRECT";
    public override string LocalizationKey => BehaviorId;
    public override string[] Keywords => ["LINK", "RESONATE"];
    public override string DesignRole => "charge-converter";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["OVERLOAD_REDIRECT"].BaseEffects).ToArray();
}
