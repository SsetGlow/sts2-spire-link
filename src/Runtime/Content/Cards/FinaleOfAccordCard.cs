using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class FinaleOfAccordCard() : SpireLinkCard(3, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "FINALE_OF_ACCORD";
    public override string LocalizationKey => BehaviorId;
    public override string[] Keywords => ["RESONATE"];
    public override string DesignRole => "team-finisher";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["FINALE_OF_ACCORD"].BaseEffects).ToArray();
}
