using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Anthropic.Exceptions;

namespace Anthropic.Bedrock;

/// <summary>
/// Adapts requests for the Bedrock Mantle gateway: (when SigV4 is active) request
/// signing, otherwise API-key bearer authorization.
///
/// <para>Attached as the innermost handler so user handlers observe Anthropic-shaped
/// requests, and any mutation they perform is covered by the request signature.</para>
/// </summary>
/// <remarks>
/// This is a self-contained copy of the handler used by the AWS client,
/// duplicated to keep the Anthropic.Bedrock package independently publishable.
/// </remarks>
internal sealed class MantleAwsAdaptationHandler : DelegatingHandler
{
    private readonly MantleAwsClientOptions _awsOptions;

    public MantleAwsAdaptationHandler(MantleAwsClientOptions awsOptions)
    {
        _awsOptions = awsOptions;
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
        if (requestMessage.Content != null)
        {
            requestMessage.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        }

        if (_awsOptions.SkipAuth)
        {
            return;
        }

        // API key mode: send as Authorization: Bearer header
        if (!_awsOptions.UseSigV4)
        {
            if (_awsOptions.ResolvedApiKey != null)
            {
                requestMessage.Headers.TryAddWithoutValidation(
                    "Authorization",
                    $"Bearer {_awsOptions.ResolvedApiKey}"
                );
            }
            return;
        }

        if (_awsOptions.AwsRegion == null)
        {
            throw new AnthropicInvalidDataException(
                "AWS region is required when using SigV4 authentication. "
                    + "Set the awsRegion constructor argument or the AWS_REGION / AWS_DEFAULT_REGION "
                    + "environment variable."
            );
        }

        var bodyTask =
            requestMessage.Content != null
                ? requestMessage.Content.ReadAsStringAsync(
#if NET
                    cancellationToken
#endif
                )
                : Task.FromResult("");

        var credentialsTask = ResolveCredentialsAsync(cancellationToken);

        await Task.WhenAll(bodyTask, credentialsTask).ConfigureAwait(false);

        var body = bodyTask.Result;
        var (accessKey, secretKey, sessionToken) = credentialsTask.Result;

        var bodyBytes = Encoding.UTF8.GetBytes(body);
        var bodyStream = new MemoryStream(bodyBytes);
        requestMessage.Content = new StreamContent(bodyStream);
        requestMessage.Content.Headers.ContentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

        var payloadHash = MantleAwsSigner.CalculateHash(body);

        requestMessage.Headers.TryAddWithoutValidation("Host", requestMessage.RequestUri!.Host);
        // content-type is added to request headers (in addition to content headers) for SigV4 signing
        requestMessage.Headers.TryAddWithoutValidation("content-type", "application/json");
        requestMessage.Headers.TryAddWithoutValidation(
            "content-length",
            bodyBytes.Length.ToString()
        );

        var now = DateTime.UtcNow;
        var amzDate = MantleAwsSigner.ToAmzDate(now);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-date", amzDate);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-content-sha256", payloadHash);

        if (sessionToken != null)
        {
            requestMessage.Headers.TryAddWithoutValidation("x-amz-security-token", sessionToken);
        }

        // Collapse any multi-value request headers (e.g. anthropic-beta when several
        // betas are supplied, or values added by user handlers, which run before this
        // handler) to a single comma-joined value before signing AND sending.
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

        var authHeader = MantleAwsSigner.GetAuthorizationHeader(
            new MantleSigningRequest
            {
                Service = _awsOptions.ServiceName,
                Region = _awsOptions.AwsRegion,
                HttpMethod = requestMessage.Method.ToString(),
                Uri = requestMessage.RequestUri!,
                Now = now,
                Headers = requestMessage.Headers.ToDictionary(
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
        var awsOptions = _awsOptions;
        if (awsOptions.AwsAccessKey != null)
        {
            return (
                awsOptions.AwsAccessKey,
                awsOptions.AwsSecretAccessKey!,
                awsOptions.AwsSessionToken
            );
        }

        ImmutableCredentials? creds;

        if (awsOptions.AwsProfile != null)
        {
            var chain = new CredentialProfileStoreChain();
            if (!chain.TryGetAWSCredentials(awsOptions.AwsProfile, out var profileCreds))
            {
                throw new AnthropicInvalidDataException(
                    $"AWS profile '{awsOptions.AwsProfile}' was not found. "
                        + "Verify your AWS credentials and config files."
                );
            }
            creds = await profileCreds.GetCredentialsAsync().ConfigureAwait(false);
        }
        else
        {
            var identity =
                DefaultAWSCredentialsIdentityResolver.GetCredentials()
                ?? throw new AnthropicInvalidDataException(
                    "No AWS credentials could be found. Provide awsAccessKey and awsSecretAccessKey, "
                        + "set awsProfile, configure AWS_PROFILE, or set up the default credential chain."
                );
            creds = await identity.GetCredentialsAsync().ConfigureAwait(false);
        }

        if (creds == null)
        {
            throw new AnthropicInvalidDataException("Failed to resolve AWS credentials.");
        }

        return (creds.AccessKey, creds.SecretKey, creds.UseToken ? creds.Token : null);
    }
}
