using System.Collections.Generic;

namespace SpireLink.Runtime.Systems;

public sealed class TeamResonanceState
{
    public const int DefaultMax = 10;
    private readonly List<ResonanceHistoryEntry> _history = new();

    public int Current { get; private set; }
    public int Max { get; }
    public IReadOnlyList<ResonanceHistoryEntry> History => _history;

    public TeamResonanceState(int max = DefaultMax)
    {
        Max = max;
    }

    public int Gain(int amount, string source)
    {
        var before = Current;
        Current = int.Min(Max, Current + int.Max(0, amount));
        var gained = Current - before;
        _history.Add(new ResonanceHistoryEntry(source, gained, Current));
        return gained;
    }

    public int Spend(int amount, string source)
    {
        var actual = int.Min(Current, int.Max(0, amount));
        Current -= actual;
        _history.Add(new ResonanceHistoryEntry(source, -actual, Current));
        return actual;
    }

    public bool CanSpend(int amount) => Current >= amount;
    public bool Reach(int threshold) => Current >= threshold;
    public void Reset() => Current = 0;
}
