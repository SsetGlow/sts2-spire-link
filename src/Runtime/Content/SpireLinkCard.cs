using BaseLib.Abstracts;
using SpireLink.Runtime.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace SpireLink.Runtime.Content;

public abstract class SpireLinkCard(int cost, CardType type, CardRarity rarity, TargetType target) : CustomCardModel(cost, type, rarity, target)
{
    public override string CustomPortraitPath => $"{Id.Entry.ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.ToLowerInvariant()}.png".CardImagePath();
}
