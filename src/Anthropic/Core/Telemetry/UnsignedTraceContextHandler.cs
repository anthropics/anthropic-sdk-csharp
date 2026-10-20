using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Core.Telemetry;

/// <summary>
/// Hides the trace-context headers (<see cref="TraceContextHeaders"/>) of each request from a
/// backend adaptation handler and puts them back before the HTTP client sends it, so that a handler
/// that signs every header it sees, as earlier cloud-platform packages do, leaves them unsigned.
/// </summary>
sealed class UnsignedTraceContextHandler : DelegatingHandler
{
    const string HeldHeadersOption = "com.anthropic.sdk.csharp.held_trace_context_headers";

    public UnsignedTraceContextHandler(
        DelegatingHandler backendAdaptationHandler,
        HttpMessageHandler innerHandler
    )
        : base(backendAdaptationHandler)
    {
        backendAdaptationHandler.InnerHandler = new RestoringHandler(innerHandler);
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        Dictionary<string, string[]> held = [];
        foreach (var name in TraceContextHeaders.Names())
        {
            if (request.Headers.TryGetValues(name, out var values))
            {
                held.Add(name, [.. values]);
                request.Headers.Remove(name);
            }
        }
#if NET
        request.Options.Set(new(HeldHeadersOption), held);
#else
        request.Properties[HeldHeadersOption] = held;
#endif
        return base.SendAsync(request, cancellationToken);
    }

    sealed class RestoringHandler(HttpMessageHandler innerHandler) : DelegatingHandler(innerHandler)
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
#if NET
            request.Options.TryGetValue(
                new HttpRequestOptionsKey<Dictionary<string, string[]>>(HeldHeadersOption),
                out var held
            );
#else
            var held = request.Properties.TryGetValue(HeldHeadersOption, out var value)
                ? value as Dictionary<string, string[]>
                : null;
#endif
            foreach (var header in held ?? [])
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
