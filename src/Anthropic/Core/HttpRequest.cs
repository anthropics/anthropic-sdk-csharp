using System.Net.Http;

namespace Anthropic.Core;

public sealed class HttpRequest<P>
    where P : ParamsBase
{
    public required HttpMethod Method { get; init; }

    public required P Params { get; init; }

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
