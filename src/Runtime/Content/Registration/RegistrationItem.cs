namespace SpireLink.Runtime.Content.Registration;

public sealed record RegistrationItem(
    RegistrationItemType ItemType,
    string Id,
    string LocalizationKey,
    string DesignRole,
    System.Type RuntimeType
);
