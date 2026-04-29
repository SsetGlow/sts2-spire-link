using System.Linq;
using SpireLink.Runtime.Systems.Preview;

namespace SpireLink.Runtime.Content.Registration;

public static class RegistrationPreviewReporter
{
    public static string[] BuildPreviewLines()
    {
        var preview = new BehaviorPreviewService();
        return SpireLinkRegistrationBridge.AllProviders.Select(provider =>
        {
            if (provider.CardBehavior is not null)
            {
                var result = preview.PreviewCard(provider.CardBehavior, "player_1");
                return $"CARD {provider.BehaviorId} resonance={result.ResonanceAfter} links={result.PendingLinkCount} support={result.SupportActionCount} logs={result.Logs.Count}";
            }
            if (provider.RelicBehavior is not null)
            {
                var result = preview.PreviewRelic(provider.RelicBehavior, "player_1");
                return $"RELIC {provider.BehaviorId} resonance={result.ResonanceAfter} links={result.PendingLinkCount} support={result.SupportActionCount} logs={result.Logs.Count}";
            }
            if (provider.EventBehavior is not null)
            {
                var optionId = provider.EventBehavior.Options.Keys.First();
                var result = preview.PreviewEvent(provider.EventBehavior, optionId, "player_1");
                return $"EVENT {provider.BehaviorId} resonance={result.ResonanceAfter} links={result.PendingLinkCount} support={result.SupportActionCount} logs={result.Logs.Count}";
            }
            return $"UNKNOWN {provider.BehaviorId}";
        }).ToArray();
    }
}
