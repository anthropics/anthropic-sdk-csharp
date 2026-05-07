#pragma warning disable xUnit1051
using System;
using System.IO;
using System.Threading.Tasks;
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

public class IdentityTokenProviderTests : IDisposable
{
    private readonly string _tempDir;

    public IdentityTokenProviderTests()
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

    [Fact]
    public async Task StaticProvider_ReturnsToken()
    {
        var provider = new StaticIdentityTokenProvider("my-jwt-token");
        var token = await provider.GetIdentityTokenAsync();
        Assert.Equal("my-jwt-token", token);
    }

    [Fact]
    public void StaticProvider_ThrowsOnNull()
    {
        Assert.Throws<ArgumentNullException>(() => new StaticIdentityTokenProvider(null!));
    }

    [Fact]
    public async Task FileProvider_ReadsToken()
    {
        var path = Path.Combine(_tempDir, "jwt.txt");
        File.WriteAllText(path, "file-jwt-token\n");

        var provider = new FileIdentityTokenProvider(path);
        var token = await provider.GetIdentityTokenAsync();
        Assert.Equal("file-jwt-token", token);
    }

    [Fact]
    public async Task FileProvider_TrimsWhitespace()
    {
        var path = Path.Combine(_tempDir, "jwt.txt");
        File.WriteAllText(path, "  jwt-with-spaces  \n");

        var provider = new FileIdentityTokenProvider(path);
        var token = await provider.GetIdentityTokenAsync();
        Assert.Equal("jwt-with-spaces", token);
    }

    [Fact]
    public async Task FileProvider_ThrowsOnMissingFile()
    {
        var provider = new FileIdentityTokenProvider("/nonexistent/path/jwt.txt");
        await Assert.ThrowsAsync<FileNotFoundException>(() => provider.GetIdentityTokenAsync());
    }

    [Fact]
    public void FileProvider_ThrowsOnNull()
    {
        Assert.Throws<ArgumentNullException>(() => new FileIdentityTokenProvider(null!));
    }

    [Fact]
    public async Task FileProvider_ReReadsOnEachCall()
    {
        var path = Path.Combine(_tempDir, "jwt.txt");
        File.WriteAllText(path, "token-v1");

        var provider = new FileIdentityTokenProvider(path);
        var token1 = await provider.GetIdentityTokenAsync();
        Assert.Equal("token-v1", token1);

        File.WriteAllText(path, "token-v2");
        var token2 = await provider.GetIdentityTokenAsync();
        Assert.Equal("token-v2", token2);
    }
}
