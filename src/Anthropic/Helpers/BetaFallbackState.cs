using System;
using System.Threading;

namespace Anthropic.Helpers;

/// <summary>
/// Tracks which fallback a sequence of requests is pinned to.
///
/// <para>Create one (<see cref="Create"/>) and wrap every request that should share the pin in a
/// <see cref="Use"/> scope — the turns of one conversation, or any wider scope the stickiness
/// should apply to; <see cref="BetaRefusalFallbackHandler"/> mutates it in place when a model
/// refuses:</para>
///
/// <code>
/// BetaFallbackState fallbackState = BetaFallbackState.Create();
/// using (fallbackState.Use())
/// {
///     BetaMessage message = await client.Beta.Messages.Create(parameters);
/// }
/// </code>
/// </summary>
public sealed class BetaFallbackState
{
    static readonly AsyncLocal<BetaFallbackState?> _current = new();

    int _index = -1;

    BetaFallbackState() { }

    /// <summary>
    /// Returns a new <see cref="BetaFallbackState"/> pinned to the original request params.
    /// </summary>
    public static BetaFallbackState Create() => new();

    /// <summary>
    /// The state the current async flow is scoped to via <see cref="Use"/>, if any.
    /// </summary>
    internal static BetaFallbackState? Current => _current.Value;

    /// <summary>
    /// The index into the fallback chain the requests are pinned to.
    ///
    /// <para>-1 targets the original request params; the handler sets it to the index of the
    /// fallback that accepted the request.</para>
    /// </summary>
    public int Index
    {
        get => Volatile.Read(ref _index);
        set => Volatile.Write(ref _index, value);
    }

    /// <summary>
    /// Scopes this state to the current async flow until the returned scope is disposed.
    ///
    /// <para>Requests made inside the scope (on the same async flow) share this state's pin. The
    /// state is carried by an <see cref="AsyncLocal{T}"/>, so it flows across <c>await</c>s but
    /// not to work started before the scope opened.</para>
    /// </summary>
    public IDisposable Use()
    {
        var previous = _current.Value;
        _current.Value = this;
        return new Scope(previous);
    }

    sealed class Scope : IDisposable
    {
        readonly BetaFallbackState? _previous;

        public Scope(BetaFallbackState? previous)
        {
            _previous = previous;
        }

        public void Dispose() => _current.Value = _previous;
    }
}
