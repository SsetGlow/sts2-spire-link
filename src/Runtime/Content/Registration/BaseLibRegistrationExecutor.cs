using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public static class BaseLibRegistrationExecutor
{
    public static RegistrationExecutionReport Execute(RegistrationPlan plan, IBaseLibRegistrationAdapter adapter)
    {
        var steps = new List<string>();

        foreach (var card in plan.Cards)
        {
            adapter.RegisterCard(card);
            steps.Add($"CARD {card.Id}");
        }

        foreach (var relic in plan.Relics)
        {
            adapter.RegisterRelic(relic);
            steps.Add($"RELIC {relic.Id}");
        }

        foreach (var ev in plan.Events)
        {
            adapter.RegisterEvent(ev);
            steps.Add($"EVENT {ev.Id}");
        }

        return new RegistrationExecutionReport(plan.Cards.Count, plan.Relics.Count, plan.Events.Count, steps);
    }
}
