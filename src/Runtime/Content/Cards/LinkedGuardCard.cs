using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class LinkedGuardCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Common, TargetType.Self), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "LINKED_GUARD";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["LINKED_GUARD"].BaseEffects).ToArray();
}
