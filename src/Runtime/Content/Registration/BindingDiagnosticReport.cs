using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed record BindingDiagnosticReport(
    bool AnyResolved,
    IReadOnlyList<BindingDiagnosticEntry> Entries
);
