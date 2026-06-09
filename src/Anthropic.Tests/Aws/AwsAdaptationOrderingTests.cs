using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Aws;
using Anthropic.Core;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Aws;

/// <summary>
/// Verifies that user handlers wrap the AWS gateway adaptation: handlers observe the
/// logical request (including the workspace ID header) before SigV4 signing, and any
/// body mutation they perform is covered by the signature.
/// </summary>
public class AwsAdaptationOrderingTests
{
    private record class JsonBodyParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // Skip default headers so ambient ANTHROPIC_* env vars can't interfere.
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent("{\"model\":\"claude-sonnet-4-5\",\"max_tokens\":1024}");
    }

    private const string MutatedBody =
        "{\"model\":\"claude-sonnet-4-5\",\"max_tokens\":1024,\"metadata\":{\"user_id\":\"user_123\"}}";

    [Fact]
    public async Task UserHandlerMutation_IsCoveredBySigV4Signature()
    {
        HttpRequestMessage? wireRequest = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>(
                (req, _) =>
                {
                    // Clone what we assert on — the request is disposed after SendAsync.
                    var clone = new HttpRequestMessage(req.Method, req.RequestUri);
                    foreach (var header in req.Headers)
                    {
                        clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                    wireRequest = clone;
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                }
            );

        var observedWorkspaceId = false;
        var observedAuthorization = true;

        var client = new AnthropicAwsClient(
            new AwsClientOptions
            {
                AwsAccessKey = "AKIAEXAMPLE",
                AwsSecretAccessKey = "test-secret",
                AwsRegion = "us-east-1",
                WorkspaceId = "wrkspc_123",
                BaseUrl = "https://aws-external-anthropic.us-east-1.api.aws",
            }
        )
        {
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>
            {
                Handler.Create(
                    (request, next, cancellationToken) =>
                    {
                        // The workspace ID is logical metadata, visible to handlers.
                        observedWorkspaceId = request.Headers.Contains("anthropic-workspace-id");
                        // Signing hasn't happened yet, so mutating the body is safe.
                        observedAuthorization = request.Headers.Contains("Authorization");
                        request.Content = new StringContent(MutatedBody);
                        return next(request, cancellationToken);
                    }
                ),
            },
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.True(observedWorkspaceId);
        Assert.False(observedAuthorization);

        // The signed payload hash matches the body as mutated by the user handler,
        // proving signing ran after the handler.
        Assert.NotNull(wireRequest);
        Assert.True(wireRequest!.Headers.Contains("Authorization"));
        var signedPayloadHash = wireRequest.Headers.GetValues("x-amz-content-sha256").Single();
#if NET
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(MutatedBody));
#else
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(MutatedBody));
#endif
        var expectedHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        Assert.Equal(expectedHash, signedPayloadHash);
    }
}
