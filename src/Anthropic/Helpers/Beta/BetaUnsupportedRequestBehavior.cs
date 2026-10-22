namespace Anthropic.Helpers.Beta;

/// <summary>
/// What a message thread does when the API answers that it cannot serve a request on a thread
/// (an error whose <c>error.details.error_code</c> is <c>thread_unsupported_request</c>).
/// </summary>
public enum BetaUnsupportedRequestBehavior
{
    /// <summary>The error reaches the caller. It is the default.</summary>
    Error,

    /// <summary>
    /// The turn is sent again without a thread, with the whole history, and so is every later
    /// turn.
    /// </summary>
    ContinueUnthreaded,
}
