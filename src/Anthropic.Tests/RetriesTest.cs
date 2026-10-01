using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Exceptions;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests;

public class RetriesTest : TestBase
{
    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    record class ParamsWithDefaultHeaders : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            ParamsBase.AddDefaultHeaders(request, options);
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    record class ParamsWithOverwrittenRetryHeader : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions _options
        )
        {
            request.Headers.TryAddWithoutValidation("x-stainless-retry-count", "42");
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    record class UploadParams : ParamsBase
    {
        public UploadParams(BinaryContent file)
        {
            File = file;
        }

        public BinaryContent File { get; }

        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }

        internal override HttpContent? BodyContent() =>
            MultipartJsonSerializer.Serialize(new Dictionary<string, object> { { "file", File } });

        internal override bool IsBodyRepeatable() => File.IsRepeatable;
    }

    [Fact]
    public async Task ImmediateSuccess_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryAfterHeader_Works()
    {
        var ResponseWithRetryDate = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        ResponseWithRetryDate.Headers.Add("Retry-After", "Wed, 21 Oct 2015 07:28:00 GMT");

        var ResponseWithRetryDelay = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        // decimals are technically out of spec, but we want to ensure we can parse them regardless
        ResponseWithRetryDelay.Headers.TryAddWithoutValidation("Retry-After", "1.234");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(ResponseWithRetryDate)
            .ReturnsAsync(ResponseWithRetryDelay)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "0"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "1"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "2"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task OverwrittenRetryCountHeader_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Content = new StringContent("foo"),
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<ParamsWithOverwrittenRetryHeader>
            {
                Method = HttpMethod.Get,
                Params = new(),
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "42"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RateLimitStatus_IsRetried()
    {
        var failResponse = new HttpResponseMessage()
        {
            StatusCode = (HttpStatusCode)429,
            Content = new StringContent("foo"),
        };
        failResponse.Headers.TryAddWithoutValidation("Retry-After-Ms", "10");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(failResponse)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryAfterMsHeader_Works()
    {
        var failResponse = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        failResponse.Headers.TryAddWithoutValidation("Retry-After-Ms", "10");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(failResponse)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Theory]
    [InlineData("Retry-After-Ms", "1e20")]
    [InlineData("Retry-After-Ms", "-1e20")]
    [InlineData("Retry-After-Ms", "NaN")]
    [InlineData("Retry-After", "1e20")]
    public async Task UnrepresentableRetryAfter_FallsBackToDefaultBackoff(
        string header,
        string value
    )
    {
        var failResponse = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        // Parses as a float, but is not a duration a TimeSpan can represent.
        failResponse.Headers.TryAddWithoutValidation(header, value);

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(failResponse)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Theory]
    [InlineData("Retry-After-Ms", "1e13")]
    [InlineData("Retry-After", "1e10")]
    public async Task OversizedRetryAfter_WaitsUntilCancelled(string header, string value)
    {
        var failResponse = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        // A duration a TimeSpan can represent, but longer than `Task.Delay` accepts.
        failResponse.Headers.TryAddWithoutValidation(header, value);

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(failResponse);

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        cts.CancelAfter(TimeSpan.FromMilliseconds(50));

        // The wait is cut short by the caller's cancellation rather than rejected by `Task.Delay`.
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            client.WithRawResponse.Execute(
                new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
                cts.Token
            )
        );

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryableException_Works()
    {
        var callCount = 0;

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                (_, ct) =>
                {
                    callCount++;
                    if (callCount == 1)
                        throw new HttpRequestException("Simulated retryable failure");

                    return Task.FromResult(
                        new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent("foo"),
                        }
                    );
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "0"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "1"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task Timeout_IsRetried()
    {
        var callCount = 0;

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                async (_, ct) =>
                {
                    callCount++;
                    if (callCount <= 1)
                    {
                        // Simulate a server that never answers this attempt.
                        await Task.Delay(Timeout.InfiniteTimeSpan, ct);
                    }

                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("foo"),
                    };
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new()
        {
            HttpClient = httpClient,
            MaxRetries = 2,
            Timeout = TimeSpan.FromMilliseconds(10),
        };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        Assert.Equal(2, callCount);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count")) == "1"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task Timeout_ThrowsAfterRetriesExhausted()
    {
        var callCount = 0;

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                async (_, ct) =>
                {
                    callCount++;
                    await Task.Delay(Timeout.InfiniteTimeSpan, ct);

                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("foo"),
                    };
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new()
        {
            HttpClient = httpClient,
            MaxRetries = 2,
            Timeout = TimeSpan.FromMilliseconds(10),
        };

        var e = await Assert.ThrowsAsync<TaskCanceledException>(() =>
            client.WithRawResponse.Execute(
                new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
                TestContext.Current.CancellationToken
            )
        );

        Assert.IsType<TimeoutException>(e.InnerException);
        // The initial attempt plus `MaxRetries` retries.
        Assert.Equal(3, callCount);
    }

    [Fact]
    public async Task CallerCancellation_IsNotRetried()
    {
        var callCount = 0;

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                async (_, ct) =>
                {
                    callCount++;
                    await Task.Delay(Timeout.InfiniteTimeSpan, ct);

                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("foo"),
                    };
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            TestContext.Current.CancellationToken
        );
        cts.CancelAfter(TimeSpan.FromMilliseconds(10));

        var e = await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            client.WithRawResponse.Execute(
                new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
                cts.Token
            )
        );

        Assert.IsNotType<TimeoutException>(e.InnerException);
        Assert.Equal(1, callCount);
    }

    [Fact]
    public async Task CultureInvariant_HeadersAndRetryAfter()
    {
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = TestCulture();
        try
        {
            var callCount = 0;

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Returns<HttpRequestMessage, CancellationToken>(
                    (_, ct) =>
                    {
                        var response = new HttpResponseMessage()
                        {
                            StatusCode =
                                callCount++ == 0
                                    ? HttpStatusCode.ServiceUnavailable
                                    : HttpStatusCode.OK,
                            Content = new StringContent("foo"),
                        };
                        // 10ms; a culture-sensitive parse would read this as 10 seconds under the test culture.
                        response.Headers.TryAddWithoutValidation("Retry-After", "0.010");
                        return Task.FromResult(response);
                    }
                );

            var httpClient = new HttpClient(handlerMock.Object);

            AnthropicClient client = new()
            {
                HttpClient = httpClient,
                MaxRetries = 1,
                Timeout = TimeSpan.FromMilliseconds(1500),
            };

            var stopwatch = Stopwatch.StartNew();
            var resp = await client.WithRawResponse.Execute(
                new HttpRequest<ParamsWithDefaultHeaders>
                {
                    Method = HttpMethod.Get,
                    Params = new(),
                },
                TestContext.Current.CancellationToken
            );
            stopwatch.Stop();

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            Assert.Equal(2, callCount);
            Assert.True(
                stopwatch.Elapsed < TimeSpan.FromSeconds(5),
                "Retry-After: 0.010 should be honored as 10ms regardless of the current culture"
            );
            handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(
                        (req) =>
                            Enumerable.Single(req.Headers.GetValues("X-Stainless-Timeout")) == "1.5"
                            && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                                == "1"
                    ),
                    ItExpr.IsAny<CancellationToken>()
                );
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    [Fact]
    public async Task CultureInvariant_RetryAfterDate()
    {
        // A culture whose default calendar isn't Gregorian: a culture-sensitive parse of an HTTP-date either
        // fails or lands centuries away from the intended instant.
        CultureInfo? culture = null;
        try
        {
            culture = new CultureInfo("th-TH");
        }
        catch (CultureNotFoundException)
        {
            // ignored
        }
        Assert.SkipWhen(
            culture is null,
            "th-TH culture data isn't available (globalization-invariant mode)"
        );

        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        try
        {
            var callCount = 0;

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Returns<HttpRequestMessage, CancellationToken>(
                    (_, ct) =>
                    {
                        var response = new HttpResponseMessage()
                        {
                            StatusCode =
                                callCount++ == 0
                                    ? HttpStatusCode.ServiceUnavailable
                                    : HttpStatusCode.OK,
                            Content = new StringContent("foo"),
                        };
                        // An HTTP-date 2-3 seconds from now. If it were parsed with the current (Thai Buddhist calendar)
                        // culture, parsing would fail and the SDK would fall back to the ~0.5s default backoff instead.
                        response.Headers.TryAddWithoutValidation(
                            "Retry-After",
                            DateTimeOffset
                                .UtcNow.AddSeconds(3)
                                .ToString("r", CultureInfo.InvariantCulture)
                        );
                        return Task.FromResult(response);
                    }
                );

            var httpClient = new HttpClient(handlerMock.Object);

            AnthropicClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

            var stopwatch = Stopwatch.StartNew();
            var resp = await client.WithRawResponse.Execute(
                new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
                TestContext.Current.CancellationToken
            );
            stopwatch.Stop();

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            Assert.Equal(2, callCount);
            Assert.True(
                stopwatch.Elapsed >= TimeSpan.FromMilliseconds(1500),
                "an HTTP-date Retry-After should be honored regardless of the current culture"
            );
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }

    static CultureInfo TestCulture()
    {
        var culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
        culture.NumberFormat.NumberDecimalSeparator = ",";
        culture.NumberFormat.NumberGroupSeparator = ".";
        return culture;
    }

    static HttpClient UploadHttpClient(List<string> bodies)
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                async (req, ct) =>
                {
                    bodies.Add(await req.Content!.ReadAsStringAsync(
#if NET
                            ct
#endif
                        ));

                    var response = new HttpResponseMessage()
                    {
                        StatusCode =
                            bodies.Count == 1
                                ? HttpStatusCode.ServiceUnavailable
                                : HttpStatusCode.OK,
                        Content = new StringContent("foo"),
                    };
                    // Retry straight away rather than after the default backoff.
                    response.Headers.TryAddWithoutValidation("Retry-After-Ms", "1");
                    return response;
                }
            );

        return new HttpClient(handlerMock.Object);
    }

    [Fact]
    public async Task UploadFromByteArray_IsRetried()
    {
        var bodies = new List<string>();
        AnthropicClient client = new() { HttpClient = UploadHttpClient(bodies), MaxRetries = 2 };

        // A file part created from a byte array can be sent again, so the 503 is retried and the second attempt
        // carries the same bytes.
        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<UploadParams>
            {
                Method = HttpMethod.Post,
                Params = new(Encoding.UTF8.GetBytes("file contents")),
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        Assert.Equal(2, bodies.Count);
        Assert.Contains("file contents", bodies[0]);
        Assert.Contains("file contents", bodies[1]);
    }

    [Fact]
    public async Task UploadFromStream_IsSentOnce()
    {
        var bodies = new List<string>();
        AnthropicClient client = new() { HttpClient = UploadHttpClient(bodies), MaxRetries = 2 };

        // A file part that reads from a caller's stream is consumed by the first attempt, so the request is sent once
        // and the 503 surfaces instead of being retried.
        var stream = new MemoryStream(Encoding.UTF8.GetBytes("file contents"));
        await Assert.ThrowsAnyAsync<AnthropicApiException>(() =>
            client.WithRawResponse.Execute(
                new HttpRequest<UploadParams>
                {
                    Method = HttpMethod.Post,
                    Params = new(new BinaryContent { Stream = stream }),
                },
                TestContext.Current.CancellationToken
            )
        );

        var body = Assert.Single(bodies);
        Assert.Contains("file contents", body);
    }
}
