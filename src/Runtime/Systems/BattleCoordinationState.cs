using System.Collections.Generic;

namespace SpireLink.Runtime.Systems;

public sealed class BattleCoordinationState
{
    private readonly Queue<LinkPayload> _pendingLinks = new();
    private readonly List<SupportActionRecord> _supportActions = new();
    private readonly Dictionary<string, int> _turnCounters = new();

    public TeamResonanceState Resonance { get; } = new();
    public IReadOnlyCollection<LinkPayload> PendingLinks => _pendingLinks;
    public IReadOnlyList<SupportActionRecord> SupportActions => _supportActions;
    public int LinkTriggeredThisTurn { get; private set; }

    public void EnqueueLink(LinkPayload payload) => _pendingLinks.Enqueue(payload);
    public void RecordSupport(SupportActionRecord record) => _supportActions.Add(record);
    public void IncrementTurn(string playerId) => _turnCounters[playerId] = _turnCounters.GetValueOrDefault(playerId, 0) + 1;
    public int GetTurn(string playerId) => _turnCounters.GetValueOrDefault(playerId, 0);
    public void IncrementLinkTriggeredThisTurn() => LinkTriggeredThisTurn++;
    public void ResetTurnScopedCounters() => LinkTriggeredThisTurn = 0;
    public void ResetBattle()
    {
        _pendingLinks.Clear();
        _supportActions.Clear();
        _turnCounters.Clear();
        LinkTriggeredThisTurn = 0;
        Resonance.Reset();
    }
}
