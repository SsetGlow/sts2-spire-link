namespace SpireLink.Runtime.Content.Registration;

public sealed record BindingDiagnosticEntry(
    string Area,
    string IntendedType,
    string IntendedMember,
    bool Resolved,
    string Detail
);
