using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic;

namespace Anthropic.Tests;

public class TestBase
{
    protected IAnthropicClient client;

    public TestBase()
    {
        client = new AnthropicClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "my-anthropic-api-key",
        };
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
