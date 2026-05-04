#pragma warning disable xUnit1051
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Oidc;

namespace Anthropic.Tests.Oidc;

public class WorkloadIdentityCredentialsTests
{
    private class FakeHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _handler;
        public List<HttpRequestMessage> Requests { get; } = new();

        public FakeHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> handler)
        {
            _handler = handler;
        }

        public FakeHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
        {
            _handler = r => Task.FromResult(handler(r));
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            // Clone the request details we want to inspect since content may be disposed
            Requests.Add(request);
            return await _handler(request);
        }
    }

    private static HttpResponseMessage OkTokenResponse(int expiresIn = 600)
    {
        var json = JsonSerializer.Serialize(
            new { access_token = "sk-ant-oat01-test", expires_in = expiresIn }
        );
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
        };
    }

    [Fact]
    public async Task ExchangeToken_SendsCorrectRequest()
    {
        string? capturedBody = null;

        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            return OkTokenResponse();
        });

        using var httpClient = new HttpClient(handler);
        using var creds = new WorkloadIdentityCredentials(
            new WorkloadIdentityOptions
            {
                FederationRuleId = "fdrl_01test",
                OrganizationId = "00000000-0000-0000-0000-000000000001",
                ServiceAccountId = "svac_01test",
                IdentityTokenProvider = new StaticIdentityTokenProvider("jwt-token-here"),
                BaseUrl = "https://api.anthropic.com",
                HttpClient = httpClient,
            }
        );

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.anthropic.com/v1/messages"
        );
        await creds.ApplyAsync(request);

        // Verify token was applied to the API request
        Assert.Equal("Bearer", request.Headers.Authorization!.Scheme);
        Assert.Equal("sk-ant-oat01-test", request.Headers.Authorization!.Parameter);
        Assert.Contains("oauth-2025-04-20", request.Headers.GetValues("anthropic-beta"));

        // Verify the token exchange request
        Assert.Single(handler.Requests);
        var tokenRequest = handler.Requests[0];
        Assert.Equal(HttpMethod.Post, tokenRequest.Method);
        Assert.Equal(
            "https://api.anthropic.com/v1/oauth/token",
            tokenRequest.RequestUri!.ToString()
        );

        // Verify token exchange has BOTH beta headers
        var betaHeader = string.Join(",", tokenRequest.Headers.GetValues("anthropic-beta"));
        Assert.Contains("oauth-2025-04-20", betaHeader);
        Assert.Contains("oidc-federation-2026-04-01", betaHeader);

        // Verify request body
        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        var root = doc.RootElement;
        Assert.Equal(
            "urn:ietf:params:oauth:grant-type:jwt-bearer",
            root.GetProperty("grant_type").GetString()
        );
        Assert.Equal("jwt-token-here", root.GetProperty("assertion").GetString());
        Assert.Equal("fdrl_01test", root.GetProperty("federation_rule_id").GetString());
        Assert.Equal(
            "00000000-0000-0000-0000-000000000001",
            root.GetProperty("organization_id").GetString()
        );
        Assert.Equal("svac_01test", root.GetProperty("service_account_id").GetString());
    }

    [Fact]
    public async Task ExchangeToken_ParsesExpiresIn()
    {
        var handler = new FakeHandler(_ => OkTokenResponse(300));

        using var httpClient = new HttpClient(handler);
        using var creds = new WorkloadIdentityCredentials(
            new WorkloadIdentityOptions
            {
                FederationRuleId = "fdrl_01test",
                IdentityTokenProvider = new StaticIdentityTokenProvider("jwt"),
                BaseUrl = "https://api.anthropic.com",
                HttpClient = httpClient,
            }
        );

        var request = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await creds.ApplyAsync(request);

        Assert.Equal("sk-ant-oat01-test", request.Headers.Authorization!.Parameter);
    }

    [Fact]
    public async Task ExchangeToken_ErrorResponse_ThrowsWithRedactedBody()
    {
        var handler = new FakeHandler(_ =>
        {
            var json = JsonSerializer.Serialize(
                new
                {
                    error = "invalid_grant",
                    error_description = "Bad JWT",
                    secret = "should-not-appear",
                }
            );
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
        });

        using var httpClient = new HttpClient(handler);
        using var creds = new WorkloadIdentityCredentials(
            new WorkloadIdentityOptions
            {
                FederationRuleId = "fdrl_01test",
                IdentityTokenProvider = new StaticIdentityTokenProvider("jwt"),
                BaseUrl = "https://api.anthropic.com",
                HttpClient = httpClient,
            }
        );

        var request = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        var ex = await Assert.ThrowsAsync<WorkloadIdentityException>(() =>
            creds.ApplyAsync(request).AsTask()
        );

        Assert.Equal(HttpStatusCode.BadRequest, ex.StatusCode);
        Assert.Contains("invalid_grant", ex.ResponseBody!);
        Assert.DoesNotContain("should-not-appear", ex.ResponseBody!);
    }

    [Fact]
    public void RejectsHttpBaseUrl()
    {
        Assert.Throws<ArgumentException>(() =>
            new WorkloadIdentityCredentials(
                new WorkloadIdentityOptions
                {
                    FederationRuleId = "fdrl_01test",
                    IdentityTokenProvider = new StaticIdentityTokenProvider("jwt"),
                    BaseUrl = "http://evil.example.com",
                }
            )
        );
    }

    [Fact]
    public void AllowsLocalhostHttp()
    {
        using var creds = new WorkloadIdentityCredentials(
            new WorkloadIdentityOptions
            {
                FederationRuleId = "fdrl_01test",
                IdentityTokenProvider = new StaticIdentityTokenProvider("jwt"),
                BaseUrl = "http://localhost:4010",
            }
        );
    }

    [Fact]
    public async Task InvalidateToken_ForcesRefresh()
    {
        var callCount = 0;
        var handler = new FakeHandler(_ =>
        {
            callCount++;
            var json = JsonSerializer.Serialize(
                new { access_token = $"tok-{callCount}", expires_in = 600 }
            );
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
        });

        using var httpClient = new HttpClient(handler);
        using var creds = new WorkloadIdentityCredentials(
            new WorkloadIdentityOptions
            {
                FederationRuleId = "fdrl_01test",
                IdentityTokenProvider = new StaticIdentityTokenProvider("jwt"),
                BaseUrl = "https://api.anthropic.com",
                HttpClient = httpClient,
            }
        );

        var req1 = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await creds.ApplyAsync(req1);
        Assert.Equal("tok-1", req1.Headers.Authorization!.Parameter);

        creds.InvalidateToken();

        var req2 = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await creds.ApplyAsync(req2);
        Assert.Equal("tok-2", req2.Headers.Authorization!.Parameter);
    }
}
