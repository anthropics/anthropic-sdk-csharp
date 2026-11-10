using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Exceptions;

namespace Anthropic.Tests;

/// <summary>
/// A successful response whose body doesn't deserialize fails with
/// <see cref="AnthropicInvalidDataException"/>, like a stream item that doesn't.
/// </summary>
public class ResponseDeserializationTest
{
    [Theory]
    [InlineData("<html><body>502 Bad Gateway</body></html>")]
    [InlineData("")]
    [InlineData("{\"id\":")]
    [InlineData("[]")]
    public async Task SuccessfulResponse_BodyThatDoesNotDeserialize_ThrowsInvalidData(string body)
    {
        using AnthropicClient client = new()
        {
            ApiKey = "test-key",
            HttpClient = new(new FixedResponseHandler(body)),
        };

        var exception = await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            client.Models.Retrieve(
                "claude-opus-4-6",
                cancellationToken: TestContext.Current.CancellationToken
            )
        );

        Assert.IsType<JsonException>(exception.InnerException, exactMatch: false);
    }

    sealed class FixedResponseHandler(string body) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) =>
            Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(body) }
            );
    }
}
