// .NET Framework can't export the PKCS#8 private key that a service account key file holds.
#if NET
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Anthropic.Vertex;

namespace Anthropic.Tests.Vertex;

/// <summary>
/// Google's library only fetches a token for a service account key once the credential has
/// an OAuth scope, so the default credentials have to ask for one.
/// </summary>
[Collection("EnvVarMutating")]
public sealed class AnthropicVertexDefaultCredentialsTests
    : IClassFixture<AnthropicVertexDefaultCredentialsTests.ServiceAccount>,
        IDisposable
{
    private readonly ServiceAccount _serviceAccount;
    private readonly Dictionary<string, string?> _origEnv = new();

    public AnthropicVertexDefaultCredentialsTests(ServiceAccount serviceAccount)
    {
        _serviceAccount = serviceAccount;
        _serviceAccount.TokenRequests.Clear();
        SetEnv("GOOGLE_APPLICATION_CREDENTIALS", serviceAccount.KeyFile);
        SetEnv("ANTHROPIC_VERTEX_PROJECT_ID", "fake-project");
        SetEnv("VERTEX_ACCESS_TOKEN", null);
    }

    public void Dispose()
    {
        foreach (var entry in _origEnv)
        {
            Environment.SetEnvironmentVariable(entry.Key, entry.Value);
        }
    }

    private void SetEnv(string name, string? value)
    {
        _origEnv[name] = Environment.GetEnvironmentVariable(name);
        Environment.SetEnvironmentVariable(name, value);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task ServiceAccountKey_RequestsTheCloudPlatformScope(bool fromEnv)
    {
        Assert.SkipWhen(
            Environment.GetEnvironmentVariable("ANTHROPIC_LIVE") == "1",
            "Google caches the default credentials per process, and the live tests need the real ones."
        );
        var credentials = fromEnv
            ? await DefaultAnthropicVertexCredentials.FromEnvAsync()
            : new AnthropicVertexCredentials(null, "fake-project");
        Assert.NotNull(credentials);
        using var request = new HttpRequestMessage(HttpMethod.Post, "https://example.invalid");

        await credentials.ApplyAsync(request);

        var tokenRequest = Assert.Single(_serviceAccount.TokenRequests);
        Assert.Equal("https://www.googleapis.com/auth/cloud-platform", ScopeOf(tokenRequest));
        Assert.Equal("Bearer fake-token", request.Headers.Authorization?.ToString());
    }

    /// <summary>Reads the <c>scope</c> claim of the signed JWT that a token request carries.</summary>
    private static string? ScopeOf(string tokenRequest)
    {
        var assertion = HttpUtility.ParseQueryString(tokenRequest)["assertion"];
        Assert.NotNull(assertion);
        var claims = assertion.Split('.')[1].Replace('-', '+').Replace('_', '/');
        claims = claims.PadRight(claims.Length + (4 - claims.Length % 4) % 4, '=');
        using var json = JsonDocument.Parse(Convert.FromBase64String(claims));
        return json.RootElement.GetProperty("scope").GetString();
    }

    /// <summary>
    /// A throwaway key file whose token endpoint is a loopback server. Google caches the
    /// default credentials per process, so every test in the class has to share one.
    /// </summary>
    public sealed class ServiceAccount : IDisposable
    {
        private readonly HttpListener _tokenServer = new();

        public string KeyFile { get; } = Path.GetTempFileName();

        /// <summary>The form body of each request the token endpoint received.</summary>
        public ConcurrentQueue<string> TokenRequests { get; } = new();

        public ServiceAccount()
        {
            var tcp = new TcpListener(IPAddress.Loopback, 0);
            tcp.Start();
            var tokenUri = $"http://127.0.0.1:{((IPEndPoint)tcp.LocalEndpoint).Port}/";
            tcp.Stop();

            _tokenServer.Prefixes.Add(tokenUri);
            _tokenServer.Start();
            _ = Task.Run(ServeTokensAsync);

            using var key = RSA.Create(2048);
            File.WriteAllText(
                KeyFile,
                JsonSerializer.Serialize(
                    new
                    {
                        type = "service_account",
                        client_email = "fake@example.invalid",
                        private_key = key.ExportPkcs8PrivateKeyPem(),
                        token_uri = tokenUri,
                    }
                )
            );
        }

        private async Task ServeTokensAsync()
        {
            try
            {
                while (true)
                {
                    var context = await _tokenServer.GetContextAsync().ConfigureAwait(false);
                    using var body = new StreamReader(context.Request.InputStream);
                    TokenRequests.Enqueue(await body.ReadToEndAsync().ConfigureAwait(false));
                    context.Response.Close(
                        """{"access_token":"fake-token","token_type":"Bearer","expires_in":3600}"""u8.ToArray(),
                        willBlock: true
                    );
                }
            }
            catch (Exception e) when (e is HttpListenerException or ObjectDisposedException)
            {
                // Closing the listener ends the loop.
            }
        }

        public void Dispose()
        {
            _tokenServer.Close();
            File.Delete(KeyFile);
        }
    }
}
#endif
