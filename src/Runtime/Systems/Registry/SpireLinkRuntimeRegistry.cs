using System.Collections.Generic;
using System.Linq;
using SpireLink.Runtime.Content;
using SpireLink.Runtime.Content.Registration;

namespace SpireLink.Runtime.Systems.Registry;

public static class SpireLinkRuntimeRegistry
{
    public static IReadOnlyDictionary<string, RegisteredCardRuntime> Cards { get; private set; } = new Dictionary<string, RegisteredCardRuntime>();
    public static IReadOnlyDictionary<string, RegisteredRelicRuntime> Relics { get; private set; } = new Dictionary<string, RegisteredRelicRuntime>();
    public static IReadOnlyDictionary<string, RegisteredEventRuntime> Events { get; private set; } = new Dictionary<string, RegisteredEventRuntime>();

    public static void Rebuild()
    {
        Cards = SpireLinkRegistrationBridge.AllProviders
            .Where(provider => provider.CardBehavior is not null)
            .ToDictionary(
                provider => provider.BehaviorId,
                provider => new RegisteredCardRuntime(
                    provider.BehaviorId,
                    provider.CardBehavior!,
                    Systems.EffectSpecInterpreter.Describe(provider.CardBehavior!.BaseEffects).ToArray()
                )
            );

        Relics = SpireLinkRegistrationBridge.AllProviders
            .Where(provider => provider.RelicBehavior is not null)
            .ToDictionary(
                provider => provider.BehaviorId,
                provider => new RegisteredRelicRuntime(provider.BehaviorId, provider.RelicBehavior!)
            );

        Events = SpireLinkRegistrationBridge.AllProviders
            .Where(provider => provider.EventBehavior is not null)
            .ToDictionary(
                provider => provider.BehaviorId,
                provider => new RegisteredEventRuntime(provider.BehaviorId, provider.EventBehavior!)
            );
    }
}
