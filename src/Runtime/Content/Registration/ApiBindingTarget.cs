namespace SpireLink.Runtime.Content.Registration;

public sealed record ApiBindingTarget(
    string Area,
    string IntendedType,
    string IntendedMember,
    string Purpose
);
