using System;

namespace SpireLink.Runtime.Content.Registration;

/// <summary>
/// Candidate real adapter shell.
/// It intentionally throws until verified against the actual local StS2/BaseLib runtime API.
/// </summary>
public sealed class RealBaseLibRegistrationAdapter : IBaseLibRegistrationAdapter
{
    private static InvalidOperationException Unverified(string itemType, RegistrationItem item) =>
        new($"Real BaseLib registration for {itemType} '{item.Id}' is not verified in the current host. Run inside a validated StS2/BaseLib runtime first.");

    public void RegisterCard(RegistrationItem item) => throw Unverified("card", item);
    public void RegisterRelic(RegistrationItem item) => throw Unverified("relic", item);
    public void RegisterEvent(RegistrationItem item) => throw Unverified("event", item);
}
