using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpireLink.Runtime.Content.Registration;

public static class ReflectionBindingHelper
{
    public static BindingDiagnosticReport Probe(ApiBindingPlan plan)
    {
        var entries = new List<BindingDiagnosticEntry>();
        foreach (var target in plan.CardBindings.Concat(plan.RelicBindings).Concat(plan.EventBindings).Concat(plan.LifecycleBindings))
        {
            var resolved = TryResolveType(target.IntendedType, out var type);
            var detail = resolved
                ? $"Resolved type candidate: {type!.FullName}"
                : "Type not resolved in current host assemblies";
            entries.Add(new BindingDiagnosticEntry(target.Area, target.IntendedType, target.IntendedMember, resolved, detail));
        }
        return new BindingDiagnosticReport(entries.Any(e => e.Resolved), entries);
    }

    private static bool TryResolveType(string intendedType, out Type? type)
    {
        type = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a =>
            {
                try { return a.GetTypes(); }
                catch (ReflectionTypeLoadException ex) { return ex.Types.Where(t => t is not null)!; }
                catch { return Array.Empty<Type>(); }
            })
            .FirstOrDefault(t => t is not null && t.FullName is not null && t.FullName.Contains(intendedType, StringComparison.OrdinalIgnoreCase));
        return type is not null;
    }
}
