using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Content.Pools;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

[Pool(typeof(SpireLinkSharedCardPool))]
public sealed class EchoCircuitCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "ECHO_CIRCUIT";
    public override string LocalizationKey => BehaviorId;
    public override string[] Keywords => ["RESONATE"];
    public override string DesignRole => "mid-payoff";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["ECHO_CIRCUIT"].BaseEffects).ToArray();
}
