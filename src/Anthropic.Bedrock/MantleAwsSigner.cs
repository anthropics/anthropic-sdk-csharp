using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Anthropic.Bedrock;

internal struct MantleSigningRequest
{
    public required string Service;
    public required string Region;
    public required string HttpMethod;
    public required Uri Uri;
    public required DateTime Now;
    public required IDictionary<string, string> Headers;
    public required string PayloadHash;
    public required string AwsAccessKey;
    public required string AwsSecretKey;
}

/// <summary>
/// AWS Signature Version 4 signing helper for the Bedrock Mantle client.
/// </summary>
/// <remarks>
/// <para>
/// This is a self-contained SigV4 implementation rather than a wrapper around
/// <c>AWSSDK.Core</c>'s <c>AWS4Signer</c>, because that class's canonicalization
/// helpers are protected and its public surface expects the SDK's own
/// <c>IRequest</c> pipeline objects — not raw <see cref="HttpRequestMessage"/>s.
/// </para>
/// <para>
/// SigV4 requires every request element (path, query string, headers) to be
/// reduced to a single deterministic "canonical request" string before signing.
/// This ensures the signature is stable regardless of superficial differences
/// like query-parameter ordering or inconsistent percent-encoding.
/// See: https://docs.aws.amazon.com/general/latest/gr/sigv4-create-canonical-request.html
/// </para>
/// </remarks>
internal static class MantleAwsSigner
{
    /// <summary>
    /// Computes the AWS SigV4 Authorization header value.
    /// </summary>
    public static string GetAuthorizationHeader(MantleSigningRequest request)
    {
        const string Algorithm = "AWS4-HMAC-SHA256";

        var amzDate = ToAmzDate(request.Now);
        var datestamp = request.Now.ToString("yyyyMMdd");

        var canonicalQuerystring = CanonicalizeQueryString(request.Uri);
        var canonicalHeaders = CanonicalizeHeaders(request.Headers);
        var canonicalHeaderNames = CanonicalizeHeaderNames(request.Headers);
        // Each path segment is re-encoded to normalize percent-encoding, same as query params.
        var canonicalPath = string.Join(
            "/",
            request
                .Uri.AbsolutePath.Split('/')
                .Select(s => Uri.EscapeDataString(Uri.UnescapeDataString(s)))
        );
        var canonicalRequest =
            $"{request.HttpMethod}\n{canonicalPath}\n{canonicalQuerystring}\n{canonicalHeaders}\n{canonicalHeaderNames}\n{request.PayloadHash}";

        var credentialScope = $"{datestamp}/{request.Region}/{request.Service}/aws4_request";
        var hashedCanonicalRequest = CalculateHash(canonicalRequest);
        var stringToSign = $"{Algorithm}\n{amzDate}\n{credentialScope}\n{hashedCanonicalRequest}";

        var signingKey = GetSignatureKey(
            request.AwsSecretKey,
            datestamp,
            request.Region,
            request.Service
        );
        var signature = CalculateHmacHex(signingKey, stringToSign);

        return $"{Algorithm} Credential={request.AwsAccessKey}/{credentialScope}, SignedHeaders={canonicalHeaderNames}, Signature={signature}";
    }

    public static string ToAmzDate(DateTime date)
    {
        return date.ToString("yyyyMMddTHHmmssZ");
    }

    // SigV4 requires query parameters to be sorted lexicographically by key and
    // percent-encoded using RFC 3986. We round-trip through unescape/escape to
    // normalize any inconsistent encoding (e.g. %2f → %2F) before sorting.
    static string CanonicalizeQueryString(Uri uri)
    {
        var query = uri.Query;
        if (string.IsNullOrEmpty(query) || query == "?")
        {
            return "";
        }

        // Strip leading '?'
        if (query.StartsWith("?"))
        {
            query = query.Substring(1);
        }

        var pairs = new SortedDictionary<string, string>(StringComparer.Ordinal);
        foreach (var segment in query.Split('&'))
        {
            var eqIndex = segment.IndexOf('=');
            if (eqIndex >= 0)
            {
#if NET9_0_OR_GREATER
                pairs[Uri.EscapeDataString(Uri.UnescapeDataString(segment.AsSpan(0, eqIndex)))] =
                    Uri.EscapeDataString(Uri.UnescapeDataString(segment.AsSpan(eqIndex + 1)));
#else
                pairs[Uri.EscapeDataString(Uri.UnescapeDataString(segment.Substring(0, eqIndex)))] =
                    Uri.EscapeDataString(Uri.UnescapeDataString(segment.Substring(eqIndex + 1)));
#endif
            }
            else
            {
                pairs[Uri.EscapeDataString(Uri.UnescapeDataString(segment))] = "";
            }
        }

        var sb = new StringBuilder();
        foreach (var pair in pairs)
        {
            if (sb.Length > 0)
            {
                sb.Append('&');
            }
            sb.Append(pair.Key);
            sb.Append('=');
            sb.Append(pair.Value);
        }
        return sb.ToString();
    }

    // SigV4 requires signed header names to be lowercased and sorted
    // case-insensitively, then joined with semicolons. This list is included
    // in the Authorization header so the verifier knows which headers were signed.
    static string CanonicalizeHeaderNames(IDictionary<string, string> headers) =>
        string.Join(
            ";",
            headers
                .Keys.OrderBy(k => k, StringComparer.OrdinalIgnoreCase)
                .Select(k => k.ToLowerInvariant())
        );

    // SigV4 canonical headers must be lowercased, sorted case-insensitively,
    // trimmed, and have interior whitespace collapsed to single spaces.
    // Each header ends with a newline. This normalization ensures the signature
    // is stable regardless of how the HTTP library formats header values.
    static string CanonicalizeHeaders(IDictionary<string, string> headers) =>
        string.Join(
            "",
            headers
                .OrderBy(h => h.Key, StringComparer.OrdinalIgnoreCase)
                .Select(h => $"{h.Key.ToLowerInvariant()}:{CollapseWhitespace(h.Value.Trim())}\n")
        );

    static string CollapseWhitespace(string value)
    {
        var sb = new StringBuilder(value.Length);
        var prevWasSpace = false;
        foreach (var c in value)
        {
            if (char.IsWhiteSpace(c))
            {
                if (!prevWasSpace)
                {
                    sb.Append(' ');
                    prevWasSpace = true;
                }
            }
            else
            {
                sb.Append(c);
                prevWasSpace = false;
            }
        }
        return sb.ToString();
    }

    static byte[] GetSignatureKey(
        string key,
        string dateStamp,
        string regionName,
        string serviceName
    )
    {
        var kSecret = Encoding.UTF8.GetBytes($"AWS4{key}");
        var kDate = HmacSha256(kSecret, dateStamp);
        var kRegion = HmacSha256(kDate, regionName);
        var kService = HmacSha256(kRegion, serviceName);
        return HmacSha256(kService, "aws4_request");
    }

    static string CalculateHmacHex(byte[] key, string data)
    {
        var hash = HmacSha256(key, data);
#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(hash);
#else
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
#endif
    }

    static byte[] HmacSha256(byte[] key, string data)
    {
        using HMACSHA256 hmac = new(key);
        return hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
    }

    public static string CalculateHash(string data)
    {
#if NET9_0_OR_GREATER
        return Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(data)));
#elif NET
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(data));
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
#else
        using SHA256 sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
#endif
    }
}
