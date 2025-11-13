using System.Net.Http;

namespace Anthropic.Core;

public sealed class HttpRequest<P>
    where P : ParamsBase
{
    public required HttpMethod Method { get; init; }

    public required P Params { get; init; }
}
