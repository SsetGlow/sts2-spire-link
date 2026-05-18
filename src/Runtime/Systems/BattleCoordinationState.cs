using System.Collections.Generic;
using System.Linq;

namespace SpireLink.Runtime.Systems;

public sealed class BattleCoordinationState
{
    private readonly Queue<LinkPayload> _pendingLinks = new();
    private readonly List<SupportActionRecord> _supportActions = new();
    private readonly Dictionary<string, int> _turnCounters = new();
    private readonly List<string> _playerOrder = ["player_1", "player_2"];

    public TeamResonanceState Resonance { get; } = new();
    public IReadOnlyCollection<LinkPayload> PendingLinks => _pendingLinks;
    public IReadOnlyList<SupportActionRecord> SupportActions => _supportActions;
    public IReadOnlyList<string> PlayerOrder => _playerOrder;
    public int LinkTriggeredThisTurn { get; private set; }

    public void ConfigurePlayers(IEnumerable<string> playerIds)
    {
        var ordered = playerIds
            .Where(id => !string.IsNullOrWhiteSpace(id))
            .Distinct()
            .ToList();

        if (ordered.Count == 0) return;

        _playerOrder.Clear();
        _playerOrder.AddRange(ordered);
    }

    public void EnqueueLink(LinkPayload payload) => _pendingLinks.Enqueue(payload);
    public void RecordSupport(SupportActionRecord record) => _supportActions.Add(record);
    public void IncrementTurn(string playerId) => _turnCounters[playerId] = _turnCounters.GetValueOrDefault(playerId, 0) + 1;
    public int GetTurn(string playerId) => _turnCounters.GetValueOrDefault(playerId, 0);
    public void IncrementLinkTriggeredThisTurn() => LinkTriggeredThisTurn++;
    public void ResetTurnScopedCounters() => LinkTriggeredThisTurn = 0;
    public string ResolveNextTeammate(string sourcePlayerId)
    {
        if (_playerOrder.Count <= 1) return sourcePlayerId;

        var index = _playerOrder.IndexOf(sourcePlayerId);
        if (index < 0) return _playerOrder[0];

        return _playerOrder[(index + 1) % _playerOrder.Count];
    }

    public IReadOnlyList<LinkPayload> DequeueLinksForTurnStart(string playerId)
    {
        var currentTurn = GetTurn(playerId);
        var matched = new List<LinkPayload>();
        var remaining = new Queue<LinkPayload>();

        while (_pendingLinks.Count > 0)
        {
            var payload = _pendingLinks.Dequeue();
            var targetPlayerId = ResolveLinkTarget(payload);
            var expired = payload.ExpireTurn < currentTurn;

            if (!expired && targetPlayerId == playerId)
            {
                matched.Add(payload with { TargetPlayerId = targetPlayerId });
            }
            else if (!expired)
            {
                remaining.Enqueue(payload);
            }
        }

        while (remaining.Count > 0)
        {
            _pendingLinks.Enqueue(remaining.Dequeue());
        }

        return matched;
    }

    public string ResolveLinkTarget(LinkPayload payload)
    {
        return payload.TargetRule switch
        {
            LinkTargetRule.NextTeammate => ResolveNextTeammate(payload.SourcePlayerId),
            LinkTargetRule.RandomTeammate => ResolveNextTeammate(payload.SourcePlayerId),
            _ => payload.TargetPlayerId ?? ResolveNextTeammate(payload.SourcePlayerId)
        };
    }

    public void ResetBattle()
    {
        _pendingLinks.Clear();
        _supportActions.Clear();
        _turnCounters.Clear();
        LinkTriggeredThisTurn = 0;
        Resonance.Reset();
    }
}
