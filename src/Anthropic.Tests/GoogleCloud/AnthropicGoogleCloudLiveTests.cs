using System;
using System.Linq;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.GoogleCloud;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.GoogleCloud;

/// <summary>
/// Live integration tests for <see cref="AnthropicGoogleCloudClient"/>. Skipped unless
/// <c>ANTHROPIC_LIVE=1</c>.
///
/// <para>
/// Authentication uses Application Default Credentials (cloud-platform scope), e.g. after
/// <c>gcloud auth application-default login</c>. Required env vars:
/// <c>ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID</c>; optional: <c>ANTHROPIC_GOOGLE_CLOUD_PROJECT</c>
/// (else inferred from ADC), <c>ANTHROPIC_GOOGLE_CLOUD_LOCATION</c> (default
/// <c>us-central1</c>), <c>ANTHROPIC_LIVE_MODEL</c>.
/// </para>
/// </summary>
public class AnthropicGoogleCloudLiveTests
{
    private static bool Live => Environment.GetEnvironmentVariable("ANTHROPIC_LIVE") == "1";

    private static string Model =>
        Environment.GetEnvironmentVariable("ANTHROPIC_LIVE_MODEL") ?? "claude-haiku-4-5";

    private static AnthropicGoogleCloudClient NewLiveClient()
    {
        var client = new AnthropicGoogleCloudClient(
            new()
            {
                Location =
                    Environment.GetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_LOCATION")
                    ?? "us-central1",
            }
        );
        return client;
    }

    [Fact]
    public async Task Live_Messages()
    {
        Assert.SkipUnless(Live, "set ANTHROPIC_LIVE=1 to run live integration tests");

        var client = NewLiveClient();
        var msg = await client.Messages.Create(
            new()
            {
                Model = Model,
                MaxTokens = 64,
                Messages = [new() { Role = "user", Content = "Say hello in exactly three words." }],
            },
            TestContext.Current.CancellationToken
        );
        Assert.NotEmpty(msg.Content);
    }

    [Fact]
    public async Task Live_Streaming()
    {
        Assert.SkipUnless(Live, "set ANTHROPIC_LIVE=1 to run live integration tests");

        var client = NewLiveClient();
        var sawStart = false;
        var sawStop = false;
        await foreach (
            var ev in client.Messages.CreateStreaming(
                new()
                {
                    Model = Model,
                    MaxTokens = 64,
                    Messages = [new() { Role = "user", Content = "Count to three." }],
                },
                TestContext.Current.CancellationToken
            )
        )
        {
            if (ev.TryPickStart(out _))
            {
                sawStart = true;
            }
            if (ev.TryPickStop(out _))
            {
                sawStop = true;
            }
        }
        Assert.True(sawStart && sawStop, $"incomplete sequence: start={sawStart} stop={sawStop}");
    }

    [Fact]
    public async Task Live_TypedError()
    {
        Assert.SkipUnless(Live, "set ANTHROPIC_LIVE=1 to run live integration tests");

        var client = NewLiveClient();
        var ex = await Assert.ThrowsAnyAsync<Anthropic4xxException>(async () =>
            await client.Messages.Create(
                new()
                {
                    Model = "no-such-model",
                    MaxTokens = 1,
                    Messages = [new() { Role = "user", Content = "hi" }],
                },
                TestContext.Current.CancellationToken
            )
        );
        Assert.InRange((int)ex.StatusCode, 400, 499);
    }
}
