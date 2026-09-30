using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Bedrock;

/// <summary>
/// Verifies that the classic Bedrock SigV4 signer canonicalizes headers the same way the
/// <c>Anthropic.Aws</c> and Bedrock Mantle signers already do, so the bytes that are signed
/// are the bytes <c>HttpClient</c> puts on the wire.
/// </summary>
public class AnthropicBedrockPrivateKeyCredentialsTests
{
    const string SigV4AccessKey = "AKIAIOSFODNN7EXAMPLE";
    const string SigV4SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
    const string MessageJson = """
        {"id":"msg_x","type":"message","role":"assistant","model":"anthropic.claude-3","content":[{"type":"text","text":"hi"}],"stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":1,"output_tokens":1}}
        """;

    /// <summary>
    /// Records the header values and body as they reach the transport, after the credentials
    /// provider has signed the request. The request is disposed once sent, so both are copied out.
    /// </summary>
    sealed class WireRecordingHandler(HttpMessageHandler inner) : DelegatingHandler(inner)
    {
        public string[]? RecordedValues { get; private set; }

        public string? RecordedBody { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            RecordedValues = request.Headers.TryGetValues("anthropic-beta", out var values)
                ? [.. values]
                : null;
            RecordedBody =
                request.Content == null
                    ? null
                    : await request
                        .Content.ReadAsStringAsync(cancellationToken)
                        .ConfigureAwait(false);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }

    static AnthropicBedrockClient CreateSigV4ClientAgainst(HttpMessageHandler gateway) =>
        new(
            new AnthropicBedrockPrivateKeyCredentials
            {
                Region = "us-east-1",
                ApiAccessKey = SigV4AccessKey,
                ApiSecret = SigV4SecretKey,
            }
        )
        {
            HttpClient = new HttpClient(gateway),
            Handlers = new List<DelegatingHandler>(),
        };

    /// <summary>
    /// A caller supplying several betas produces a repeated <c>anthropic-beta</c> header. Left
    /// repeated, <c>HttpClient</c> serializes it as <c>a, b</c> on the wire, which is not the value
    /// that was signed, so the gateway rejects the request. The provider therefore collapses it to
    /// a single comma-joined value before signing, and both the signature and the wire bytes agree.
    /// </summary>
    [Fact]
    public async Task SigV4Mode_RepeatedAnthropicBetaHeader_SignatureVerifies()
    {
        var gateway = new SigV4VerifyingHandler(SigV4SecretKey, MessageJson);
        var recorder = new WireRecordingHandler(gateway);
        var client = CreateSigV4ClientAgainst(recorder);

        var message = await client.Messages.Create(
            new MessageCreateParams(
                rawHeaderData: new Dictionary<string, JsonElement>
                {
                    ["anthropic-beta"] = JsonSerializer.SerializeToElement(
                        new List<string> { "beta-one", "beta-two" }
                    ),
                },
                rawQueryData: new Dictionary<string, JsonElement>(),
                rawBodyData: new Dictionary<string, JsonElement>()
            )
            {
                MaxTokens = 16,
                Messages = [new() { Content = "hello", Role = Role.User }],
                Model = "anthropic.claude-3",
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal("msg_x", message.ID);

        // The value that reaches the transport is the single comma-joined value that was signed,
        // not the two separate values the caller supplied.
        Assert.NotNull(recorder.RecordedValues);
        Assert.Equal(["beta-one,beta-two"], recorder.RecordedValues);

        // Collapsing happens while signing, after BedrockAdaptationHandler has already copied the
        // betas into the body, so the body still carries both values separately.
        Assert.NotNull(recorder.RecordedBody);
        using var body = JsonDocument.Parse(recorder.RecordedBody!);
        var betas = body.RootElement.GetProperty("anthropic_beta");
        Assert.Equal(2, betas.GetArrayLength());
        Assert.Equal("beta-one", betas[0].GetString());
        Assert.Equal("beta-two", betas[1].GetString());
    }

    /// <summary>
    /// SigV4 canonicalizes a header value by trimming it and collapsing runs of whitespace to a
    /// single space. A single-valued header carrying an internal whitespace run must therefore be
    /// collapsed before signing, as <c>Anthropic.Aws</c> and the Bedrock Mantle signer both do.
    /// </summary>
    [Fact]
    public async Task SigV4Mode_HeaderValueWithInternalWhitespaceRun_SignatureVerifies()
    {
        var gateway = new SigV4VerifyingHandler(SigV4SecretKey, MessageJson);
        var client = CreateSigV4ClientAgainst(gateway);

        var message = await client.Messages.Create(
            new MessageCreateParams(
                rawHeaderData: new Dictionary<string, JsonElement>
                {
                    ["x-amz-meta-note"] = JsonSerializer.SerializeToElement("alpha  beta"),
                },
                rawQueryData: new Dictionary<string, JsonElement>(),
                rawBodyData: new Dictionary<string, JsonElement>()
            )
            {
                MaxTokens = 16,
                Messages = [new() { Content = "hello", Role = Role.User }],
                Model = "anthropic.claude-3",
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal("msg_x", message.ID);
    }
}
