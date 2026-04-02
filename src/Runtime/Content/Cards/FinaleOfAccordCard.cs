using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class FinaleOfAccordCard() : SpireLinkCard(3, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies)
{
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["FINALE_OF_ACCORD"].BaseEffects).ToArray();
}
