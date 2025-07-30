using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Anthropic.Models.Completions;

namespace Anthropic.Service.Completions;

public sealed class CompletionService : ICompletionService
{
    readonly IAnthropicClient _client;

    public CompletionService(IAnthropicClient client)
    {
        _client = client;
    }

    public async Task<Completion> Create(CompletionCreateParams @params)
    {
        HttpRequestMessage webRequest = new(HttpMethod.Post, @params.Url(this._client))
        {
            Content = @params.BodyContent(),
        };
        @params.AddHeadersToRequest(webRequest, this._client);
        using HttpResponseMessage response = await _client.HttpClient.SendAsync(webRequest);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new HttpException(e.StatusCode, await response.Content.ReadAsStringAsync());
        }
        return JsonSerializer.Deserialize<Completion>(await response.Content.ReadAsStringAsync())
            ?? throw new NullReferenceException();
    }
}
