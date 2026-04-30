using BaseLib.Abstracts;
using Godot;

namespace SpireLink.Runtime.Content.Pools;

public sealed class SpireLinkSharedCardPool : CustomCardPoolModel
{
    public override string Title => "SpireLinkShared";
    public override bool IsShared => true;
    public override bool IsColorless => true;
    public override Color DeckEntryCardColor => new("ffffff");
    public override float H => 0.75f;
    public override float S => 0.65f;
    public override float V => 0.95f;
}
