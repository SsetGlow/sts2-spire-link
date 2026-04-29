using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class ResonancePrepCard() : SpireLinkCard(0, CardType.Skill, CardRarity.Common, TargetType.Self), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "RESONANCE_PREP";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["RESONANCE_PREP"].BaseEffects).ToArray();
}
