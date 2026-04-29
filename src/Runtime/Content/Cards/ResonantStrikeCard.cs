using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class ResonantStrikeCard() : SpireLinkCard(2, CardType.Attack, CardRarity.Uncommon, TargetType.Enemy), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "RESONANT_STRIKE";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["RESONANT_STRIKE"].BaseEffects).ToArray();
}
