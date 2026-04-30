using BaseLib.Abstracts;
using Godot;
using SpireLink.Runtime.Extensions;

namespace SpireLink.Runtime.Content;

public abstract class SpireLinkRelic : CustomRelicModel(false)
{
    public abstract string LocalizationKey { get; }
    public virtual string DesignRole => "unspecified";

    public override string PackedIconPath
    {
        get
        {
            var path = $"{Id.Entry.ToLowerInvariant()}.png".RelicImagePath();
            return ResourceLoader.Exists(path) ? path : "relic.png".RelicImagePath();
        }
    }

    protected override string PackedIconOutlinePath => "relic_outline.png".RelicImagePath();
    protected override string BigIconPath => "relic.png".BigRelicImagePath();
}
