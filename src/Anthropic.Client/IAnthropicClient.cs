using System;
using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Services.Beta;
using Anthropic.Client.Services.Messages;
using Anthropic.Client.Services.Models;

namespace Anthropic.Client;

public interface IAnthropicClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    TimeSpan Timeout { get; init; }

    string? APIKey { get; init; }

    string? AuthToken { get; init; }

    IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageService Messages { get; }

    IModelService Models { get; }

    IBetaService Beta { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
