using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Cards;
using SpireLink.Runtime.Extensions;

namespace SpireLink.Runtime.Content;

public abstract class SpireLinkCard(int cost, CardType type, CardRarity rarity, TargetType target) : CustomCardModel(cost, type, rarity, target)
{
    public abstract string LocalizationKey { get; }
    public virtual string[] Keywords => [];
    public virtual string DesignRole => "unspecified";

    public override string CustomPortraitPath => $"{Id.Entry.ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.ToLowerInvariant()}.png".CardImagePath();
}
