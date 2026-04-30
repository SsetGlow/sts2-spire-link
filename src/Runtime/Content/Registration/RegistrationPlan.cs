using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed record RegistrationPlan(
    IReadOnlyList<RegistrationItem> Cards,
    IReadOnlyList<RegistrationItem> Relics,
    IReadOnlyList<RegistrationItem> Events
);
