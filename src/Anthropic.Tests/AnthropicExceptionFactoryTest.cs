using System.Net;
using System.Threading.Tasks;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;
using Anthropic.Tests.Helpers;

namespace Anthropic.Tests;

public class AnthropicExceptionFactoryTest
{
    static MessageCreateParams MessageParams =>
        new()
        {
            MaxTokens = 1024,
            Messages = [new UserMessageParam { Content = "Hello, world" }],
            Model = Model.ClaudeOpus4_6,
        };

    [Theory]
    [InlineData(
        """[{"error":{"code":403,"message":"Permission denied on resource","status":"PERMISSION_DENIED"}}]"""
    )]
    [InlineData("""{"error":"text"}""")]
    public async Task ErrorResponseWithoutAnErrorEnvelope_ThrowsTheExceptionForItsStatus(
        string body
    )
    {
        using AnthropicClient client = new()
        {
            ApiKey = "my-anthropic-api-key",
            HttpClient = new(new FakeTransport().EnqueueJson(403, body)),
            MaxRetries = 0,
        };

        var exception = await Assert.ThrowsAsync<AnthropicForbiddenException>(() =>
            client.Messages.Create(MessageParams, TestContext.Current.CancellationToken)
        );

        Assert.Equal(HttpStatusCode.Forbidden, exception.StatusCode);
        Assert.Equal(body, exception.ResponseBody);
        Assert.Null(exception.ErrorType);
    }

    [Fact]
    public async Task ErrorEventWithoutAnErrorEnvelope_ThrowsSseException()
    {
        var data = """{"error":"text"}""";
        using AnthropicClient client = new()
        {
            ApiKey = "my-anthropic-api-key",
            HttpClient = new(new FakeTransport().EnqueueSse($"event: error\ndata: {data}\n\n")),
        };

        var exception = await Assert.ThrowsAsync<AnthropicSseException>(async () =>
        {
            await foreach (
                var _ in client.Messages.CreateStreaming(
                    MessageParams,
                    TestContext.Current.CancellationToken
                )
            ) { }
        });

        Assert.Contains(data, exception.Message);
        Assert.Null(exception.ErrorType);
    }
}
