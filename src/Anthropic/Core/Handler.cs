using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Core;

/// <summary>
/// Calls the next handler in the handler chain.
/// </summary>
public delegate Task<HttpResponseMessage> NextHandler(
    HttpRequestMessage request,
    CancellationToken cancellationToken
);

/// <summary>
/// Provides helpers for creating <see cref="DelegatingHandler"/>s.
/// </summary>
public static class Handler
{
    /// <summary>
    /// Creates a handler from the given function.
    ///
    /// <para>The function receives the request, a function that calls the next handler
    /// in the handler chain, and a cancellation token.</para>
    /// </summary>
    public static DelegatingHandler Create(
        Func<HttpRequestMessage, NextHandler, CancellationToken, Task<HttpResponseMessage>> function
    ) => new FunctionHandler(function);

    sealed class FunctionHandler : DelegatingHandler
    {
        readonly Func<
            HttpRequestMessage,
            NextHandler,
            CancellationToken,
            Task<HttpResponseMessage>
        > _function;

        public FunctionHandler(
            Func<
                HttpRequestMessage,
                NextHandler,
                CancellationToken,
                Task<HttpResponseMessage>
            > function
        )
        {
            _function = function;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            return _function(request, base.SendAsync, cancellationToken);
        }
    }
}
