using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// NuGet allows an application to use an assembly that was compiled against a different major
/// version of the SDK than the one that is running. Such an assembly contains its own copy of
/// the SDK's constants, so it can misbehave without an error.
/// </summary>
internal static class AssemblyVersionCompatibility
{
    const string Switch = "Anthropic.CheckAssemblyVersionCompatibility";

    static readonly Lazy<string?> Error = new(FindError);

    internal static void ThrowIfIncompatible()
    {
        if (AppContext.TryGetSwitch(Switch, out var isEnabled) && !isEnabled)
        {
            return;
        }

        if (Error.Value is { } error)
        {
            throw new AnthropicException(error);
        }
    }

    static string? FindError()
    {
        var root = Assembly.GetEntryAssembly();
        if (root == null)
        {
            return null;
        }

        var sdk = typeof(AssemblyVersionCompatibility).Assembly.GetName();
        var incompatible = FindIncompatibleReferences(root.GetName(), sdk);
        if (incompatible.Count == 0)
        {
            return null;
        }

        return $"The following assemblies were compiled against a different major version of {sdk.Name} than the one that is running ({sdk.Version?.ToString(3)}):\n\n"
            + string.Join(
                "\n",
                Enumerable.Select(
                    incompatible,
                    found =>
                        $"- {found.Assembly.Name} {found.Assembly.Version} (compiled against {sdk.Name} {found.Reference.Version?.ToString(3)})"
                )
            )
            + $"\n\nThey may misbehave without an error. Upgrade each one to a version that was compiled against {sdk.Name} {sdk.Version?.Major}, or rebuild it."
            + $"\n\nTo turn off this check, call AppContext.SetSwitch(\"{Switch}\", false).";
    }

#if NET
    [UnconditionalSuppressMessage(
        "Trimming",
        "IL2026",
        Justification = "An assembly whose references were trimmed is left unchecked."
    )]
#endif
    internal static List<(
        AssemblyName Assembly,
        AssemblyName Reference
    )> FindIncompatibleReferences(AssemblyName root, AssemblyName target)
    {
        var incompatible = new List<(AssemblyName Assembly, AssemblyName Reference)>();
        var seen = new HashSet<string?>();
        var pending = new Stack<AssemblyName>();
        pending.Push(root);
        while (pending.Count > 0)
        {
            Assembly assembly;
            AssemblyName[] references;
            try
            {
                assembly = Assembly.Load(pending.Pop());
                references = assembly.GetReferencedAssemblies();
            }
            catch (Exception)
            {
                // An assembly that can't be read, such as one that wasn't deployed, is left unchecked.
                continue;
            }

            foreach (var reference in references)
            {
                // Loading all of .NET is slow, and no part of it references an SDK.
                var isPartOfDotNet =
                    reference.Name is "mscorlib" or "netstandard" or "System"
                    || reference.Name?.StartsWith("System.", StringComparison.Ordinal) == true;
                if (reference.Name == target.Name)
                {
                    if (reference.Version?.Major != target.Version?.Major)
                    {
                        incompatible.Add((assembly.GetName(), reference));
                    }
                }
                else if (!isPartOfDotNet && seen.Add(reference.Name))
                {
                    pending.Push(reference);
                }
            }
        }

        return incompatible;
    }
}
