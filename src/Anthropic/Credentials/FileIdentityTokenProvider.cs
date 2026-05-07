using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Credentials;

/// <summary>
/// Reads a JWT identity token from a file on each call.
/// The file is re-read every time to support token rotation by the platform.
/// </summary>
public sealed class FileIdentityTokenProvider : IIdentityTokenProvider
{
    private readonly string _filePath;

    public FileIdentityTokenProvider(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public Task<string> GetIdentityTokenAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException(
                $"Identity token file not found: {_filePath}",
                _filePath
            );
        }

        var token = File.ReadAllText(_filePath).Trim();
        return Task.FromResult(token);
    }
}
