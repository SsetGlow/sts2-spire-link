using System.Collections.Generic;
using SpireLink.Runtime.Content;

namespace SpireLink.Runtime.Systems;

public static class EffectSpecInterpreter
{
    public static IReadOnlyList<string> Describe(IEnumerable<EffectSpec> specs)
    {
        var output = new List<string>();
        foreach (var spec in specs)
        {
            output.Add($"{spec.Type} value={spec.Value} secondary={spec.SecondaryValue} target={spec.Target} condition={spec.Condition} payload={spec.Payload}");
        }
        return output;
    }
}
