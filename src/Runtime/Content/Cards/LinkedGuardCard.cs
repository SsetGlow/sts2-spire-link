using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class LinkedGuardCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["LINKED_GUARD"].BaseEffects).ToArray();
}
