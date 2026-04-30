using BaseLib.Patches.Content;

namespace SpireLink.Runtime.Content.Registration;

/// <summary>
/// Real adapter implementation based on BaseLib content registration entry points found in source:
/// - cards/relics via CustomContentDictionary.AddModel(type) with PoolAttribute
/// - events via CustomContentDictionary.AddEvent(CustomEventModel)
/// </summary>
public sealed class RealBaseLibRegistrationAdapter : IBaseLibRegistrationAdapter
{
    public void RegisterCard(RegistrationItem item)
    {
        CustomContentDictionary.AddModel(item.RuntimeType);
    }

    public void RegisterRelic(RegistrationItem item)
    {
        CustomContentDictionary.AddModel(item.RuntimeType);
    }

    public void RegisterEvent(RegistrationItem item)
    {
        if (item.RuntimeType == typeof(Events.AltarOfSyncEvent))
        {
            CustomContentDictionary.AddEvent(new Events.AltarOfSyncEvent(false));
            return;
        }

        throw new System.InvalidOperationException($"Unsupported event runtime type for real registration: {item.RuntimeType.FullName}");
    }
}
