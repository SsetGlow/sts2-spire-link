using BaseLib.Abstracts;

namespace SpireLink.Runtime.Content.Pools;

public sealed class SpireLinkSharedRelicPool : CustomRelicPoolModel
{
    public override string Title => "SpireLinkSharedRelics";
    public override bool IsShared => true;
}
