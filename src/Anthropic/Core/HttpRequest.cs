using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace Anthropic.Core;

public sealed class HttpRequest<P>
    where P : ParamsBase
{
    public required HttpMethod Method { get; init; }

    public required P Params { get; init; }

    /// <summary>
    /// The name of the request's span. Set by the SDK method that sends the request.
    /// </summary>
    internal string? SpanName { get; init; }

    /// <summary>
    /// The resource IDs of the request's span: the name of the attribute of each parameter in the
    /// request's path, with the parameter's value. Set by the SDK method that sends the request,
    /// from its arguments. An ID without a value is left out. A method that knows more of its
    /// request before it is sent adds that here too.
    /// </summary>
    internal IReadOnlyList<KeyValuePair<string, object?>>? SpanResourceIds { get; init; }

    /// <summary>
    /// The request's span, when the SDK method that sends the request started it itself
    /// (<see cref="Tracing.StartApiCallSpan"/>) to give it what it knows of its request and
    /// response. The client then uses it in place of one named <see cref="SpanName"/>.
    /// </summary>
    internal Activity? Span { get; init; }

    public override string ToString() =>
        string.Format("Method: {0}\n{1}", this.Method.ToString(), this.Params.ToString());

    public override bool Equals(object? obj)
    {
        if (obj is not HttpRequest<P> other)
        {
            return false;
        }

        return this.Method.Equals(other.Method) && this.Params.Equals(other.Params);
    }

    public override int GetHashCode() => 0;
}
