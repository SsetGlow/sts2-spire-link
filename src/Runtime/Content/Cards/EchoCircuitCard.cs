using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class EchoCircuitCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["ECHO_CIRCUIT"].BaseEffects).ToArray();
}
