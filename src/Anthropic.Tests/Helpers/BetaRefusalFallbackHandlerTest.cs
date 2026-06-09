using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Helpers;

[Collection("console stderr")]
public class BetaRefusalFallbackHandlerTest
{
    [Fact]
    public async Task RetriesRefusalWithFallbackParamsAndCreditToken()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Message("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        // A fresh state, so falling back doesn't write the missing-state warning to the stderr
        // of tests asserting on it.
        using var _ = BetaFallbackState.Create().Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        var message = await ReadMessage(response);
        Assert.Equal("fallback-model", message.Model.Raw());
        Assert.Equal(BetaStopReason.EndTurn, message.StopReason?.Value());
        Assert.Equal(["primary-model", "fallback-model"], transport.Models);
        Assert.Equal(
            "credit-token",
            transport.JsonBodies[1]["fallback_credit_token"]?.GetValue<string>()
        );
    }

    [Fact]
    public async Task PrependsSeamBlockOnServedFallbackRetry()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Message("fallback-model", "answer"));
        using var invoker = Intercepted(transport, "fallback-model");

        using var _ = BetaFallbackState.Create().Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        var message = await ReadMessage(response);
        Assert.Equal(2, message.Content.Count);
        Assert.True(message.Content[0].TryPickFallback(out var seam));
        Assert.Equal("primary-model", seam.From.Model.Raw());
        Assert.Equal("fallback-model", seam.To.Model.Raw());
        Assert.True(message.Content[1].TryPickText(out var text));
        Assert.Equal("answer", text.Text);
    }

    [Fact]
    public async Task PrependsSeamBlockPerBoundaryOnMultiHopChain()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Refusal("mid-model", "fresh-token"))
            .EnqueueJson(200, Message("last-model", "answer"));
        using var invoker = Intercepted(transport, "mid-model", "last-model");

        using var _ = BetaFallbackState.Create().Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        // One seam per model boundary, oldest first, then the serving hop's content.
        var message = await ReadMessage(response);
        Assert.Equal(3, message.Content.Count);
        Assert.True(message.Content[0].TryPickFallback(out var first));
        Assert.Equal("primary-model", first.From.Model.Raw());
        Assert.Equal("mid-model", first.To.Model.Raw());
        Assert.True(message.Content[1].TryPickFallback(out var second));
        Assert.Equal("mid-model", second.From.Model.Raw());
        Assert.Equal("last-model", second.To.Model.Raw());
        Assert.True(message.Content[2].TryPickText(out var text));
        Assert.Equal("answer", text.Text);
    }

    [Fact]
    public async Task SurfacesTerminalRefusalVerbatimWithNoSeam()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Refusal("fallback-model", "fresh-token"));
        using var invoker = Intercepted(transport, "fallback-model");

        using var state = BetaFallbackState.Create().Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        var message = await ReadMessage(response);
        Assert.Equal(BetaStopReason.Refusal, message.StopReason?.Value());
        Assert.DoesNotContain(message.Content, block => block.TryPickFallback(out _));
    }

    [Fact]
    public async Task PinsToAcceptedFallbackViaFallbackState()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Message("fallback-model"))
            .EnqueueJson(200, Message("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var fallbackState = BetaFallbackState.Create();
        using var _ = fallbackState.Use();
        await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        Assert.Equal(0, fallbackState.Index);

        // The follow-up goes straight to the pinned fallback in a single request.
        await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        Assert.Equal(["primary-model", "fallback-model", "fallback-model"], transport.Models);
    }

    [Fact]
    public async Task ThrowsWhenStateIndexIsOutOfBounds()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var fallbackState = BetaFallbackState.Create();
        fallbackState.Index = 1;
        using var _ = fallbackState.Use();

        var exception = await Assert.ThrowsAsync<AnthropicException>(() =>
            invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken)
        );
        Assert.Contains(
            "BetaFallbackState.Index 1 is out of bounds for a chain of 1 fallback(s)",
            exception.Message
        );
        Assert.Equal(0, transport.RequestCount);
    }

    [Fact]
    public async Task WarnsOnceWhenFallingBackWithoutState()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Message("fallback-model"))
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Message("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
            await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        });

        Assert.Equal(4, transport.RequestCount);
        Assert.Single(stderr.Split('\n'), line => line.Contains("BetaFallbackState"));
    }

    [Fact]
    public async Task ASeparateStateIsUnaffectedByAnotherState()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Message("fallback-model"))
            .EnqueueJson(200, Message("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        using (BetaFallbackState.Create().Use())
        {
            await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        }
        using (BetaFallbackState.Create().Use())
        {
            await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        }

        Assert.Equal(["primary-model", "fallback-model", "primary-model"], transport.Models);
    }

    [Fact]
    public async Task LeavesAcceptedRequestsAndTheResponseUntouched()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var fallbackState = BetaFallbackState.Create();
        using var _ = fallbackState.Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal("primary-model", (await ReadMessage(response)).Model.Raw());
        Assert.Equal(1, transport.RequestCount);
        Assert.False(transport.JsonBodies[0].ContainsKey("fallback_credit_token"));
        Assert.Equal(-1, fallbackState.Index);
    }

    [Fact]
    public async Task WalksEachHopThroughTheChainUntilAModelAccepts()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Refusal("mid-model"))
            .EnqueueJson(200, Message("last-model"));
        using var invoker = Intercepted(transport, "mid-model", "last-model");

        var fallbackState = BetaFallbackState.Create();
        using var _ = fallbackState.Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal("last-model", (await ReadMessage(response)).Model.Raw());
        Assert.Equal(1, fallbackState.Index);
        Assert.Equal(["primary-model", "mid-model", "last-model"], transport.Models);
    }

    [Fact]
    public async Task ReturnsTheFinalRefusalOnceTheChainIsExhausted()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Refusal("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        HttpResponseMessage? response = null;
        // Capture the missing-state warning to avoid polluting test output.
        await FallbackTestSupport.CaptureStderr(async () =>
        {
            response = await invoker.SendAsync(
                MessagesRequest(),
                TestContext.Current.CancellationToken
            );
        });

        var message = await ReadMessage(response!);
        Assert.Equal("fallback-model", message.Model.Raw());
        Assert.Equal(BetaStopReason.Refusal, message.StopReason?.Value());
        Assert.Equal(2, transport.RequestCount);
    }

    [Fact]
    public async Task ReturnsErrorResponsesAsIs()
    {
        // Even a refusal-shaped body must not trigger a fallback when the status is an error.
        var transport = new FakeTransport().EnqueueJson(429, Refusal("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal((HttpStatusCode)429, response.StatusCode);
        Assert.Equal(1, transport.RequestCount);
    }

    [Fact]
    public async Task AppendsTheFallbackCreditBetaToEveryHandledRequest()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Message("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        using var _ = BetaFallbackState.Create().Use();
        await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);

        Assert.Equal(2, transport.RequestCount);
        for (var index = 0; index < transport.RequestCount; index++)
        {
            Assert.Equal(["fallback-credit-2026-06-01"], transport.BetaHeaderValues(index));
        }
    }

    [Fact]
    public async Task DoesNotDuplicateAnAlreadyPresentBeta()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var request = MessagesRequest();
        request.Headers.TryAddWithoutValidation(
            "anthropic-beta",
            "some-other-beta,fallback-credit-2026-06-01"
        );
        await invoker.SendAsync(request, TestContext.Current.CancellationToken);

        Assert.Equal(["some-other-beta,fallback-credit-2026-06-01"], transport.BetaHeaderValues(0));
    }

    [Fact]
    public async Task SendsCustomBetasInsteadOfTheDefault()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks = [new BetaFallbackParam("fallback-model")],
            Betas = ["custom-beta"],
            InnerHandler = transport,
        };
        using HttpMessageInvoker invoker = new(handler);

        await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);

        Assert.Equal(["custom-beta"], transport.BetaHeaderValues(0));
    }

    [Fact]
    public async Task SendsNoBetasWhenConfiguredWithAnEmptyList()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks = [new BetaFallbackParam("fallback-model")],
            Betas = [],
            InnerHandler = transport,
        };
        using HttpMessageInvoker invoker = new(handler);

        await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);

        Assert.Empty(transport.BetaHeaderValues(0));
    }

    [Fact]
    public async Task AnEmptyChainDisablesTheHandler()
    {
        var transport = new FakeTransport().EnqueueJson(200, Refusal("primary-model"));
        var handler = new BetaRefusalFallbackHandler { InnerHandler = transport };
        using HttpMessageInvoker invoker = new(handler);

        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal(BetaStopReason.Refusal, (await ReadMessage(response)).StopReason?.Value());
        Assert.Equal(1, transport.RequestCount);
        Assert.Empty(transport.BetaHeaderValues(0));
    }

    [Fact]
    public async Task AppliesFallbackAdditionalPropertiesToRetriedRequests()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Message("fallback-model"));
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks =
            [
                BetaFallbackParam.FromRawUnchecked(
                    new System.Collections.Generic.Dictionary<string, JsonElement>
                    {
                        ["model"] = JsonSerializer.SerializeToElement("fallback-model"),
                        ["custom_field"] = JsonSerializer.SerializeToElement("custom-value"),
                    }
                ),
            ],
            InnerHandler = transport,
        };
        using HttpMessageInvoker invoker = new(handler);

        using var _ = BetaFallbackState.Create().Use();
        await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);

        Assert.Equal("custom-value", transport.JsonBodies[1]["custom_field"]?.GetValue<string>());
    }

    [Fact]
    public async Task ThrowsOnRequestsWithServerSideFallbacks()
    {
        var transport = new FakeTransport().EnqueueJson(200, Refusal("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var body = MessagesBody();
        body["fallbacks"] = new JsonArray(new JsonObject { ["model"] = "server-side-model" });
        var exception = await Assert.ThrowsAsync<AnthropicException>(() =>
            invoker.SendAsync(MessagesRequest(body), TestContext.Current.CancellationToken)
        );

        Assert.Equal(
            "Sending the `fallbacks:` request param is not supported when using the "
                + "`BetaRefusalFallbackHandler`. You should either remove the middleware and "
                + "send `fallbacks:` with "
                + "the `server-side-fallback-2026-06-01` beta header to let the API handle "
                + "refusal fallbacks, or omit the "
                + "`fallbacks:` param if you'd like `BetaRefusalFallbackHandler` to handle "
                + "fallbacks on the client side.",
            exception.Message
        );
        Assert.Equal(0, transport.RequestCount);
    }

    [Fact]
    public async Task SkipsNonMessagesRequests()
    {
        var transport = new FakeTransport().EnqueueJson(200, Refusal("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        HttpRequestMessage request = new(
            HttpMethod.Post,
            "https://api.example.com/v1/complete?beta=true"
        )
        {
            Content = JsonContent(MessagesBody()),
        };
        await invoker.SendAsync(request, TestContext.Current.CancellationToken);

        Assert.Equal(1, transport.RequestCount);
    }

    [Fact]
    public async Task SkipsNonBetaMessagesRequests()
    {
        var transport = new FakeTransport().EnqueueJson(200, Refusal("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        // The same request the beta service would make, minus its `beta=true` tag — what the
        // non-beta `client.Messages` service sends.
        HttpRequestMessage request = new(HttpMethod.Post, "https://api.example.com/v1/messages")
        {
            Content = JsonContent(MessagesBody()),
        };
        await invoker.SendAsync(request, TestContext.Current.CancellationToken);

        Assert.Equal(1, transport.RequestCount);
        Assert.Empty(transport.BetaHeaderValues(0));
    }

    [Fact]
    public async Task SkipsAFailedHopAndCarriesTheTokenToTheNextEntry()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(529, OverloadedError)
            .EnqueueJson(200, Message("second-model"));
        using var invoker = Intercepted(transport, "fallback-model", "second-model");

        var fallbackState = BetaFallbackState.Create();
        using var _ = fallbackState.Use();
        HttpResponseMessage? response = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            response = await invoker.SendAsync(
                MessagesRequest(),
                TestContext.Current.CancellationToken
            );
        });

        Assert.Contains("fallback request to fallback-model failed: HTTP 529", stderr);
        Assert.Equal("second-model", (await ReadMessage(response!)).Model.Raw());
        Assert.Equal(["primary-model", "fallback-model", "second-model"], transport.Models);
        // The failed hop never redeemed the token, so it carries to the next entry.
        Assert.Equal(
            "credit-token",
            transport.JsonBodies[1]["fallback_credit_token"]?.GetValue<string>()
        );
        Assert.Equal(
            "credit-token",
            transport.JsonBodies[2]["fallback_credit_token"]?.GetValue<string>()
        );
        Assert.Equal(1, fallbackState.Index);
    }

    [Fact]
    public async Task ReturnsTheLastHopErrorWhenNoEntriesRemain()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(529, OverloadedError);
        using var invoker = Intercepted(transport, "fallback-model");

        var fallbackState = BetaFallbackState.Create();
        using var _ = fallbackState.Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal((HttpStatusCode)529, response.StatusCode);
        Assert.Equal(2, transport.RequestCount);
        // A hop that failed outright never served anything, so it isn't pinned.
        Assert.Equal(-1, fallbackState.Index);
    }

    [Fact]
    public async Task DoesNotPinARefusedLastFallback()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Refusal("fallback-model", "fresh-token"));
        using var invoker = Intercepted(transport, "fallback-model");

        var fallbackState = BetaFallbackState.Create();
        using var _ = fallbackState.Use();
        var response = await invoker.SendAsync(
            MessagesRequest(),
            TestContext.Current.CancellationToken
        );

        Assert.Equal(BetaStopReason.Refusal, (await ReadMessage(response)).StopReason?.Value());
        // The last entry refused; follow-up requests should start back at the original params,
        // not at a model that just refused.
        Assert.Equal(-1, fallbackState.Index);
    }

    [Fact]
    public async Task RetriesWithoutTheTokenWhenThePinnedEntryHadOverrides()
    {
        // The token was minted against the pinned entry's overlaid body (max_tokens: 99); the
        // hop body reverts that field, so the server can reject the redemption even though the
        // hop's own entry overrides nothing.
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("override-model", "credit-token"))
            .EnqueueJson(400, InvalidRequestError)
            .EnqueueJson(200, Message("plain-model"));
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks =
            [
                BetaFallbackParam.FromRawUnchecked(
                    new System.Collections.Generic.Dictionary<string, JsonElement>
                    {
                        ["model"] = JsonSerializer.SerializeToElement("override-model"),
                        ["max_tokens"] = JsonSerializer.SerializeToElement(99),
                    }
                ),
                new BetaFallbackParam("plain-model"),
            ],
            InnerHandler = transport,
        };
        using HttpMessageInvoker invoker = new(handler);

        var fallbackState = BetaFallbackState.Create();
        fallbackState.Index = 0;
        using var _ = fallbackState.Use();
        HttpResponseMessage? response = null;
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            response = await invoker.SendAsync(
                MessagesRequest(),
                TestContext.Current.CancellationToken
            );
        });

        Assert.Contains("retrying without the token", stderr);
        Assert.Equal(3, transport.RequestCount);
        Assert.Equal(99, transport.JsonBodies[0]["max_tokens"]?.GetValue<int>());
        Assert.Equal(
            "credit-token",
            transport.JsonBodies[1]["fallback_credit_token"]?.GetValue<string>()
        );
        Assert.False(transport.JsonBodies[2].ContainsKey("fallback_credit_token"));
        Assert.Equal("plain-model", transport.JsonBodies[2]["model"]?.GetValue<string>());
        Assert.Equal("plain-model", (await ReadMessage(response!)).Model.Raw());
        Assert.Equal(1, fallbackState.Index);
    }

    [Fact]
    public async Task WarnsOnceWhenARefusalHasNoCreditToken()
    {
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model"))
            .EnqueueJson(200, Message("fallback-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        using var _ = BetaFallbackState.Create().Use();
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        });

        // The retry still happens — only the credit is missing — and the warning lists the
        // beta among the causes, since this request never proved it enabled.
        Assert.Equal(2, transport.RequestCount);
        Assert.Single(stderr.Split('\n'), line => line.Contains("no fallback_credit_token"));
        Assert.Contains("beta may not be enabled", stderr);
    }

    [Fact]
    public async Task TheMissingTokenWarningOmitsTheBetaCauseMidChain()
    {
        // The initial refusal carried a token, so the beta is provably enabled by the time the
        // hop's token-less refusal is warned about.
        var transport = new FakeTransport()
            .EnqueueJson(200, Refusal("primary-model", "credit-token"))
            .EnqueueJson(200, Refusal("mid-model"))
            .EnqueueJson(200, Message("last-model"));
        using var invoker = Intercepted(transport, "mid-model", "last-model");

        using var _ = BetaFallbackState.Create().Use();
        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            await invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken);
        });

        Assert.Contains("no fallback_credit_token", stderr);
        Assert.DoesNotContain("beta may not be enabled", stderr);
    }

    [Fact]
    public async Task DisposesTheResponseWhenReadingItsBodyThrows()
    {
        ThrowingStream stream = new();
        var transport = new FakeTransport().Enqueue(() =>
        {
            StreamContent content = new(stream);
            content.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK) { Content = content }
            );
        });
        using var invoker = Intercepted(transport, "fallback-model");

        using var _ = BetaFallbackState.Create().Use();
        var exception = await Record.ExceptionAsync(() =>
            invoker.SendAsync(MessagesRequest(), TestContext.Current.CancellationToken)
        );

        // The response never reaches the caller, so the handler must release it (and its
        // pooled connection) itself.
        Assert.NotNull(exception);
        Assert.True(stream.Disposed);
    }

    [Fact]
    public async Task TrimsReplayedFallbackTurnFromOutgoingHistory()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var body = MessagesBody();
        body["messages"] = new JsonArray(
            new JsonObject { ["role"] = "user", ["content"] = "hi" },
            new JsonObject
            {
                ["role"] = "assistant",
                ["content"] = new JsonArray(
                    FallbackTestSupport.Block(
                        new BetaThinkingBlockParam { Thinking = "hmm", Signature = "sig" }
                    ),
                    FallbackTestSupport.Block(
                        new BetaToolUseBlockParam
                        {
                            ID = "tool_1",
                            Name = "lookup",
                            Input = new System.Collections.Generic.Dictionary<
                                string,
                                JsonElement
                            >(),
                        }
                    ),
                    FallbackBlock(),
                    FallbackTestSupport.Block(new BetaTextBlockParam { Text = "answer" })
                ),
            },
            new JsonObject { ["role"] = "user", ["content"] = "continue" }
        );

        using var _ = BetaFallbackState.Create().Use();
        await invoker.SendAsync(MessagesRequest(body), TestContext.Current.CancellationToken);

        // The seam block and the refused attempt before it are gone; the post-seam text — what
        // the serving model produced — ships verbatim.
        var sent = (JsonArray)transport.JsonBodies[0]["messages"]!;
        Assert.Equal(3, sent.Count);
        var block = Assert.Single((JsonArray)sent[1]!["content"]!);
        Assert.Equal("text", block?["type"]?.GetValue<string>());
        Assert.Equal("answer", block?["text"]?.GetValue<string>());
    }

    [Fact]
    public async Task DropsAssistantTurnLeftEmptyByTrimming()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        var body = MessagesBody();
        body["messages"] = new JsonArray(
            new JsonObject { ["role"] = "user", ["content"] = "hi" },
            new JsonObject { ["role"] = "assistant", ["content"] = new JsonArray(FallbackBlock()) },
            new JsonObject { ["role"] = "user", ["content"] = "continue" }
        );

        using var _ = BetaFallbackState.Create().Use();
        await invoker.SendAsync(MessagesRequest(body), TestContext.Current.CancellationToken);

        var sent = (JsonArray)transport.JsonBodies[0]["messages"]!;
        Assert.Equal(2, sent.Count);
        Assert.All(sent, message => Assert.Equal("user", message?["role"]?.GetValue<string>()));
    }

    [Fact]
    public async Task SeamFreeHistoryPassesThroughByteIdentical()
    {
        var transport = new FakeTransport().EnqueueJson(200, Message("primary-model"));
        using var invoker = Intercepted(transport, "fallback-model");

        // Deliberately a hand-formatted string, not typed constructors: any reserialization —
        // even a key-preserving one — must show in the byte comparison.
        const string requestBody = """
            {"model": "primary-model",  "max_tokens": 1024, "messages": [{"role": "user", "content": "hi"}, {"role": "assistant", "content": [{"type": "thinking", "thinking": "hmm", "signature": "sig"}, {"type": "text", "text": "answer"}]}]}
            """;
        HttpRequestMessage request = new(
            HttpMethod.Post,
            "https://api.example.com/v1/messages?beta=true"
        )
        {
            Content = new StringContent(requestBody, Encoding.UTF8, "application/json"),
        };

        using var _ = BetaFallbackState.Create().Use();
        await invoker.SendAsync(request, TestContext.Current.CancellationToken);

        Assert.Equal(requestBody, transport.RawBodies[0]);
    }

    static JsonNode FallbackBlock() =>
        FallbackTestSupport.Block(
            new BetaFallbackBlockParam
            {
                From = new BetaFallbackInfoParam { Model = "primary-model" },
                To = new BetaFallbackInfoParam { Model = "fallback-model" },
            }
        );

    const string OverloadedError =
        """{"type":"error","error":{"type":"overloaded_error","message":"later"}}""";

    const string InvalidRequestError =
        """{"type":"error","error":{"type":"invalid_request_error","message":"bad request"}}""";

    static HttpMessageInvoker Intercepted(FakeTransport transport, params string[] fallbackModels)
    {
        var handler = new BetaRefusalFallbackHandler
        {
            Fallbacks = [.. fallbackModels.Select(model => new BetaFallbackParam(model))],
            InnerHandler = transport,
        };
        return new HttpMessageInvoker(handler);
    }

    static JsonObject MessagesBody() =>
        new()
        {
            ["model"] = "primary-model",
            ["max_tokens"] = 1024,
            ["messages"] = new JsonArray(new JsonObject { ["role"] = "user", ["content"] = "hi" }),
        };

    static HttpRequestMessage MessagesRequest(JsonObject? body = null) =>
        new(HttpMethod.Post, "https://api.example.com/v1/messages?beta=true")
        {
            Content = JsonContent(body ?? MessagesBody()),
        };

    static StringContent JsonContent(JsonObject body) =>
        new(body.ToJsonString(), Encoding.UTF8, "application/json");

    static async Task<BetaMessage> ReadMessage(HttpResponseMessage response) =>
        JsonSerializer.Deserialize<BetaMessage>(
            await response.Content.ReadAsStringAsync(),
            ModelBase.SerializerOptions
        )!;

    static string Message(string model) =>
        $$"""
            {
              "id": "msg_1",
              "type": "message",
              "role": "assistant",
              "model": "{{model}}",
              "content": [],
              "stop_reason": "end_turn",
              "stop_sequence": null,
              "usage": {"input_tokens": 1, "output_tokens": 1}
            }
            """;

    static string Message(string model, string text) =>
        $$"""
            {
              "id": "msg_1",
              "type": "message",
              "role": "assistant",
              "model": "{{model}}",
              "content": [{"type": "text", "text": "{{text}}"}],
              "stop_reason": "end_turn",
              "stop_sequence": null,
              "usage": {"input_tokens": 1, "output_tokens": 1}
            }
            """;

    static string Refusal(string model, string? fallbackCreditToken = null) =>
        $$"""
        {
          "id": "msg_1",
          "type": "message",
          "role": "assistant",
          "model": "{{model}}",
          "content": [],
          "stop_reason": "refusal",
          "stop_details": {
            "type": "refusal",
            "reason": "other",
            "explanation": null,
            "fallback_credit_token": {{(
            fallbackCreditToken == null ? "null" : $"\"{fallbackCreditToken}\""
        )}}
          },
          "stop_sequence": null,
          "usage": {"input_tokens": 1, "output_tokens": 1}
        }
        """;
}
