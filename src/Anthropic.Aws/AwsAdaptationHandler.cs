using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Anthropic.Exceptions;

namespace Anthropic.Aws;

/// <summary>
/// Adapts requests for the AWS external Anthropic gateway: signs them with AWS SigV4
/// when SigV4 auth is active.
///
/// <para>Attached as the innermost handler so user handlers observe the request before
/// signing, and any mutation they perform is covered by the request signature.</para>
/// </summary>
internal sealed class AwsAdaptationHandler : DelegatingHandler
{
    private readonly AwsClientOptions _awsConfig;

    public AwsAdaptationHandler(AwsClientOptions awsConfig)
    {
        _awsConfig = awsConfig;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        await AdaptRequest(requestMessage, cancellationToken).ConfigureAwait(false);
        return await base.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
    }

    private async Task AdaptRequest(
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        // Backstop for the workspace ID: the client ctor merges it into ExtraHeaders so
        // user handlers can observe it, but a WithOptions modifier that replaces
        // ExtraHeaders would drop it. Re-add here (before signing) when missing.
        if (
            _awsConfig.WorkspaceId != null
            && !requestMessage.Headers.Contains("anthropic-workspace-id")
        )
        {
            requestMessage.Headers.TryAddWithoutValidation(
                "anthropic-workspace-id",
                _awsConfig.WorkspaceId
            );
        }

        if (_awsConfig.SkipAuth || !_awsConfig.UseSigV4)
        {
            return;
        }

        if (_awsConfig.AwsRegion == null)
        {
            throw new AnthropicException(
                "AWS region is required when using SigV4 authentication. "
                    + "Set the awsRegion constructor argument or the AWS_REGION / AWS_DEFAULT_REGION "
                    + "environment variable."
            );
        }

        // Capture the original Content-Type (including any multipart boundary) before we
        // replace the content below — replacing Content discards its headers.
        var originalContentType = requestMessage.Content?.Headers.ContentType?.ToString();

        // Read the body as raw bytes and replace the content with a fresh MemoryStream so
        // it can be consumed again after we read it for signing. Reading bytes (rather than
        // a string) preserves binary payloads such as multipart/form-data file uploads.
        var bodyBytes = Array.Empty<byte>();
        if (requestMessage.Content != null)
        {
            bodyBytes = await requestMessage
                .Content.ReadAsByteArrayAsync(
#if NET
                    cancellationToken
#endif
                )
                .ConfigureAwait(false);
        }

        var bodyStream = new MemoryStream(bodyBytes);
        var newContent = new StreamContent(bodyStream);
        // Content-Type and Content-Length are content headers per the HTTP spec and must be
        // set on Content.Headers (HttpClient may strip or reject them on request headers).
        if (originalContentType != null)
        {
            newContent.Headers.TryAddWithoutValidation("Content-Type", originalContentType);
        }
        newContent.Headers.TryAddWithoutValidation("Content-Length", bodyBytes.Length.ToString());
        requestMessage.Content = newContent;

        var payloadHash = AwsSigner.CalculateHash(bodyBytes);

        // Add headers required for SigV4 signing. These will be included in the
        // signed-headers list and must be present on the actual request.
        requestMessage.Headers.TryAddWithoutValidation("Host", requestMessage.RequestUri!.Host);

        var now = DateTime.UtcNow;
        var amzDate = AwsSigner.ToAmzDate(now);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-date", amzDate);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-content-sha256", payloadHash);

        var (accessKey, secretKey, sessionToken) = await ResolveCredentialsAsync(cancellationToken)
            .ConfigureAwait(false);

        if (sessionToken != null)
        {
            requestMessage.Headers.TryAddWithoutValidation("x-amz-security-token", sessionToken);
        }

        // Collapse any multi-value request headers (e.g. anthropic-beta when several
        // betas are supplied) to a single comma-joined value before signing AND sending.
        // HttpClient serializes multi-value headers with ", " on the wire, which would
        // not match the canonical request and cause a SigV4 signature mismatch. By
        // mutating the message headers here, the signed bytes and the wire bytes agree.
        foreach (var header in requestMessage.Headers.ToList())
        {
            var values = header.Value.ToList();
            if (values.Count > 1)
            {
                requestMessage.Headers.Remove(header.Key);
                requestMessage.Headers.TryAddWithoutValidation(
                    header.Key,
                    string.Join(",", values)
                );
            }
        }

        var authHeader = AwsSigner.GetAuthorizationHeader(
            new SigningRequest
            {
                Service = _awsConfig.ServiceName,
                Region = _awsConfig.AwsRegion,
                HttpMethod = requestMessage.Method.ToString(),
                Uri = requestMessage.RequestUri!,
                Now = now,
                // Sign both request headers and content headers (Content-Type,
                // Content-Length) so the canonical request matches the bytes on the wire.
                Headers = requestMessage
                    .Headers.Concat(requestMessage.Content.Headers)
                    .ToDictionary(
                        e => e.Key,
                        e => string.Join(",", e.Value),
                        StringComparer.InvariantCultureIgnoreCase
                    ),
                PayloadHash = payloadHash,
                AwsAccessKey = accessKey,
                AwsSecretKey = secretKey,
            }
        );

        requestMessage.Headers.TryAddWithoutValidation("Authorization", authHeader);
    }

    private async Task<(
        string accessKey,
        string secretKey,
        string? sessionToken
    )> ResolveCredentialsAsync(CancellationToken cancellationToken)
    {
        if (_awsConfig.AwsAccessKey != null)
        {
            return (
                _awsConfig.AwsAccessKey,
                _awsConfig.AwsSecretAccessKey!,
                _awsConfig.AwsSessionToken
            );
        }

        ImmutableCredentials? creds;

        if (_awsConfig.AwsProfile != null)
        {
            var chain = new CredentialProfileStoreChain();
            if (!chain.TryGetAWSCredentials(_awsConfig.AwsProfile, out var profileCreds))
            {
                throw new AnthropicException(
                    $"AWS profile '{_awsConfig.AwsProfile}' was not found. "
                        + "Verify your AWS credentials and config files."
                );
            }
            creds = await profileCreds.GetCredentialsAsync().ConfigureAwait(false);
        }
        else
        {
            var identity =
                DefaultAWSCredentialsIdentityResolver.GetCredentials()
                ?? throw new AnthropicException(
                    "No AWS credentials could be found. Provide awsAccessKey and awsSecretAccessKey, "
                        + "set awsProfile, configure AWS_PROFILE, or set up the default credential chain."
                );
            creds = await identity.GetCredentialsAsync().ConfigureAwait(false);
        }

        if (creds == null)
        {
            throw new AnthropicException("Failed to resolve AWS credentials.");
        }

        return (creds.AccessKey, creds.SecretKey, creds.UseToken ? creds.Token : null);
    }
}
