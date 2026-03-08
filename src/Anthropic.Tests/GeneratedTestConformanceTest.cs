using System;
using System.Linq;
using System.Reflection;

namespace Anthropic.Tests;

/// <summary>
/// Ensures no generated service test method is left with a [Fact] attribute.
///
/// Generated service test classes (e.g. FileServiceTest) inherit <see cref="TestBase"/> and contain
/// the raw test logic. Their methods intentionally have no [Fact] so they don't run directly.
/// Multi-client wrappers (e.g. FileServiceMultiClientTest) subclass them and add [Theory] +
/// [AnthropicTestClients] to run each method against all supported client implementations.
///
/// When codegen adds a new method it will arrive with [Fact]. This test will then warn, telling
/// the developer to: (1) add a [Theory] wrapper in the corresponding *MultiClientTest file, and
/// (2) remove the [Fact] attribute from the generated file.
///
/// Note: only classes in the Anthropic.Tests.Services.* namespace are checked — custom test
/// helpers that extend TestBase for convenience (e.g. SseTest) are excluded.
/// Note: [Fact(Skip = ...)] methods are also excluded — these are generated endpoints that the mock
/// server cannot serve and do not need *MultiClientTest wrappers.
/// </summary>
public class GeneratedTestConformanceTest
{
    [Fact]
    public void GeneratedTestMethods_ShouldNotHaveFactAttribute()
    {
        var violations = typeof(TestBase)
            .Assembly.GetTypes()
            .Where(t =>
                t.IsSubclassOf(typeof(TestBase))
                && !t.IsAbstract
                && t.Namespace?.StartsWith("Anthropic.Tests.Services") == true
            )
            .SelectMany(t =>
                t.GetMethods(
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
                )
            )
            .Where(m =>
                m.GetCustomAttributes()
                    .OfType<FactAttribute>()
                    .Any(a => a.GetType() == typeof(FactAttribute) && string.IsNullOrEmpty(a.Skip))
            )
            .Select(m => $"{m.DeclaringType!.Name}.{m.Name}")
            .ToList();

        if (violations.Count > 0)
        {
            Console.WriteLine(
                "WARNING: The following generated test methods still have [Fact] and need a [Theory] wrapper"
                    + $" in their *MultiClientTest file:\n{string.Join("\n", violations)}"
            );
        }
    }
}
