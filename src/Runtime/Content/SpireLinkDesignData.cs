using MegaCrit.Sts2.Core.Entities.Cards;

namespace SpireLink.Runtime.Content;

public static class SpireLinkDesignData
{
    public static readonly CardDescriptor[] Cards =
    {
        new("LINKED_GUARD", "LINKED_GUARD", 1, CardType.Skill, CardRarity.Common, TargetType.Self, ["LINK"], "setup-defense"),
        new("TARGET_MARK", "TARGET_MARK", 1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies, ["LINK"], "setup-debuff"),
        new("RESONANCE_PREP", "RESONANCE_PREP", 0, CardType.Skill, CardRarity.Common, TargetType.Self, ["LINK"], "setup-tempo"),
        new("ECHO_CIRCUIT", "ECHO_CIRCUIT", 1, CardType.Skill, CardRarity.Uncommon, TargetType.Self, ["RESONATE"], "mid-payoff"),
        new("RESONANT_STRIKE", "RESONANT_STRIKE", 2, CardType.Attack, CardRarity.Uncommon, TargetType.Enemy, ["RESONATE"], "single-target-payoff"),
        new("CHAIN_REPAIR", "CHAIN_REPAIR", 1, CardType.Skill, CardRarity.Uncommon, TargetType.Ally, ["LINK", "GUARD_LINK"], "rescue-support"),
        new("OVERLOAD_REDIRECT", "OVERLOAD_REDIRECT", 1, CardType.Skill, CardRarity.Rare, TargetType.Self, ["LINK", "RESONATE"], "charge-converter"),
        new("FINALE_OF_ACCORD", "FINALE_OF_ACCORD", 3, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies, ["RESONATE"], "team-finisher")
    };

    public static readonly RelicDescriptor[] Relics =
    {
        new("RESONANCE_CONDUCTOR", "RESONANCE_CONDUCTOR", "Common", "support-engine"),
        new("ECHO_PRISM", "ECHO_PRISM", "Uncommon", "link-enhancer"),
        new("COMMAND_CORE", "COMMAND_CORE", "Rare", "spender-support")
    };

    public static readonly EventDescriptor[] Events =
    {
        new("ALTAR_OF_SYNC", "ALTAR_OF_SYNC", "TeamEvent", "risk-reward-synchronization")
    };
}
