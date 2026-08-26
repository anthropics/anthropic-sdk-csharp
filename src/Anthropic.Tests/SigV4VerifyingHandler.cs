using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Anthropic.Tests;

/// <summary>
/// Stands in for an AWS SigV4-authenticated gateway: recomputes the signature over the
/// request exactly as received, independently of the SDK's signer, and answers 403
/// unless it matches the <c>Authorization</c> header.
/// </summary>
sealed class SigV4VerifyingHandler : HttpMessageHandler
{
    const string Algorithm = "AWS4-HMAC-SHA256";

    readonly string _secretKey;
    readonly string _successBody;

    public SigV4VerifyingHandler(string secretKey, string successBody)
    {
        _secretKey = secretKey;
        _successBody = successBody;
    }

    public List<Uri> VerifiedRequestUris { get; } = [];

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        var failure = await Verify(request).ConfigureAwait(false);
        if (failure != null)
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                Content = new StringContent(
                    "{\"message\":\"The request signature we calculated does not match the signature you provided. "
                        + failure.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n")
                        + "\"}",
                    Encoding.UTF8,
                    "application/json"
                ),
            };
        }

        VerifiedRequestUris.Add(request.RequestUri!);
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_successBody, Encoding.UTF8, "application/json"),
        };
    }

    async Task<string?> Verify(HttpRequestMessage request)
    {
        if (!request.Headers.TryGetValues("Authorization", out var authorizationValues))
        {
            return "Missing Authorization header.";
        }
        var authorization = authorizationValues.Single();
        if (!authorization.StartsWith(Algorithm + " ", StringComparison.Ordinal))
        {
            return "Authorization header is not SigV4.";
        }
        var fields = authorization
            .Substring(Algorithm.Length + 1)
            .Split(',')
            .Select(field => field.Trim().Split(['='], 2))
            .ToDictionary(kv => kv[0], kv => kv[1], StringComparer.Ordinal);
        var credential = fields["Credential"].Split('/');
        var (datestamp, region, service) = (credential[1], credential[2], credential[3]);
        var signedHeaders = fields["SignedHeaders"];
        var amzDate = HeaderValue(request, "x-amz-date");

        var uri = request.RequestUri!;
        var canonicalPath = string.Join(
            "/",
            uri.AbsolutePath.Split('/').Select(s => UriEncode(Uri.UnescapeDataString(s)))
        );

        // Every name=value pair is part of the canonical request, repeated names included,
        // ordered by encoded name and then encoded value.
        var query = uri.Query.TrimStart('?');
        var pairs = new List<(string Key, string Value)>();
        foreach (var pair in query.Length == 0 ? [] : query.Split('&'))
        {
            var eq = pair.IndexOf('=');
            pairs.Add(
                eq < 0
                    ? (UriEncode(Uri.UnescapeDataString(pair)), "")
                    : (
                        UriEncode(Uri.UnescapeDataString(pair.Substring(0, eq))),
                        UriEncode(Uri.UnescapeDataString(pair.Substring(eq + 1)))
                    )
            );
        }
        pairs.Sort(
            (a, b) =>
            {
                var byKey = string.CompareOrdinal(a.Key, b.Key);
                return byKey != 0 ? byKey : string.CompareOrdinal(a.Value, b.Value);
            }
        );
        var canonicalQuery = string.Join("&", pairs.Select(p => p.Key + "=" + p.Value));

        var canonicalHeaders = string.Concat(
            signedHeaders
                .Split(';')
                .Select(name => name + ":" + CollapseWhitespace(HeaderValue(request, name)) + "\n")
        );

        var body =
            request.Content == null
                ? []
                : await request.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
        var payloadHash = Hex(Sha256(body));
        if (
            request.Headers.TryGetValues("x-amz-content-sha256", out var declaredHash)
            && declaredHash.Single() != payloadHash
        )
        {
            return "x-amz-content-sha256 does not match the request body.";
        }

        var canonicalRequest =
            $"{request.Method.Method}\n{canonicalPath}\n{canonicalQuery}\n{canonicalHeaders}\n{signedHeaders}\n{payloadHash}";
        var scope = $"{datestamp}/{region}/{service}/aws4_request";
        var stringToSign =
            $"{Algorithm}\n{amzDate}\n{scope}\n{Hex(Sha256(Encoding.UTF8.GetBytes(canonicalRequest)))}";

        var key = Hmac(Encoding.UTF8.GetBytes("AWS4" + _secretKey), datestamp);
        key = Hmac(key, region);
        key = Hmac(key, service);
        key = Hmac(key, "aws4_request");
        var expectedSignature = Hex(Hmac(key, stringToSign));

        return expectedSignature == fields["Signature"]
            ? null
            : "Canonical request seen by the gateway:\n" + canonicalRequest;
    }

    /// <summary>
    /// The header value as it appears on the wire: request or content headers, with
    /// repeated headers comma-joined, and <c>Host</c> defaulting to the URI authority.
    /// </summary>
    static string HeaderValue(HttpRequestMessage request, string name)
    {
        if (request.Headers.TryGetValues(name, out var values))
        {
            return string.Join(",", values);
        }
        if (request.Content != null && request.Content.Headers.TryGetValues(name, out values))
        {
            return string.Join(",", values);
        }
        if (name.Equals("host", StringComparison.OrdinalIgnoreCase))
        {
            return request.RequestUri!.Authority;
        }
        return "";
    }

    static string CollapseWhitespace(string value) =>
        string.Join(" ", value.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));

    /// <summary>RFC 3986 percent-encoding as SigV4 defines it: only unreserved bytes pass through.</summary>
    static string UriEncode(string value)
    {
        var sb = new StringBuilder();
        foreach (var b in Encoding.UTF8.GetBytes(value))
        {
            var c = (char)b;
            if (
                (c >= 'A' && c <= 'Z')
                || (c >= 'a' && c <= 'z')
                || (c >= '0' && c <= '9')
                || c == '-'
                || c == '_'
                || c == '.'
                || c == '~'
            )
            {
                sb.Append(c);
            }
            else
            {
                sb.Append('%').Append(b.ToString("X2"));
            }
        }
        return sb.ToString();
    }

    static byte[] Sha256(byte[] data)
    {
#if NET
        return SHA256.HashData(data);
#else
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(data);
#endif
    }

    static byte[] Hmac(byte[] key, string data)
    {
        using var hmac = new HMACSHA256(key);
        return hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
    }

    static string Hex(byte[] bytes) =>
        BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
}
