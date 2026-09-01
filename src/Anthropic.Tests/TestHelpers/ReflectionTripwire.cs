using System;
using System.Linq;
using System.Reflection;

namespace Anthropic.Tests.TestHelpers;

/// <summary>
/// Lists the public instance properties a generated model declares, so aggregator tests can
/// pin the exact field set they hand-copy and fail when codegen adds one.
/// </summary>
static class ReflectionTripwire
{
    internal static string[] DeclaredPropertyNames(Type type) =>
        [
            .. type.GetProperties(
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
                )
                .Select(p => p.Name)
                .OrderBy(n => n, StringComparer.Ordinal),
        ];
}
