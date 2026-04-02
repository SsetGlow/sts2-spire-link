using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class OverloadRedirectCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["OVERLOAD_REDIRECT"].BaseEffects).ToArray();
}
