namespace SpireLink.Runtime.Systems;

public static class SpireLinkRuntimeState
{
    public static BattleCoordinationState CurrentBattle { get; private set; } = new();

    public static void StartBattle()
    {
        CurrentBattle = new BattleCoordinationState();
    }

    public static void EndBattle()
    {
        CurrentBattle.ResetBattle();
    }
}
