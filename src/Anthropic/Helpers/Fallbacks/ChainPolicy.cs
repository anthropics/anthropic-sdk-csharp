using System.Collections.Generic;

namespace Anthropic.Helpers.Fallbacks;

/// <summary>
/// The decision core of the fallback chain: pure state, no HTTP, no JSON.
///
/// <para>One instance drives one intercepted request. The executor (buffered or spliced) sends
/// hops and classifies responses; every <em>decision</em> is made here, once for both
/// protocols: which entry next, whether the credit token carries, whether a 400 earns a
/// one-shot reduced retry, when to deliver, what to pin. The executor reports observations
/// (<see cref="OnRefusal"/>, <see cref="OnHopError"/>, <see cref="OnServed"/>) and acts on the
/// returned <see cref="Directive"/>.</para>
///
/// <para>The two protocols differ in one negotiable "extra" their hop requests carry beyond the
/// token binding, and in which side wins a conflict: a buffered hop's extra is the credit token
/// itself (entry overrides may be what makes the fallback accept, so on a 400 the token is
/// dropped and the overrides kept), while a spliced hop's extra is the prefill (the continuation
/// requires the token, so on a 400 the prefill is dropped and the token kept). The
/// <see cref="Mode"/> selects which rule applies; the retry-once shape is shared.</para>
///
/// <para>Thread-safety: none needed; an instance belongs to a single sequential run.</para>
/// </summary>
internal sealed class ChainPolicy
{
    public enum Mode
    {
        /// <summary>Non-streaming. Tokenless refusals still chain; the droppable extra is the
        /// credit token (dropped only when entry overrides could conflict with it).</summary>
        Buffered,

        /// <summary>Streaming splice. Tokenless refusals cannot chain (the continuation requires
        /// the token); the droppable extra is the prefill.</summary>
        Spliced,
    }

    /// <summary>What the executor should do next.</summary>
    public enum Directive
    {
        /// <summary>Send the request for <see cref="CurrentIndex"/> with
        /// <see cref="CarriedToken"/>, extras allowed.</summary>
        SendEntry,

        /// <summary>Resend <see cref="CurrentIndex"/> once with the mode's droppable extra
        /// removed (buffered: no token; spliced: no prefill).</summary>
        ResendWithoutExtra,

        /// <summary>Deliver the response in hand to the caller (prepending transition blocks first if
        /// <see cref="Refusals"/> is non-empty and the response served).</summary>
        Deliver,

        /// <summary>Spliced only: the last entry failed outright with the caller's stream still
        /// open, so emit the held refusal and close.</summary>
        DegradedClose,
    }

    /// <summary>One recorded refusal: the entry it happened at (-1 = the original request) and
    /// its trigger category. The refusals recorded form the transition and iterations record.</summary>
    public readonly record struct RefusalRecord(int Index, string? Category);

    readonly Mode _mode;
    readonly int _entryCount;

    /// <summary>Whether each entry carries params beyond <c>model</c> (token-binding conflict
    /// candidates). Index -1 (the original request) never does.</summary>
    readonly IReadOnlyList<bool> _hasNonModelOverrides;

    readonly List<RefusalRecord> _refusals = [];

    /// <summary>The entry the token in hand was minted against; the refused request carried its
    /// overrides.</summary>
    int _mintedIndex;

    bool _retriedWithoutExtra;
    bool _tokenSeen;

    public ChainPolicy(
        Mode mode,
        int entryCount,
        IReadOnlyList<bool> hasNonModelOverrides,
        int initialIndex
    )
    {
        _mode = mode;
        _entryCount = entryCount;
        _hasNonModelOverrides = hasNonModelOverrides;
        CurrentIndex = initialIndex;
        _mintedIndex = initialIndex;
    }

    /// <summary>The entry whose request is in flight or was answered last (-1 = the original
    /// request).</summary>
    public int CurrentIndex { get; private set; }

    /// <summary>The unredeemed credit token to attach to the next hop, if any.</summary>
    public string? CarriedToken { get; private set; }

    /// <summary>The latest refusal's trigger category (spliced boundaries repeat it after a
    /// failed hop).</summary>
    public string? CarriedCategory { get; private set; }

    /// <summary>Whether the latest refusal granted a prefill claim (spliced only).</summary>
    public bool CarriedPrefillClaim { get; private set; }

    /// <summary>Whether any refusal this run carried a credit token, proof the fallback-credit
    /// beta is enabled; scopes the missing-token warning.</summary>
    public bool TokenSeen => _tokenSeen;

    /// <summary>Every refusal recorded this run, in order: the transition record.</summary>
    public IReadOnlyList<RefusalRecord> Refusals => _refusals;

    bool AtLastEntry => CurrentIndex >= _entryCount - 1;

    /// <summary>
    /// The response in hand is a refusal. Chains to the next entry when possible (recording the
    /// refusal, carrying its token, resetting the retry-once budget), else delivers it. Buffered
    /// mode chains tokenless refusals, since the next entry's overrides may make the difference;
    /// spliced mode cannot, since the continuation requires the token.
    /// </summary>
    public Directive OnRefusal(string? token, string? category, bool prefillClaim)
    {
        if (token != null)
        {
            _tokenSeen = true;
        }
        var chainable = !AtLastEntry && (_mode == Mode.Buffered || token != null);
        if (!chainable)
        {
            return Directive.Deliver;
        }
        _refusals.Add(new RefusalRecord(CurrentIndex, category));
        _mintedIndex = CurrentIndex;
        CarriedToken = token;
        CarriedCategory = category;
        CarriedPrefillClaim = prefillClaim;
        CurrentIndex++;
        _retriedWithoutExtra = false;
        return Directive.SendEntry;
    }

    /// <summary>
    /// The hop request for <see cref="CurrentIndex"/> failed: transport exception
    /// (<paramref name="badRequest"/> false) or non-2xx. Grants one reduced retry when a 400
    /// plausibly rejected the mode's extra; otherwise skips to the next entry (the token was
    /// never redeemed and carries) or ends the chain (buffered: deliver the error response;
    /// spliced: degraded close).
    /// </summary>
    /// <param name="badRequest">Whether the failure was HTTP 400.</param>
    /// <param name="extraIncluded">Whether the failed request carried the mode's extra
    /// (buffered: a token; spliced: a prefill).</param>
    public Directive OnHopError(bool badRequest, bool extraIncluded)
    {
        // No refusal has chained yet: this is the run's first response, and its error gets normal
        // handling; only hops issued *while chaining* are skipped or retried.
        if (_refusals.Count == 0)
        {
            return Directive.Deliver;
        }
        if (badRequest && extraIncluded && !_retriedWithoutExtra && ExtraCanConflict())
        {
            _retriedWithoutExtra = true;
            return Directive.ResendWithoutExtra;
        }
        if (AtLastEntry)
        {
            return _mode == Mode.Buffered ? Directive.Deliver : Directive.DegradedClose;
        }
        CurrentIndex++;
        _retriedWithoutExtra = false;
        return Directive.SendEntry;
    }

    /// <summary>
    /// Whether the mode's extra can be what the server rejected. Spliced: any included prefill.
    /// Buffered: the token conflicts only when the attempted entry or the minted entry carries
    /// non-model overrides, since a model-only swap is always within the token binding.
    /// </summary>
    bool ExtraCanConflict() =>
        _mode == Mode.Spliced
        || HasNonModelOverrides(CurrentIndex)
        || HasNonModelOverrides(_mintedIndex);

    bool HasNonModelOverrides(int index) => index >= 0 && _hasNonModelOverrides[index];

    /// <summary>
    /// The response in hand served (any 2xx non-refusal, unparseable bodies included). Returns
    /// the entry index to pin, or <c>null</c> when nothing should be pinned: pin only when at
    /// least one refusal chained this run, which structurally implies the serving index is a
    /// real entry, never -1.
    /// </summary>
    public int? OnServed() => _refusals.Count > 0 ? CurrentIndex : null;
}
