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
using Anthropic;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Aws;

/// <summary>
/// An Anthropic client that authenticates via the AWS external Anthropic gateway.
/// Supports both Anthropic API key mode and AWS SigV4 mode.
/// </summary>
/// <remarks>
/// See <see cref="AwsClientOptions"/> for auth precedence, region resolution,
/// base URL resolution, and workspace ID resolution.
/// </remarks>
public sealed class AnthropicAwsClient : AnthropicClient
{
    /// <inheritdoc/>
    protected override bool ShouldAutoResolveCredentials => false;

    private readonly AwsClientOptions _awsConfig;
    private readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <summary>
    /// Creates a new <see cref="AnthropicAwsClient"/>.
    /// </summary>
    /// <param name="options">
    /// Configuration options for authentication, region, base URL, and workspace ID.
    /// When <c>null</c>, all values are resolved from environment variables and the
    /// default AWS credential chain.
    /// </param>
    public AnthropicAwsClient(AwsClientOptions? options = null)
        : base(options?.ClientOptions ?? new ClientOptions())
    {
        var opts = options ?? new AwsClientOptions();

        var resolvedRegion =
            opts.AwsRegion
            ?? Environment.GetEnvironmentVariable("AWS_REGION")
            ?? Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");
        var resolvedWorkspaceId =
            opts.WorkspaceId ?? Environment.GetEnvironmentVariable("ANTHROPIC_AWS_WORKSPACE_ID");

        if (resolvedWorkspaceId == null && !opts.SkipAuth)
        {
            throw new AnthropicException(
                "No workspace ID found. Set the WorkspaceId option "
                    + "or the ANTHROPIC_AWS_WORKSPACE_ID environment variable."
            );
        }

        bool useSigV4;

        if (opts.SkipAuth)
        {
            useSigV4 = false;
            ApiKey = null;
        }
        // Auth precedence
        else if (opts.ApiKey != null)
        {
            useSigV4 = false;
            ApiKey = opts.ApiKey;
        }
        else if (opts.AwsAccessKey != null && opts.AwsSecretAccessKey != null)
        {
            useSigV4 = true;
            ApiKey = null; // suppress ANTHROPIC_API_KEY env var
        }
        else if (opts.AwsProfile != null)
        {
            useSigV4 = true;
            ApiKey = null;
        }
        else
        {
            var envApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_AWS_API_KEY");
            if (envApiKey != null)
            {
                useSigV4 = false;
                ApiKey = envApiKey;
            }
            else
            {
                useSigV4 = true;
                ApiKey = null; // suppress ANTHROPIC_API_KEY env var
            }
        }

        // Base URL: explicit option > env var > derived from region
        var resolvedBaseUrl =
            opts.BaseUrl
            ?? Environment.GetEnvironmentVariable("ANTHROPIC_AWS_BASE_URL")
            ?? (
                resolvedRegion != null
                    ? $"https://aws-external-anthropic.{resolvedRegion}.api.aws"
                    : null
            );

        if (resolvedBaseUrl != null)
        {
            BaseUrl = resolvedBaseUrl;
        }
        else
        {
            throw new AnthropicException(
                "No base URL could be determined. Set the BaseUrl option, "
                    + "the ANTHROPIC_AWS_BASE_URL environment variable, or provide a region via "
                    + "AwsRegion / AWS_REGION / AWS_DEFAULT_REGION."
            );
        }

        _awsConfig = new AwsClientOptions
        {
            SkipAuth = opts.SkipAuth,
            UseSigV4 = useSigV4,
            AwsRegion = resolvedRegion,
            AwsAccessKey = opts.AwsAccessKey,
            AwsSecretAccessKey = opts.AwsSecretAccessKey,
            AwsSessionToken = opts.AwsSessionToken,
            AwsProfile = opts.AwsProfile,
            WorkspaceId = resolvedWorkspaceId,
        };

        _withRawResponse = new Lazy<IAnthropicClientWithRawResponse>(() =>
            new AnthropicAwsClientWithRawResponse(_awsConfig, _options)
        );
    }

    private AnthropicAwsClient(AwsClientOptions awsConfig, ClientOptions options)
        : base(options)
    {
        _awsConfig = awsConfig;
        _withRawResponse = new Lazy<IAnthropicClientWithRawResponse>(() =>
            new AnthropicAwsClientWithRawResponse(_awsConfig, _options)
        );
    }

    /// <inheritdoc />
    public override IAnthropicClientWithRawResponse WithRawResponse => _withRawResponse.Value;

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicAwsClient(_awsConfig, modifier(_options));
    }
}

internal class AnthropicAwsClientWithRawResponse : AnthropicClientWithRawResponse
{
    private readonly AwsClientOptions _awsConfig;

    public AnthropicAwsClientWithRawResponse(AwsClientOptions awsConfig, ClientOptions options)
        : base(options)
    {
        _awsConfig = awsConfig;
    }

    /// <inheritdoc />
    public override IAnthropicClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AnthropicAwsClientWithRawResponse(_awsConfig, modifier(_options));
    }

    /// <inheritdoc />
    protected override async ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        if (_awsConfig.WorkspaceId != null)
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
