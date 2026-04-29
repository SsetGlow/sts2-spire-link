using System;

namespace SpireLink.Runtime.Systems;

public static class ConditionEvaluator
{
    public static bool Evaluate(string? condition, ExecutionContext context)
    {
        if (string.IsNullOrWhiteSpace(condition)) return true;

        if (condition.StartsWith("resonance>=", StringComparison.OrdinalIgnoreCase))
        {
            var threshold = int.Parse(condition.Split(">=")[1]);
            return context.BattleState.Resonance.Reach(threshold);
        }

        if (condition.StartsWith("link_triggered_this_turn>=", StringComparison.OrdinalIgnoreCase))
        {
            var threshold = int.Parse(condition.Split(">=")[1]);
            return context.BattleState.LinkTriggeredThisTurn >= threshold;
        }

        if (condition.StartsWith("spent>=", StringComparison.OrdinalIgnoreCase))
        {
            var threshold = int.Parse(condition.Split(">=")[1]);
            var spent = context.GetFlag<int>("spent_resonance");
            return spent >= threshold;
        }

        return condition switch
        {
            "link_applied" => context.GetFlag<bool>("link_applied"),
            "helped_teammate" => context.GetFlag<bool>("helped_teammate"),
            "cleanse_success" => context.GetFlag<bool>("cleanse_success"),
            "optional_bonus_per_spend" => true,
            "random_bonus" => true,
            "grant_resonance_conductor_random_player" => true,
            "enemies_gain_strength_next_2_battles" => true,
            "double_first_link_next_battle" => true,
            "shuffle_burden_each_player" => true,
            "heal_team_5" => true,
            _ => false
        };
    }
}
