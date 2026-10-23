using System.Collections.Generic;
using System.Net.Http;

namespace Anthropic.Core;

/// <summary>
/// The query pairs that tell an operation apart from the others with its path in the OpenAPI
/// document, for the handlers of the client. Every attempt of an API call has them.
/// </summary>
internal static class Qualifiers
{
    const string Option = "Anthropic.qualifiers";

    /// <summary>
    /// Returns what the SDK method that sends <paramref name="request"/> set, or null when it
    /// set nothing.
    /// </summary>
    internal static IReadOnlyDictionary<string, string>? From(HttpRequestMessage request)
    {
#if NET
        request.Options.TryGetValue(
            new HttpRequestOptionsKey<IReadOnlyDictionary<string, string>>(Option),
            out var qualifiers
        );
        return qualifiers;
#else
        return request.Properties.TryGetValue(Option, out var qualifiers)
            ? qualifiers as IReadOnlyDictionary<string, string>
            : null;
#endif
    }

    internal static void Attach(
        HttpRequestMessage request,
        IReadOnlyDictionary<string, string>? qualifiers
    )
    {
        if (qualifiers == null)
        {
            return;
        }
#if NET
        request.Options.Set(
            new HttpRequestOptionsKey<IReadOnlyDictionary<string, string>>(Option),
            qualifiers
        );
#else
        request.Properties[Option] = qualifiers;
#endif
    }
}
