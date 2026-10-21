using System;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Models.Messages;
using Beta = Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Core.Telemetry;

/// <summary>
/// What the tests of the spans share: the parameters of a call, and how a JSON attribute is
/// compared.
/// </summary>
public abstract class TracingTestBase
{
    protected static MessageCreateParams MessageParams(string text = "Hello") =>
        new()
        {
            MaxTokens = 64,
            Messages = [new UserMessageParam { Content = text }],
            Model = "claude-test",
            System = "Be brief.",
        };

    protected static Beta.MessageCreateParams BetaParams() =>
        new()
        {
            MaxTokens = 64,
            Messages = [new Beta.BetaUserMessageParam { Content = "Weather?" }],
            Model = "claude-test",
        };

    protected static void AssertJson(string expected, object? actual)
    {
        var text = Assert.IsType<string>(actual);
        Assert.Equal(Normalize(expected), Normalize(text));

        static string Normalize(string json) =>
            JsonSerializer.Serialize(JsonDocument.Parse(json).RootElement);
    }

    /// <summary>
    /// A Messages request that every platform client can adapt.
    /// </summary>
    protected sealed record class PingParams : ParamsBase
    {
        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        ) { }

        internal override HttpContent? BodyContent() =>
            new StringContent("""{"model":"claude-test","max_tokens":1,"messages":[]}""");
    }
}
