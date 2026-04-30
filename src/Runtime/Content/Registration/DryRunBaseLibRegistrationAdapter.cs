using System.Collections.Generic;

namespace SpireLink.Runtime.Content.Registration;

public sealed class DryRunBaseLibRegistrationAdapter : IBaseLibRegistrationAdapter
{
    private readonly List<string> _steps = new();

    public IReadOnlyList<string> Steps => _steps;

    public void RegisterCard(RegistrationItem item)
    {
        _steps.Add($"RegisterCard id={item.Id} loc={item.LocalizationKey} role={item.DesignRole} type={item.RuntimeType.Name}");
    }

    public void RegisterRelic(RegistrationItem item)
    {
        _steps.Add($"RegisterRelic id={item.Id} loc={item.LocalizationKey} role={item.DesignRole} type={item.RuntimeType.Name}");
    }

    public void RegisterEvent(RegistrationItem item)
    {
        _steps.Add($"RegisterEvent id={item.Id} loc={item.LocalizationKey} role={item.DesignRole} type={item.RuntimeType.Name}");
    }
}
