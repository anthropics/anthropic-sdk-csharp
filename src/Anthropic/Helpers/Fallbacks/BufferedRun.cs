using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// Executes the fallback chain for a non-streaming request: sends hops, classifies buffered
/// responses, and carries out the <see cref="ChainPolicy"/>'s directives. It owns transport
/// and response lifetime only; every decision is the policy's.
/// </summary>
internal sealed class BufferedRun
{
    /// <summary>A refusal read off a buffered response; the credit token and category are each
    /// absent when the refusal didn't carry them.</summary>
    sealed record RefusalDetails(string? Token, string? Category);

    readonly RequestSnapshot _snapshot;
    readonly ChainPolicy _policy;
    readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _send;

    /// <summary>Whether the request in flight carries the credit token, the buffered mode's
    /// droppable extra.</summary>
    bool _tokenAttached;

    public BufferedRun(
        RequestSnapshot snapshot,
        ChainPolicy policy,
        Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send
    )
    {
        _snapshot = snapshot;
        _policy = policy;
        _send = send;
    }

    public async Task<HttpResponseMessage> Run(CancellationToken cancellationToken)
    {
        var response = await _send(_snapshot.Request(_policy.CurrentIndex), cancellationToken)
            .ConfigureAwait(false);

        while (true)
        {
            if (!response.IsSuccessStatusCode)
            {
                var retry = await RetryFailedHop(response, cancellationToken).ConfigureAwait(false);
                if (retry == null)
                {
                    return response; // normal error handling gets the response unread
                }
                response = retry;
                continue;
            }

            RefusalDetails? refusal;
            try
            {
                refusal = await TryReadRefusal(response, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // The response never reaches the caller; release it (and its connection).
                response.Dispose();
                throw;
            }

            if (refusal == null)
            {
                // Pin only a fallback that accepted; a refused last entry must not capture
                // follow-up requests sharing the state.
                if (_policy.OnServed() is { } pinIndex)
                {
                    _snapshot.Pin(pinIndex);
                    await WireShape
                        .PrependTransitionBlocks(
                            response,
                            ModelTransitions(pinIndex),
                            cancellationToken
                        )
                        .ConfigureAwait(false);
                }
                return response;
            }

            var afterRefusal = _policy.OnRefusal(
                refusal.Token,
                refusal.Category,
                prefillClaim: false
            );
            if (afterRefusal == ChainPolicy.Directive.Deliver)
            {
                return response; // chain exhausted: deliver the refusal
            }
            // A tokenless refusal still chains, since the next entry's params may make the
            // difference, but the retry's cache-miss cost isn't refunded.
            if (refusal.Token == null)
            {
                _snapshot.Diagnostics.WarnMissingTokenOnce(
                    "the retry's cache-miss cost isn't refunded",
                    betaEnabled: _policy.TokenSeen
                );
            }
            response.Dispose();
            response = await SendHop(afterRefusal, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reports a failed hop to the policy and issues the retry it directs: the next entry, or
    /// the same entry without the credit token when a 400 rejected it. Returns null when the
    /// error should reach the caller instead: the run's initial response, or the last entry's,
    /// which stay unread.
    /// </summary>
    async Task<HttpResponseMessage?> RetryFailedHop(
        HttpResponseMessage failedResponse,
        CancellationToken cancellationToken
    )
    {
        var failedIndex = _policy.CurrentIndex;
        var directive = _policy.OnHopError(
            badRequest: failedResponse.StatusCode == HttpStatusCode.BadRequest,
            extraIncluded: _tokenAttached
        );
        if (directive == ChainPolicy.Directive.Deliver)
        {
            return null;
        }
        var errorBody = await FallbackDiagnostics
            .ReadErrorBody(failedResponse, cancellationToken)
            .ConfigureAwait(false);
        if (directive == ChainPolicy.Directive.ResendWithoutExtra)
        {
            _snapshot.Diagnostics.Warn(
                "fallback request with the entry's overrides and the credit token was "
                    + $"rejected (HTTP 400: {errorBody}); retrying without the token"
            );
        }
        else
        {
            // A hop that failed outright never redeemed the token, so it carries to the next
            // entry.
            _snapshot.Diagnostics.WarnHopFailure(
                _snapshot.Entries[failedIndex].Model.Raw(),
                failedResponse.StatusCode,
                errorBody
            );
        }
        return await SendHop(directive, cancellationToken).ConfigureAwait(false);
    }

    Task<HttpResponseMessage> SendHop(
        ChainPolicy.Directive directive,
        CancellationToken cancellationToken
    )
    {
        var token =
            directive == ChainPolicy.Directive.ResendWithoutExtra ? null : _policy.CarriedToken;
        _tokenAttached = token != null;
        return _send(_snapshot.Request(_policy.CurrentIndex, token), cancellationToken);
    }

    /// <summary>
    /// One (from, to, category) triple per model boundary: each refused entry into the next,
    /// and the last refused entry into the serving one.
    /// </summary>
    List<WireShape.ModelTransition> ModelTransitions(int servingIndex)
    {
        var refusals = _policy.Refusals;
        List<WireShape.ModelTransition> transitions = [];
        for (var i = 0; i < refusals.Count; i++)
        {
            var to = i + 1 < refusals.Count ? refusals[i + 1].Index : servingIndex;
            transitions.Add(
                new WireShape.ModelTransition(
                    _snapshot.ModelAt(refusals[i].Index),
                    _snapshot.ModelAt(to),
                    refusals[i].Category
                )
            );
        }
        return transitions;
    }

    /// <summary>
    /// Reads the response as a message and returns its refusal details, or <c>null</c> when it
    /// isn't a refused message and should be returned as-is.
    /// </summary>
    static async Task<RefusalDetails?> TryReadRefusal(
        HttpResponseMessage response,
        CancellationToken cancellationToken
    )
    {
        // Reading the content buffers it, so a non-refusal response stays fully readable.
        var body = await response
            .Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);
        try
        {
            var message = JsonSerializer.Deserialize<BetaMessage>(
                body,
                ModelBase.SerializerOptions
            );
            if (
                message?.StopReason is not { } stopReason
                || stopReason.Value() != BetaStopReason.Refusal
            )
            {
                return null;
            }
            return new RefusalDetails(
                message.StopDetails?.FallbackCreditToken,
                message.StopDetails?.Category?.Raw()
            );
        }
        catch (Exception e) when (e is JsonException or AnthropicInvalidDataException)
        {
            // Pass unexpected response shapes (e.g. errors) through for normal handling.
            return null;
        }
    }
}
