using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public static class ApiBindingPlanBuilder
{
    public static ApiBindingPlan Build()
    {
        return new ApiBindingPlan(
            new List<ApiBindingTarget>
            {
                new("Cards", "BaseLib Card Pool / CustomCardModel pipeline", "Register custom cards into card pools", "Make Spire Link cards obtainable and playable"),
                new("Cards", "Card execution hook", "Resolve card behavior specs on play / upgrade / targeting", "Make gameplay effects run in actual combat")
            },
            new List<ApiBindingTarget>
            {
                new("Relics", "BaseLib Relic Pool / CustomRelicModel pipeline", "Register relics into relic pools", "Make relics obtainable in runs"),
                new("Relics", "Relic trigger hook", "Bind first-support / on-link / on-spend triggers", "Make relic behavior react to runtime state")
            },
            new List<ApiBindingTarget>
            {
                new("Events", "Event registration pipeline", "Register Altar of Sync into event system", "Make the event appear during map traversal"),
                new("Events", "Event option resolution hook", "Resolve event option specs into runtime mutations", "Apply team resonance/event side effects")
            },
            new List<ApiBindingTarget>
            {
                new("Lifecycle", "Combat start hook", "Initialize battle coordination state", "Start resonance/link tracking each combat"),
                new("Lifecycle", "Turn start hook", "Trigger queued Link payloads", "Deliver delayed teammate support effects"),
                new("Lifecycle", "Combat end hook", "Reset runtime battle state", "Prevent cross-combat leakage")
            }
        );
    }
}
