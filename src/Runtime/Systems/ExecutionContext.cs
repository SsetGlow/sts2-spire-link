using System.Collections.Generic;

namespace SpireLink.Runtime.Systems;

public sealed class ExecutionContext
{
    private readonly Dictionary<string, object> _flags = new();
    private readonly List<ExecutionLogEntry> _log = new();

    public BattleCoordinationState BattleState { get; }
    public string SourceId { get; }
    public string SourcePlayerId { get; }
    public string? ExplicitTargetId { get; }
    public bool Upgraded { get; }

    public IReadOnlyDictionary<string, object> Flags => _flags;
    public IReadOnlyList<ExecutionLogEntry> Log => _log;

    public ExecutionContext(BattleCoordinationState battleState, string sourceId, string sourcePlayerId, string? explicitTargetId, bool upgraded)
    {
        BattleState = battleState;
        SourceId = sourceId;
        SourcePlayerId = sourcePlayerId;
        ExplicitTargetId = explicitTargetId;
        Upgraded = upgraded;
    }

    public void SetFlag(string key, object value) => _flags[key] = value;
    public T? GetFlag<T>(string key)
    {
        if (_flags.TryGetValue(key, out var value) && value is T casted)
        {
            return casted;
        }
        return default;
    }

    public void AddLog(string message) => _log.Add(new ExecutionLogEntry(SourceId, message));
}
