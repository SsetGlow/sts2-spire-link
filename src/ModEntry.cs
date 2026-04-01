using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Modding;

namespace SpireLink;

[ModInitializer(nameof(Initialize))]
public partial class ModEntry : Node
{
    public const string ModId = "SpireLink";
    private static bool _initialized;
    public static readonly MegaCrit.Sts2.Core.Logging.Logger Logger = new(ModId, MegaCrit.Sts2.Core.Logging.LogType.Generic);

    public static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;
        Logger.Info("SpireLink initializing");
        var harmony = new Harmony(ModId);
        harmony.PatchAll();
        Runtime.SpireLinkContentBootstrap.RegisterAll();
        Logger.Info("SpireLink initialized");
    }
}
