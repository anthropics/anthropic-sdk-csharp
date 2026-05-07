using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Anthropic.Credentials;

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

        // string overloads (not char) for netstandard2.0 compat — Contains(char) is netcoreapp2.1+.
        if (
            profile.Contains("..")
            || profile.Contains("/")
            || profile.Contains("\\")
            || profile.Contains("\0")
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
    /// Deserializes a token-endpoint 2xx response body, wrapping JSON failures in
    /// <see cref="WorkloadIdentityException"/> so callers see a domain error instead
    /// of a bare <see cref="JsonException"/>.
    /// </summary>
    internal static JsonElement DeserializeTokenResponse(string responseBody)
    {
        try
        {
            return JsonSerializer.Deserialize<JsonElement>(responseBody);
        }
        catch (JsonException ex)
        {
            throw new WorkloadIdentityException(
                "Token endpoint returned a non-JSON 2xx response.",
                ex
            );
        }
    }

    /// <summary>
    /// Reads <c>expires_in</c> from a token response. Absent → <c>null</c> (no expiry).
    /// Present but unparsable → throws. Accepts integer, fractional, and string forms
    /// (the server has historically sent it as a string).
    /// </summary>
    internal static long? ParseExpiresIn(JsonElement root)
    {
        if (!root.TryGetProperty("expires_in", out var element))
        {
            return null;
        }

        long seconds;
        if (element.ValueKind == JsonValueKind.Number && element.TryGetDouble(out var d))
        {
            seconds = (long)d;
        }
        else if (
            element.ValueKind == JsonValueKind.String
            && long.TryParse(element.GetString(), out var parsed)
        )
        {
            seconds = parsed;
        }
        else
        {
            throw new WorkloadIdentityException("Token response 'expires_in' has unexpected type.");
        }

        return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + seconds;
    }

    /// <summary>
    /// Validates the optional <c>token_type</c> field of an RFC 6749 §5.1 token
    /// response. If present and not <c>Bearer</c> (case-insensitive), throws.
    /// Absent is allowed for servers that omit it.
    /// </summary>
    internal static void RequireBearerTokenType(JsonElement root)
    {
        if (
            root.TryGetProperty("token_type", out var tt)
            && tt.ValueKind == JsonValueKind.String
            && !string.Equals(tt.GetString(), "Bearer", StringComparison.OrdinalIgnoreCase)
        )
        {
            throw new WorkloadIdentityException(
                $"Unexpected token_type '{tt.GetString()}'; only Bearer is supported."
            );
        }
    }

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
                    return Truncate(redacted, CredentialsConstants.MaxErrorBodyLength);
                }
            }
        }
        catch (JsonException)
        {
            // Not valid JSON — fall through to the redacted placeholder.
        }

        // Body is not a JSON object with RFC-6749 error fields. Don't echo it back —
        // it could be a misrouted JSON payload containing tokens, or an HTML error page.
        // Surface only the length and a short prefix as a debugging hint.
        //
        // The 40-char prefix is for diagnostic value only. It must NOT be routed through
        // any structured-logging or telemetry sink that could persist it; if the SDK gains
        // such a sink, drop the prefix and emit only the byte count.
        var prefix = Truncate(body, 40);
        return $"<non-standard error body redacted; {body.Length} bytes, starts with '{prefix}'>";
    }

    private static string Truncate(string value, int max)
    {
        if (value.Length <= max)
        {
            return value;
        }

#if NET
        return string.Concat(value.AsSpan(0, max), "...");
#else
        return value.Substring(0, max) + "...";
#endif
    }
}
