using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Anthropic.Tests;

public class NamingConventionTest
{
    static readonly Type[] Exemptions = [typeof(Microsoft.Extensions.AI.AIContentCacheExtensions)];

    /// <summary>
    /// Public types declared in namespaces the SDK doesn't own (the <c>Microsoft.Extensions.AI</c>
    /// extension classes, for instance) carry an <c>Anthropic</c> prefix so they can't collide with
    /// types the namespace owner adds later.
    /// </summary>
    [Fact]
    public void PublicTypesOutsideAnthropicNamespaces_ShouldHaveAnthropicPrefix()
    {
        var sdkAssemblies = Directory
            .EnumerateFiles(AppContext.BaseDirectory, "Anthropic*.dll")
            .Select(path => Path.GetFileNameWithoutExtension(path))
            .Where(name => name != "Anthropic.Tests")
            .Select(name => Assembly.Load(new AssemblyName(name)))
            .ToList();
        Assert.Contains(typeof(AnthropicClient).Assembly, sdkAssemblies);

        var violations = sdkAssemblies
            .SelectMany(assembly => assembly.GetExportedTypes())
            .Where(type =>
                !type.IsNested
                && !IsAnthropicNamespace(type.Namespace)
                && !type.Name.StartsWith("Anthropic", StringComparison.Ordinal)
            )
            .Except(Exemptions)
            .Select(type => type.FullName)
            .ToList();

        if (violations.Count > 0)
        {
            Assert.Fail(
                "Public types outside the Anthropic namespaces need an 'Anthropic' name prefix"
                    + $" (or to be made internal):\n{string.Join("\n", violations)}"
            );
        }
    }

    static bool IsAnthropicNamespace(string? ns) =>
        ns is not null
        && (ns == "Anthropic" || ns.StartsWith("Anthropic.", StringComparison.Ordinal));
}
