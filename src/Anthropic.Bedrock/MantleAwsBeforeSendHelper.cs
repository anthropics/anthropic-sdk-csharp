using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.Runtime.Credentials;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Bedrock;

/// <summary>
/// Shared <c>BeforeSend</c> logic for the Bedrock Mantle client: (when SigV4 is active)
/// request signing.
/// </summary>
/// <remarks>
/// This is a self-contained copy of the helper used by the AWS client,
/// duplicated to keep the Anthropic.Bedrock package independently publishable.
/// </remarks>
internal static class MantleAwsBeforeSendHelper
{
    internal static async ValueTask ApplyBeforeSend<T>(
        MantleAwsClientOptions awsOptions,
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
        where T : ParamsBase
    {
        if (requestMessage.Content != null)
        {
            requestMessage.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        }

        if (awsOptions.SkipAuth)
        {
            return;
        }

        // API key mode: send as Authorization: Bearer header
        if (!awsOptions.UseSigV4)
        {
            if (awsOptions.ResolvedApiKey != null)
            {
                requestMessage.Headers.TryAddWithoutValidation(
                    "Authorization",
                    $"Bearer {awsOptions.ResolvedApiKey}"
                );
            }
            return;
        }

        if (awsOptions.AwsRegion == null)
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

        var credentialsTask = ResolveCredentialsAsync(awsOptions, cancellationToken);

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

        var authHeader = MantleAwsSigner.GetAuthorizationHeader(
            new MantleSigningRequest
            {
                Service = awsOptions.ServiceName,
                Region = awsOptions.AwsRegion,
                HttpMethod = requestMessage.Method.ToString(),
                Uri = requestMessage.RequestUri!,
                Now = now,
                Headers = requestMessage.Headers.ToDictionary(
                    e => e.Key,
                    e => string.Join(" ", e.Value),
                    StringComparer.InvariantCultureIgnoreCase
                ),
                PayloadHash = payloadHash,
                AwsAccessKey = accessKey,
                AwsSecretKey = secretKey,
            }
        );

        requestMessage.Headers.TryAddWithoutValidation("Authorization", authHeader);
    }

    internal static async Task<(
        string accessKey,
        string secretKey,
        string? sessionToken
    )> ResolveCredentialsAsync(
        MantleAwsClientOptions awsOptions,
        CancellationToken cancellationToken
    )
    {
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
