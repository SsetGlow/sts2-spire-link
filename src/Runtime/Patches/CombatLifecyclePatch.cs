using HarmonyLib;
using SpireLink.Runtime.Systems.Lifecycle;

namespace SpireLink.Runtime.Patches;

[HarmonyPatch]
public static class CombatLifecyclePatch
{
    public static void StartBattlePreview() => SpireLinkLifecycleCoordinator.StartBattle();
    public static void EndBattlePreview() => SpireLinkLifecycleCoordinator.ResetBattle();
}
