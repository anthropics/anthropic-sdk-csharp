using System;
using System.Collections.Generic;
using System.Net.Http;
using Anthropic;
using Anthropic.Core;

namespace Anthropic.Tests;

internal static class TestClientExtensions
{
    /// <summary>
    /// Returns a client that adds <paramref name="query"/> to the query string of each request.
    /// The mock server needs it to tell two operations with the same path apart.
    /// </summary>
    internal static IAnthropicClient WithQuery(this IAnthropicClient client, string query)
    {
        return client.WithOptions(options =>
            options with
            {
                Handlers = new List<DelegatingHandler>
                {
                    Handler.Create(
                        (request, next, cancellationToken) =>
                        {
                            var uri = new UriBuilder(request.RequestUri!);
                            uri.Query = string.IsNullOrEmpty(uri.Query)
                                ? query
                                : uri.Query.TrimStart('?') + "&" + query;
                            request.RequestUri = uri.Uri;
                            return next(request, cancellationToken);
                        }
                    ),
                },
            }
        );
    }
}
