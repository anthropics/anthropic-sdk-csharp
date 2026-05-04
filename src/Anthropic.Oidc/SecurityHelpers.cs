using System.Text.Json;

namespace Anthropic.Oidc;

internal static class SecurityHelpers
{
    /// <summary>
    /// Validates that a URL uses HTTPS. Allows HTTP only for localhost (testing).
    /// </summary>
    internal static void EnforceHttps(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
        {
            throw new ArgumentException($"Invalid URL: {url}", nameof(url));
        }

        if (
            uri.Scheme != Uri.UriSchemeHttps
            && !(
                uri.Scheme == Uri.UriSchemeHttp
                && (
                    uri.Host == "localhost"
                    || uri.Host == "127.0.0.1"
                    || uri.Host == "::1"
                    || uri.Host == "[::1]"
                )
            )
        )
        {
            throw new ArgumentException(
                $"HTTPS is required for token exchange URLs. Got: {uri.Scheme}://{uri.Host}",
                nameof(url)
            );
        }
    }

    /// <summary>
    /// Validates a profile name to prevent path traversal attacks.
    /// </summary>
    internal static void ValidateProfileName(string profile)
    {
        if (string.IsNullOrEmpty(profile))
        {
            throw new ArgumentException("Profile name cannot be empty.", nameof(profile));
        }

#if NET
        if (profile.StartsWith('.'))
#else
        if (profile.StartsWith(".", StringComparison.Ordinal))
#endif
        {
            throw new ArgumentException("Profile name cannot start with a dot.", nameof(profile));
        }

        if (
            profile.Contains("..")
            || profile.Contains('/')
            || profile.Contains('\\')
            || profile.Contains('\0')
        )
        {
            throw new ArgumentException(
                "Profile name contains invalid characters.",
                nameof(profile)
            );
        }
    }

#if NET
    /// <summary>
    /// On POSIX systems, checks that a credentials file is not world-readable.
    /// </summary>
    internal static void CheckFilePermissions(string path)
    {
        if (!OperatingSystem.IsLinux() && !OperatingSystem.IsMacOS())
        {
            return;
        }

        var mode = File.GetUnixFileMode(path);

        if ((mode & (UnixFileMode.OtherRead | UnixFileMode.GroupRead)) != 0)
        {
            throw new InvalidOperationException(
                $"Credentials file {path} is world-readable. Set permissions to 0600."
            );
        }
    }
#else
    internal static void CheckFilePermissions(string path)
    {
        // File permission checks are only available on .NET 8+
    }
#endif

    /// <summary>
    /// Redacts an error response body, keeping only RFC 6749 standard error fields
    /// and truncating to a maximum length.
    /// </summary>
    internal static string RedactErrorBody(string body)
    {
        if (string.IsNullOrEmpty(body))
        {
            return body;
        }

        try
        {
            var root = JsonSerializer.Deserialize<JsonElement>(body);
            if (root.ValueKind == JsonValueKind.Object)
            {
                var safeFields = new Dictionary<string, string>();
                foreach (var field in new[] { "error", "error_description", "error_uri" })
                {
                    if (
                        root.TryGetProperty(field, out var value)
                        && value.ValueKind == JsonValueKind.String
                    )
                    {
                        var str = value.GetString();
                        if (str != null)
                        {
                            safeFields[field] = str;
                        }
                    }
                }

                if (safeFields.Count > 0)
                {
                    var redacted = JsonSerializer.Serialize(safeFields);
                    return Truncate(redacted);
                }
            }
        }
        catch (JsonException)
        {
            // Not valid JSON, fall through to raw truncation
        }

        return Truncate(body);
    }

    private static string Truncate(string value)
    {
        if (value.Length <= OidcConstants.MaxErrorBodyLength)
        {
            return value;
        }

#if NET
        return string.Concat(value.AsSpan(0, OidcConstants.MaxErrorBodyLength), "...");
#else
        return value.Substring(0, OidcConstants.MaxErrorBodyLength) + "...";
#endif
    }
}
