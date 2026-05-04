#pragma warning disable xUnit1051
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Oidc;

namespace Anthropic.Tests.Oidc;

public class CredentialsFileProviderTests : IDisposable
{
    private readonly string _tempDir;

    public CredentialsFileProviderTests()
    {
        _tempDir = Path.Combine(
            Path.GetTempPath(),
            "anthropic_test_" + Guid.NewGuid().ToString("N")
        );
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        try
        {
            Directory.Delete(_tempDir, true);
        }
        catch
        {
            // best effort
        }
        GC.SuppressFinalize(this);
    }

    private string WriteCredentialsFile(object data)
    {
        var path = Path.Combine(_tempDir, "credentials.json");
        File.WriteAllText(path, JsonSerializer.Serialize(data));
        return path;
    }

    [Fact]
    public async Task ReadsValidCredentialsFile()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = 1,
                type = "oauth_token",
                access_token = "sk-ant-oat01-test",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600,
            }
        );

        using var provider = new CredentialsFileProvider(path, "https://api.anthropic.com");

        var request = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await provider.ApplyAsync(request);

        Assert.Equal("Bearer", request.Headers.Authorization!.Scheme);
        Assert.Equal("sk-ant-oat01-test", request.Headers.Authorization.Parameter);
    }

    [Fact]
    public async Task RefreshesExpiredToken()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = 1,
                type = "oauth_token",
                access_token = "expired-token",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                refresh_token = "refresh-tok",
            }
        );

        string? capturedBody = null;
        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            var json = JsonSerializer.Serialize(
                new
                {
                    access_token = "refreshed-token",
                    expires_in = 600,
                    refresh_token = "new-refresh-tok",
                }
            );
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
        });

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        var request = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await provider.ApplyAsync(request);

        Assert.Equal("refreshed-token", request.Headers.Authorization!.Parameter);

        // Verify refresh request body
        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.Equal("refresh_token", doc.RootElement.GetProperty("grant_type").GetString());
        Assert.Equal("refresh-tok", doc.RootElement.GetProperty("refresh_token").GetString());

        // Verify refresh request uses oauth beta only (NOT federation)
        var tokenRequest = handler.Requests[0];
        var betaHeader = string.Join(",", tokenRequest.Headers.GetValues("anthropic-beta"));
        Assert.Contains("oauth-2025-04-20", betaHeader);
        Assert.DoesNotContain("oidc-federation", betaHeader);
    }

    [Fact]
    public async Task ThrowsWhenFileNotFound()
    {
        using var provider = new CredentialsFileProvider(
            "/nonexistent/path.json",
            "https://api.anthropic.com"
        );

        var request = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await Assert.ThrowsAsync<FileNotFoundException>(() =>
            provider.ApplyAsync(request).AsTask()
        );
    }

    [Fact]
    public async Task ThrowsWhenExpiredAndNoRefreshToken()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = 1,
                type = "oauth_token",
                access_token = "expired",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
            }
        );

        using var provider = new CredentialsFileProvider(path, "https://api.anthropic.com");

        var request = new HttpRequestMessage(HttpMethod.Get, "https://test.com");
        await Assert.ThrowsAsync<WorkloadIdentityException>(() =>
            provider.ApplyAsync(request).AsTask()
        );
    }

    private class FakeHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _handler;
        public List<HttpRequestMessage> Requests { get; } = new();

        public FakeHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> handler)
        {
            _handler = handler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests.Add(request);
            return await _handler(request);
        }
    }
}
