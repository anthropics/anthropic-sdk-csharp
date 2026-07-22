using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// The warning funnel for one <see cref="BetaRefusalFallbackHandler"/>: every message the
/// fallback machinery emits goes through here, and the once-per-handler latches live here.
/// The handler owns one instance for its lifetime, shared by both protocols, so (for example)
/// a streaming missing-token warning suppresses the non-streaming one.
/// </summary>
internal sealed class FallbackDiagnostics
{
    /// <summary>An overriding warning sink; when null, warnings go to whatever
    /// <see cref="Console.Error"/> is at the moment of writing (resolved lazily so a runtime
    /// redirect, from tests or host logging, takes effect).</summary>
    readonly TextWriter? _writer;

    int _warnedMissingState;
    int _warnedMissingToken;

    /// <summary>Delta types the splice can't accumulate into a prefill, each warned once.</summary>
    readonly ConcurrentDictionary<string, byte> _warnedDeltaTypes = new();

    /// <param name="writer">Warning sink; defaults to standard error, resolved at write time.</param>
    public FallbackDiagnostics(TextWriter? writer = null)
    {
        _writer = writer;
    }

    TextWriter Writer => _writer ?? Console.Error;

    public void Warn(string message) =>
        Writer.WriteLine($"WARNING: `BetaRefusalFallbackHandler`: {message}");

    public void WarnHopFailure(string model, HttpStatusCode statusCode, string body) =>
        Warn($"fallback request to {model} failed: HTTP {(int)statusCode}: {body}");

    public void WarnHopException(string model, Exception exception) =>
        Warn($"fallback request to {model} failed: {exception}");

    /// <param name="consequence">What the missing token means for this request.</param>
    /// <param name="betaEnabled">Whether a credit token already arrived this request, proof the
    /// fallback-credit beta is enabled, which rules that cause out of the warning.</param>
    public void WarnMissingTokenOnce(string consequence, bool betaEnabled)
    {
        if (Interlocked.Exchange(ref _warnedMissingToken, 1) == 0)
        {
            Warn(
                $"refusal stop_details has no fallback_credit_token, so {consequence}; the "
                    + "refusal may be ineligible for a fallback credit"
                    + (
                        betaEnabled
                            ? ""
                            : ", or the fallback-credit beta may not be enabled for this account"
                    )
            );
        }
    }

    public void WarnMissingStateOnce()
    {
        if (Interlocked.Exchange(ref _warnedMissingState, 1) == 0)
        {
            Writer.WriteLine(
                "WARNING: `BetaRefusalFallbackHandler` fell back without an ambient "
                    + "`BetaFallbackState`; follow-up requests will retry models that already "
                    + "refused. Wrap requests that should share the pin in a "
                    + "`BetaFallbackState.Create()` scope via `using (state.Use()) { ... }` to "
                    + "pin them to the accepted model."
            );
        }
    }

    public void WarnDeltaTypeOnce(string type)
    {
        if (_warnedDeltaTypes.TryAdd(type, 0))
        {
            Warn(
                $"content_block_delta type \"{type}\" is not accumulated; a continuation prefill "
                    + "including its block may be rejected and retried without the prefill"
            );
        }
    }

    /// <summary>Reads a failed hop response's error body, disposing the response.</summary>
    public static async Task<string> ReadErrorBody(
        HttpResponseMessage response,
        CancellationToken cancellationToken
    )
    {
        using (response)
        {
            try
            {
                return await response
                    .Content.ReadAsStringAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e) when (e is not OperationCanceledException)
            {
                return "";
            }
        }
    }
}
