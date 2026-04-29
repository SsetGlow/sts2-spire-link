using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content.Cards;

public sealed class TargetMarkCard() : SpireLinkCard(1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies), ISpireLinkBehaviorProvider
{
    public string BehaviorId => "TARGET_MARK";
    public CardBehaviorSpec? CardBehavior => SpireLinkBehaviorLibrary.Cards[BehaviorId];
    public RelicBehaviorSpec? RelicBehavior => null;
    public EventBehaviorSpec? EventBehavior => null;
    public static readonly string[] BehaviorSummary = EffectSpecInterpreter.Describe(SpireLinkBehaviorLibrary.Cards["TARGET_MARK"].BaseEffects).ToArray();
}
