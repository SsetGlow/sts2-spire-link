using MegaCrit.Sts2.Core.Entities.Cards;

namespace SpireLink.Runtime.Content;

public sealed record CardDescriptor(
    string Id,
    string LocalizationKey,
    int Cost,
    CardType Type,
    CardRarity Rarity,
    TargetType Target,
    string[] Keywords,
    string DesignRole
);
