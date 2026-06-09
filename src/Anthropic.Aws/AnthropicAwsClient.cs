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

        // A local (rather than the field) so the factory closure below doesn't
        // capture and pin the whole client.
        var awsConfig = new AwsClientOptions
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
        _awsConfig = awsConfig;

        // The workspace ID is logical request metadata (not backend wire adaptation), so
        // it's applied via ExtraHeaders, before user handlers run, where they can observe
        // it. SigV4 signing happens after, in the adaptation handler, so it is signed.
        if (resolvedWorkspaceId != null)
        {
            var merged = new Dictionary<string, string>();
            if (ExtraHeaders != null)
            {
                foreach (var header in ExtraHeaders)
                {
                    merged[header.Key] = header.Value;
                }
            }
            // The dedicated WorkspaceId option (or its env var) wins on conflict.
            merged["anthropic-workspace-id"] = resolvedWorkspaceId;
            ExtraHeaders = merged;
        }

        BackendAdaptationHandler = () => new AwsAdaptationHandler(awsConfig);
    }

    private AnthropicAwsClient(AwsClientOptions awsConfig, ClientOptions options)
        : base(options)
    {
        _awsConfig = awsConfig;
        // The options normally carry the backend adaptation handler and workspace-ID
        // extra header from the original construction; restore the handler if a
        // WithOptions modifier returned fresh options.
        BackendAdaptationHandler ??= () => new AwsAdaptationHandler(awsConfig);
    }

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicAwsClient(_awsConfig, modifier(_options));
    }
}
