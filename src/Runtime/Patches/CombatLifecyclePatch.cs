using HarmonyLib;
using SpireLink.Runtime.Systems;

namespace SpireLink.Runtime.Patches;

[HarmonyPatch]
public static class CombatLifecyclePatch
{
    public static void StartBattlePreview() => SpireLinkRuntimeState.StartBattle();
    public static void EndBattlePreview() => SpireLinkRuntimeState.EndBattle();
}
