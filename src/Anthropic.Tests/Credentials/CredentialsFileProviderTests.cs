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
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

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
#if NET
        if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
        {
            File.SetUnixFileMode(path, UnixFileMode.UserRead | UnixFileMode.UserWrite);
        }
#endif
        return path;
    }

    [Fact]
    public async Task ReadsValidCredentialsFile()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "sk-ant-oat01-test",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600,
            }
        );

        using var provider = new CredentialsFileProvider(path, "https://api.anthropic.com");

        var token = await provider.GetTokenAsync();

        Assert.Equal("sk-ant-oat01-test", token.Token);
    }

    [Fact]
    public async Task RefreshesExpiredToken()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
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

        var token = await provider.GetTokenAsync();

        Assert.Equal("refreshed-token", token.Token);

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
        var missing = Path.Combine(_tempDir, "does-not-exist.json");
        using var provider = new CredentialsFileProvider(missing, "https://api.anthropic.com");

        await Assert.ThrowsAsync<FileNotFoundException>(async () => await provider.GetTokenAsync());
    }

    [Fact]
    public async Task ThrowsWhenExpiredAndNoRefreshToken()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "expired",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
            }
        );

        using var provider = new CredentialsFileProvider(path, "https://api.anthropic.com");

        await Assert.ThrowsAsync<WorkloadIdentityException>(async () =>
            await provider.GetTokenAsync()
        );
    }

    [Fact]
    public async Task ForceRefresh_SkipsValidTokenAndRefreshes()
    {
        // On-disk token is unexpired, but forceRefresh=true should still hit the
        // refresh endpoint (the server just rejected this token with a 401).
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "rejected-but-unexpired",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 600,
                refresh_token = "refresh-tok",
            }
        );

        var handler = new FakeHandler(_ =>
        {
            var json = JsonSerializer.Serialize(
                new { access_token = "force-refreshed", expires_in = 600 }
            );
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                }
            );
        });

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        // Normal call returns the on-disk token without contacting the server.
        var t1 = await provider.GetTokenAsync();
        Assert.Equal("rejected-but-unexpired", t1.Token);
        Assert.Empty(handler.Requests);

        // Force-refresh bypasses the short-circuit.
        var t2 = await provider.GetTokenAsync(forceRefresh: true);
        Assert.Equal("force-refreshed", t2.Token);
        Assert.Single(handler.Requests);
    }

    [Fact]
    public async Task Refresh_WritesUpdatedCredentialsFile()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "expired-token",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                refresh_token = "rt-original",
            }
        );

        var handler = OkRefreshHandler(
            new
            {
                access_token = "at-new",
                expires_in = 3600,
                refresh_token = "rt-rotated",
            }
        );

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        var beforeRefresh = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var token = await provider.GetTokenAsync();
        Assert.Equal("at-new", token.Token);

        // Read what was written back to disk.
        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        var root = doc.RootElement;
        Assert.Equal("1.0", root.GetProperty("version").GetString());
        Assert.Equal("oauth_token", root.GetProperty("type").GetString());
        Assert.Equal("at-new", root.GetProperty("access_token").GetString());
        Assert.Equal("rt-rotated", root.GetProperty("refresh_token").GetString());

        var expiresAt = root.GetProperty("expires_at").GetInt64();
        Assert.InRange(expiresAt, beforeRefresh + 3600 - 60, beforeRefresh + 3600 + 60);
    }

    [Fact]
    public async Task Refresh_PreservesRefreshTokenWhenResponseOmitsIt()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "expired-token",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                refresh_token = "rt-original",
            }
        );

        // Server response intentionally omits refresh_token.
        var handler = OkRefreshHandler(new { access_token = "at-new", expires_in = 3600 });

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        await provider.GetTokenAsync();

        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        var root = doc.RootElement;
        Assert.Equal("at-new", root.GetProperty("access_token").GetString());
        // The original refresh_token must be carried forward, not dropped.
        Assert.Equal("rt-original", root.GetProperty("refresh_token").GetString());
    }

#if NET
    [Fact]
    public async Task Refresh_PreservesRestrictiveFilePermissions()
    {
        if (!OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS())
        {
            // POSIX file modes are not applicable on Windows.
            return;
        }

        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "expired-token",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                refresh_token = "rt-original",
            }
        );

        var handler = OkRefreshHandler(
            new
            {
                access_token = "at-new",
                expires_in = 3600,
                refresh_token = "rt-rotated",
            }
        );

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        await provider.GetTokenAsync();

        var mode = File.GetUnixFileMode(path);
        Assert.True(
            (mode & UnixFileMode.UserRead) != 0 && (mode & UnixFileMode.UserWrite) != 0,
            $"expected user rw, got {mode}"
        );
        const UnixFileMode forbidden =
            UnixFileMode.GroupRead
            | UnixFileMode.GroupWrite
            | UnixFileMode.OtherRead
            | UnixFileMode.OtherWrite;
        Assert.True(
            (mode & forbidden) == 0,
            $"credentials file is readable/writable by group or other after refresh: {mode}"
        );
    }
#endif

    [Fact]
    public async Task Refresh_SendsClientIdInRequestBody()
    {
        var path = WriteExpiredFixture();

        string? capturedBody = null;
        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            return Ok(new { access_token = "at-new", expires_in = 3600 });
        });

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient,
            clientId: "test-client-123"
        );

        await provider.GetTokenAsync();

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        var root = doc.RootElement;
        Assert.Equal("refresh_token", root.GetProperty("grant_type").GetString());
        Assert.Equal("rt-original", root.GetProperty("refresh_token").GetString());
        Assert.Equal("test-client-123", root.GetProperty("client_id").GetString());
    }

    [Fact]
    public async Task Refresh_OmitsClientIdWhenNotConfigured()
    {
        var path = WriteExpiredFixture();

        string? capturedBody = null;
        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            return Ok(new { access_token = "at-new", expires_in = 3600 });
        });

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient,
            clientId: null
        );

        await provider.GetTokenAsync();

        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.False(
            doc.RootElement.TryGetProperty("client_id", out _),
            "client_id key should be omitted entirely when not configured"
        );
    }

    [Fact]
    public async Task Refresh_PreservesUnknownCredentialsFileKeys()
    {
        var path = WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "expired-token",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                refresh_token = "rt-original",
                scope = "read write",
                organization_uuid = "org-abc",
                account_email = "x@y.z",
                some_future_field = new { nested = true },
            }
        );

        var handler = OkRefreshHandler(
            new
            {
                access_token = "at-new",
                expires_in = 3600,
                refresh_token = "rt-rotated",
            }
        );

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        await provider.GetTokenAsync();

        using var doc = JsonDocument.Parse(File.ReadAllText(path));
        var root = doc.RootElement;

        // Known fields updated.
        Assert.Equal("at-new", root.GetProperty("access_token").GetString());
        Assert.Equal("rt-rotated", root.GetProperty("refresh_token").GetString());

        // Unknown fields round-tripped.
        Assert.Equal("read write", root.GetProperty("scope").GetString());
        Assert.Equal("org-abc", root.GetProperty("organization_uuid").GetString());
        Assert.Equal("x@y.z", root.GetProperty("account_email").GetString());
        Assert.True(root.GetProperty("some_future_field").GetProperty("nested").GetBoolean());
    }

#if NET
    [Fact]
    public async Task Refresh_WriteFailure_StillReturnsToken()
    {
        if (!OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS())
        {
            // POSIX-only fixture; on Windows the read-only-dir trick doesn't apply.
            return;
        }

        // Create the credentials file inside a subdirectory, then make that
        // directory read-only so the temp-file write in WriteRefreshedCredentials
        // fails with UnauthorizedAccessException.
        var subdir = Path.Combine(_tempDir, "ro");
        Directory.CreateDirectory(subdir);
        var path = Path.Combine(subdir, "credentials.json");
        File.WriteAllText(
            path,
            JsonSerializer.Serialize(
                new
                {
                    version = "1.0",
                    type = "oauth_token",
                    access_token = "expired-token",
                    expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                    refresh_token = "rt-original",
                }
            )
        );
        File.SetUnixFileMode(path, UnixFileMode.UserRead | UnixFileMode.UserWrite);
        // Directory: r-x only — file is still readable, but creating the
        // sibling temp file fails.
        File.SetUnixFileMode(subdir, UnixFileMode.UserRead | UnixFileMode.UserExecute);

        var handler = OkRefreshHandler(new { access_token = "at-new", expires_in = 3600 });

        using var httpClient = new HttpClient(handler);
        using var provider = new CredentialsFileProvider(
            path,
            "https://api.anthropic.com",
            httpClient
        );

        var originalErr = Console.Error;
        var captured = new StringWriter();
        Console.SetError(captured);
        AccessToken token;
        try
        {
            token = await provider.GetTokenAsync();
        }
        finally
        {
            Console.SetError(originalErr);
            // Restore permissions so test cleanup can delete the directory.
            File.SetUnixFileMode(
                subdir,
                UnixFileMode.UserRead | UnixFileMode.UserWrite | UnixFileMode.UserExecute
            );
        }

        // The fresh token is returned despite the persist failure.
        Assert.Equal("at-new", token.Token);
        Assert.Contains("failed to persist refreshed credentials", captured.ToString());
        Assert.Contains("in-memory only", captured.ToString());
    }
#endif

    private string WriteExpiredFixture()
    {
        return WriteCredentialsFile(
            new
            {
                version = "1.0",
                type = "oauth_token",
                access_token = "expired-token",
                expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 100,
                refresh_token = "rt-original",
            }
        );
    }

    private static HttpResponseMessage Ok(object body)
    {
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json"
            ),
        };
    }

    private static FakeHandler OkRefreshHandler(object responseBody)
    {
        var json = JsonSerializer.Serialize(responseBody);
        return new FakeHandler(_ =>
            Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                }
            )
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
