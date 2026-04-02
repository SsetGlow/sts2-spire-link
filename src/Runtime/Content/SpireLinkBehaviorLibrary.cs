using System.Collections.Generic;

namespace SpireLink.Runtime.Content;

public static class SpireLinkBehaviorLibrary
{
    public static readonly IReadOnlyDictionary<string, CardBehaviorSpec> Cards = new Dictionary<string, CardBehaviorSpec>
    {
        ["LINKED_GUARD"] = new("LINKED_GUARD", new List<EffectSpec> { new(EffectSpecType.GainBlock, 7, Target: "self"), new(EffectSpecType.QueueLink, 5, Target: "next_teammate", Payload: "block"), new(EffectSpecType.GainResonance, 1) }, new List<EffectSpec> { new(EffectSpecType.GainBlock, 9, Target: "self"), new(EffectSpecType.QueueLink, 7, Target: "next_teammate", Payload: "block"), new(EffectSpecType.GainResonance, 1) }),
        ["TARGET_MARK"] = new("TARGET_MARK", new List<EffectSpec> { new(EffectSpecType.ApplyVulnerableToAllEnemies, 1), new(EffectSpecType.QueueLink, 4, Target: "next_teammate", Payload: "attack_bonus"), new(EffectSpecType.GainResonance, 1) }, new List<EffectSpec> { new(EffectSpecType.ApplyVulnerableToAllEnemies, 2), new(EffectSpecType.QueueLink, 6, Target: "next_teammate", Payload: "attack_bonus"), new(EffectSpecType.GainResonance, 1) }),
        ["RESONANCE_PREP"] = new("RESONANCE_PREP", new List<EffectSpec> { new(EffectSpecType.DrawCards, 1, Target: "self"), new(EffectSpecType.QueueLink, 1, Target: "next_teammate", Payload: "cost_reduction"), new(EffectSpecType.GainResonance, 1, Condition: "link_applied") }, new List<EffectSpec> { new(EffectSpecType.DrawCards, 2, Target: "self"), new(EffectSpecType.QueueLink, 1, Target: "next_teammate", Payload: "cost_reduction"), new(EffectSpecType.GainResonance, 1, Condition: "link_applied") }),
        ["ECHO_CIRCUIT"] = new("ECHO_CIRCUIT", new List<EffectSpec> { new(EffectSpecType.GainBlock, 8, Target: "self"), new(EffectSpecType.DrawCards, 2, Target: "self", Condition: "resonance>=3") }, new List<EffectSpec> { new(EffectSpecType.GainBlock, 10, Target: "self"), new(EffectSpecType.DrawCards, 2, Target: "self", Condition: "resonance>=3") }),
        ["RESONANT_STRIKE"] = new("RESONANT_STRIKE", new List<EffectSpec> { new(EffectSpecType.DealDamage, 14, Target: "enemy"), new(EffectSpecType.SpendResonance, 3, SecondaryValue: 5, Condition: "optional_bonus_per_spend") }, new List<EffectSpec> { new(EffectSpecType.DealDamage, 18, Target: "enemy"), new(EffectSpecType.SpendResonance, 3, SecondaryValue: 6, Condition: "optional_bonus_per_spend") }),
        ["CHAIN_REPAIR"] = new("CHAIN_REPAIR", new List<EffectSpec> { new(EffectSpecType.CleanseTeammate, 1, Target: "teammate_or_block_fallback"), new(EffectSpecType.GainBlock, 8, Target: "fallback_teammate"), new(EffectSpecType.GainResonance, 2, Condition: "helped_teammate") }, new List<EffectSpec> { new(EffectSpecType.CleanseTeammate, 1, Target: "teammate_or_block_fallback"), new(EffectSpecType.GainBlock, 11, Target: "fallback_teammate"), new(EffectSpecType.DrawCards, 1, Target: "teammate", Condition: "cleanse_success"), new(EffectSpecType.GainResonance, 2, Condition: "helped_teammate") }),
        ["OVERLOAD_REDIRECT"] = new("OVERLOAD_REDIRECT", new List<EffectSpec> { new(EffectSpecType.LoseHp, 3, Target: "self"), new(EffectSpecType.GainResonance, 3), new(EffectSpecType.QueueLink, 2, Target: "next_teammate", Payload: "draw"), new(EffectSpecType.GainEnergy, 1, Target: "self", Condition: "resonance>=5") }, new List<EffectSpec> { new(EffectSpecType.LoseHp, 2, Target: "self"), new(EffectSpecType.GainResonance, 3), new(EffectSpecType.QueueLink, 2, Target: "next_teammate", Payload: "draw"), new(EffectSpecType.GainEnergy, 1, Target: "self", Condition: "resonance>=5") }),
        ["FINALE_OF_ACCORD"] = new("FINALE_OF_ACCORD", new List<EffectSpec> { new(EffectSpecType.DealAoeDamage, 16), new(EffectSpecType.Conditional, 5, SecondaryValue: 12, Condition: "link_triggered_this_turn>=2", Payload: "team_block_5") }, new List<EffectSpec> { new(EffectSpecType.DealAoeDamage, 20), new(EffectSpecType.Conditional, 5, SecondaryValue: 15, Condition: "link_triggered_this_turn>=2", Payload: "team_block_6") })
    };

    public static readonly IReadOnlyDictionary<string, RelicBehaviorSpec> Relics = new Dictionary<string, RelicBehaviorSpec>
    {
        ["RESONANCE_CONDUCTOR"] = new("RESONANCE_CONDUCTOR", "first_support_each_turn", new List<EffectSpec> { new(EffectSpecType.GainResonance, 1) }),
        ["ECHO_PRISM"] = new("ECHO_PRISM", "on_link_trigger", new List<EffectSpec> { new(EffectSpecType.Conditional, Condition: "random_bonus") }),
        ["COMMAND_CORE"] = new("COMMAND_CORE", "first_resonance_spend_each_turn", new List<EffectSpec> { new(EffectSpecType.GainBlock, 4, Target: "spender"), new(EffectSpecType.DrawCards, 1, Target: "random_teammate"), new(EffectSpecType.GainResonance, 1, Condition: "spent>=4") })
    };

    public static readonly IReadOnlyDictionary<string, EventBehaviorSpec> Events = new Dictionary<string, EventBehaviorSpec>
    {
        ["ALTAR_OF_SYNC"] = new("ALTAR_OF_SYNC", new Dictionary<string, IReadOnlyList<EffectSpec>>
        {
            ["BUILD_RESONANCE"] = new List<EffectSpec> { new(EffectSpecType.GainResonance, 3), new(EffectSpecType.Conditional, Condition: "grant_resonance_conductor_random_player"), new(EffectSpecType.Conditional, Condition: "enemies_gain_strength_next_2_battles") },
            ["FORCE_SYNC"] = new List<EffectSpec> { new(EffectSpecType.Conditional, Condition: "double_first_link_next_battle"), new(EffectSpecType.Conditional, Condition: "shuffle_burden_each_player") },
            ["REJECT"] = new List<EffectSpec> { new(EffectSpecType.Conditional, Condition: "heal_team_5") }
        })
    };
}
