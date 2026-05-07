using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic;
using Anthropic.Core;

namespace Anthropic.Tests;

/// <summary>
/// This is the TestBase compat used as an intermediary solution until multiple providers can be supported via codegen.
/// </summary>
public abstract class TestBase
{
    protected IAnthropicClient client;

    /// <summary>
    /// This class is only used by codegen tests and should not be used for hand written tests. Use the <see cref="AnthropicTestClientsAttribute"/> instead.
    /// </summary>
    public TestBase()
    {
        client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = AnthropicTestClientsAttribute.ApiKey,
                BaseUrl = AnthropicTestClientsAttribute.DataServiceUrl,
            }
        );
    }

    internal static bool UrisEqual(Uri uri1, Uri uri2)
    {
        if (
            uri1.Scheme != uri2.Scheme
            || uri1.Host != uri2.Host
            || uri1.Port != uri2.Port
            || uri1.AbsolutePath != uri2.AbsolutePath
        )
        {
            return false;
        }

        var query1 = ParseQueryString(uri1.Query);
        var query2 = ParseQueryString(uri2.Query);

        return Enumerable.SequenceEqual(query1, query2);
    }

    static SortedDictionary<string, string> ParseQueryString(string query)
    {
        var ret = new SortedDictionary<string, string>(StringComparer.Ordinal);

        if (string.IsNullOrEmpty(query))
            return ret;

        var pairs = query.TrimStart('?').Split(['&'], StringSplitOptions.RemoveEmptyEntries);

        foreach (var pair in pairs)
        {
            var parts = pair.Split(['&'], 2);
            var key = Uri.UnescapeDataString(parts[0]);
            var value = parts.Length > 1 ? Uri.UnescapeDataString(parts[1]) : string.Empty;
            ret[key] = value;
        }

        return ret;
    }
}
