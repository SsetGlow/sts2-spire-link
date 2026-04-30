namespace SpireLink.Runtime.Content.Registration;

public interface IBaseLibRegistrationAdapter
{
    void RegisterCard(RegistrationItem item);
    void RegisterRelic(RegistrationItem item);
    void RegisterEvent(RegistrationItem item);
}
