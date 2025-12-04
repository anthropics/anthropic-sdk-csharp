using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Anthropic.Bedrock;

/// <summary>
/// AWS Signing helper
/// </summary>
/// <remarks>
/// Taken from: https://github.com/aws-samples/sigv4-signing-examples/blob/main/no-sdk/dotnet/AWSSigner.cs
/// </remarks>
public static class AWSSigner
{
    public static string GetAuthorizationHeader(
        string service,
        string region,
        string httpMethod,
        Uri uri,
        DateTime now,
        string awsAccessKey,
        string awsSecretKey,
        string? awsSessionToken = null
    )
    {
        return GetAuthorizationHeader(
            service,
            region,
            httpMethod,
            uri,
            now,
            new Dictionary<string, string>(),
            CalculateHash(""),
            awsAccessKey,
            awsSecretKey,
            awsSessionToken
        );
    }

    public static string GetAuthorizationHeader(
        string service,
        string region,
        string httpMethod,
        Uri uri,
        DateTime now,
        IDictionary<string, string> headers,
        string payloadHash,
        string awsAccessKey,
        string awsSecretKey,
        string? awsSessionToken = null
    )
    {
        var ALGORITHM = "AWS4-HMAC-SHA256";

        var amzDate = ToAmzDate(now);
        var datestamp = now.ToString("yyyyMMdd");
        headers["host"] = uri.Host;
        headers["x-amz-date"] = amzDate;
        if (!string.IsNullOrWhiteSpace(awsSessionToken))
        {
            headers["x-amz-security-token"] = awsSessionToken!;
        }

        // Create the canonical request
        var canonicalQuerystring = "";
        var canonicalHeaders = CanonicalizeHeaders(headers);
        var signedHeaders = CanonicalizeHeaderNames(headers);
        var canonicalRequest =
            $"{httpMethod}\n{string.Join("/", uri.AbsolutePath.Split('/').Select(WebUtility.UrlEncode))}\n{canonicalQuerystring}\n{canonicalHeaders}\n{signedHeaders}\n{payloadHash}";

        // Create the string to sign
        var credentialScope = $"{datestamp}/{region}/{service}/aws4_request";
        var hashedCanonicalRequest = CalculateHash(canonicalRequest);
        var stringToSign = $"{ALGORITHM}\n{amzDate}\n{credentialScope}\n{hashedCanonicalRequest}";

        // Sign the string
        var signingKey = GetSignatureKey(awsSecretKey, datestamp, region, service);
        var signature = CalculateHmacHex(signingKey, stringToSign);

        // return signing information
        return $"{ALGORITHM} Credential={awsAccessKey}/{credentialScope}, SignedHeaders={signedHeaders}, Signature={signature}";
    }

    public static string ToAmzDate(DateTime date)
    {
        return date.ToString("yyyyMMddTHHmmssZ");
    }

    static string CanonicalizeHeaderNames(IDictionary<string, string> headers)
    {
        var headersToSign = new List<string>(headers.Keys);
        headersToSign.Sort(StringComparer.OrdinalIgnoreCase);

        var sb = new StringBuilder();
        foreach (var header in headersToSign)
        {
            if (sb.Length > 0)
                sb.Append(';');
            sb.Append(header.ToLower());
        }
        return sb.ToString();
    }

    static string CanonicalizeHeaders(IDictionary<string, string> headers)
    {
        var canonicalHeaders = new StringBuilder();
        var sortedHeaders = new SortedDictionary<string, string>(
            headers,
            StringComparer.OrdinalIgnoreCase
        );
        foreach (var header in sortedHeaders)
        {
            canonicalHeaders.Append($"{header.Key.ToLowerInvariant()}:{header.Value.Trim()}\n");
        }
        return canonicalHeaders.ToString();
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
        return System.Convert.ToHexStringLower(hash).Replace("-", "");
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
        return Convert
            .ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(data)))
            .Replace("-", "");
#else
        using SHA256 sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
#endif
    }

    public static string ToHexString(byte[] data, bool lowercase)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < data.Length; i++)
        {
            sb.Append(data[i].ToString(lowercase ? "x2" : "X2"));
        }
        return sb.ToString();
    }
}
