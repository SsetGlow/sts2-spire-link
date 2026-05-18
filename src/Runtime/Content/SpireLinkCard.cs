using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SpireLink.Runtime.Extensions;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Content;

public abstract class SpireLinkCard(int cost, CardType type, CardRarity rarity, TargetType target) : CustomCardModel(cost, type, rarity, target, true, false)
{
    public abstract string LocalizationKey { get; }
    public virtual string[] Keywords => [];
    public virtual string DesignRole => "unspecified";

    public override string CustomPortraitPath => $"{Id.Entry.ToLowerInvariant()}.png".BigCardImagePath();
    public override string PortraitPath => $"{Id.Entry.ToLowerInvariant()}.png".CardImagePath();

    protected override Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (this is ISpireLinkBehaviorProvider provider)
        {
            SpireLinkSystemFacade.Cards.Execute(provider.BehaviorId, ResolveSourcePlayerId(), null, IsUpgraded);
        }

        return Task.CompletedTask;
    }

    private string ResolveSourcePlayerId()
    {
        return Owner?.Creature?.Id.Entry ?? "player_1";
    }
}
