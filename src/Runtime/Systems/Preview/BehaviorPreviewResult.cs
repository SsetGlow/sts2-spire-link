using System.Collections.Generic;

namespace SpireLink.Runtime.Systems.Preview;

public sealed record BehaviorPreviewResult(
    string BehaviorId,
    IReadOnlyList<ExecutionLogEntry> Logs,
    int ResonanceAfter,
    int PendingLinkCount,
    int SupportActionCount
);
