using System.Collections.Generic;
using System.Linq;
using SpireLink.Runtime.Content.Events;

namespace SpireLink.Runtime.Content.Registration;

public static class RegistrationPlanBuilder
{
    public static RegistrationPlan Build()
    {
        var cards = SpireLinkRegistrationBridge.AllProviders
            .Where(p => p.CardBehavior is not null && p is SpireLinkCard card)
            .Select(p => new RegistrationItem(RegistrationItemType.Card, p.BehaviorId, ((SpireLinkCard)p).LocalizationKey, ((SpireLinkCard)p).DesignRole, p.GetType()))
            .ToList();

        var relics = SpireLinkRegistrationBridge.AllProviders
            .Where(p => p.RelicBehavior is not null && p is SpireLinkRelic relic)
            .Select(p => new RegistrationItem(RegistrationItemType.Relic, p.BehaviorId, ((SpireLinkRelic)p).LocalizationKey, ((SpireLinkRelic)p).DesignRole, p.GetType()))
            .ToList();

        var events = SpireLinkRegistrationBridge.AllProviders
            .Where(p => p.EventBehavior is not null && p is AltarOfSyncEvent altar)
            .Select(p => new RegistrationItem(RegistrationItemType.Event, p.BehaviorId, altar.LocalizationKey, altar.DesignRole, p.GetType()))
            .ToList();

        return new RegistrationPlan(cards, relics, events);
    }
}
