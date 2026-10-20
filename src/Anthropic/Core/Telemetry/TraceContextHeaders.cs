using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// The request headers that carry the trace context. The client sends them with each attempt, and
/// an HTTP instrumentation below the SDK may replace them with the context of its own span after
/// the request is signed. A client that signs its requests therefore leaves them out of the
/// signature, which would otherwise no longer match the request that arrives.
/// </summary>
static class TraceContextHeaders
{
    /// <summary>
    /// The names of the trace-context headers for the request at hand: those of the W3C formats,
    /// and those that the propagator registered now writes, compared without regard to case.
    /// </summary>
    internal static HashSet<string> Names()
    {
        var names = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "traceparent",
            "tracestate",
            "baggage",
        };
        try
        {
            names.UnionWith(DistributedContextPropagator.Current.Fields);
        }
        catch (Exception)
        {
            // A propagator that fails to say what it writes must not fail the request.
        }
        return names;
    }

    /// <summary>
    /// <paramref name="headers"/>, the headers of a request, without the trace-context ones: the
    /// headers that a signature of the request covers.
    /// </summary>
    internal static IEnumerable<KeyValuePair<string, IEnumerable<string>>> Signed(
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers
    )
    {
        var unsigned = Names();
        foreach (var header in headers)
        {
            if (!unsigned.Contains(header.Key))
            {
                yield return header;
            }
        }
    }
}
