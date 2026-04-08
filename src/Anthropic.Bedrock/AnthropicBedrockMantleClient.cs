using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services;
using Beta = Anthropic.Services.Beta;

namespace Anthropic.Bedrock;

/// <summary>
/// An Anthropic client that authenticates via the AWS Bedrock Mantle gateway.
/// Supports both Anthropic API key mode and AWS SigV4 mode. Only the Messages
/// resource (and its subpaths) is available — other resources will throw
/// <see cref="NotSupportedException"/>.
/// </summary>
/// <remarks>
/// See <see cref="MantleAwsClientOptions"/> for auth precedence, region resolution,
/// and base URL resolution.
/// </remarks>
public sealed class AnthropicBedrockMantleClient : AnthropicClient
{
    private readonly MantleAwsClientOptions _awsOptions;
    private readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <summary>
    /// Creates a new <see cref="AnthropicBedrockMantleClient"/>.
    /// </summary>
    /// <param name="options">
    /// Configuration options for authentication, region, and base URL.
    /// When <c>null</c>, all values are resolved from environment variables and the
    /// default AWS credential chain.
    /// </param>
    public AnthropicBedrockMantleClient(MantleAwsClientOptions? options = null)
        : base(options?.ClientOptions ?? new ClientOptions())
    {
        var opts = options ?? new MantleAwsClientOptions();

        var resolvedRegion =
            opts.AwsRegion
            ?? Environment.GetEnvironmentVariable("AWS_REGION")
            ?? Environment.GetEnvironmentVariable("AWS_DEFAULT_REGION");

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
            var envApiKey =
                Environment.GetEnvironmentVariable("AWS_BEARER_TOKEN_BEDROCK")
                ?? Environment.GetEnvironmentVariable("ANTHROPIC_AWS_API_KEY");
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
            ?? Environment.GetEnvironmentVariable("ANTHROPIC_BEDROCK_MANTLE_BASE_URL")
            ?? (
                resolvedRegion != null
                    ? $"https://bedrock-mantle.{resolvedRegion}.api.aws/anthropic"
                    : null
            );

        if (resolvedBaseUrl != null)
        {
            BaseUrl = resolvedBaseUrl;
        }
        else
        {
            throw new AnthropicInvalidDataException(
                "No base URL could be determined. Set the BaseUrl option, "
                    + "the ANTHROPIC_BEDROCK_MANTLE_BASE_URL environment variable, or provide a region via "
                    + "AwsRegion / AWS_REGION / AWS_DEFAULT_REGION."
            );
        }

        _awsOptions = new MantleAwsClientOptions
        {
            SkipAuth = opts.SkipAuth,
            UseSigV4 = useSigV4,
            AwsRegion = resolvedRegion,
            AwsAccessKey = opts.AwsAccessKey,
            AwsSecretAccessKey = opts.AwsSecretAccessKey,
            AwsSessionToken = opts.AwsSessionToken,
            AwsProfile = opts.AwsProfile,
        };

        _withRawResponse = new Lazy<IAnthropicClientWithRawResponse>(() =>
            new AnthropicBedrockMantleClientWithRawResponse(_awsOptions, _options)
        );
    }

    private AnthropicBedrockMantleClient(MantleAwsClientOptions awsOptions, ClientOptions options)
        : base(options)
    {
        _awsOptions = awsOptions;
        _withRawResponse = new Lazy<IAnthropicClientWithRawResponse>(() =>
            new AnthropicBedrockMantleClientWithRawResponse(_awsOptions, _options)
        );
    }

    /// <inheritdoc />
    public override IAnthropicClientWithRawResponse WithRawResponse => _withRawResponse.Value;

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicBedrockMantleClient(_awsOptions, modifier(_options));
    }

    /// <summary>
    /// Not supported on Bedrock Mantle. Only Messages (and Beta.Messages) are available.
    /// </summary>
    /// <exception cref="NotSupportedException">Always thrown.</exception>
    public new IModelService Models =>
        throw new NotSupportedException(
            "The Models resource is not supported on Bedrock Mantle. "
                + "Only Messages and Beta.Messages are available."
        );

    /// <summary>
    /// Beta resources. Only <c>Messages</c> is available; accessing <c>Models</c>,
    /// <c>Files</c>, or <c>Skills</c> will throw <see cref="NotSupportedException"/>.
    /// </summary>
    public new IBetaService Beta => new RestrictedBetaService(base.Beta);

    #region Restricted Beta Wrappers

    private sealed class RestrictedBetaService : IBetaService
    {
        private readonly IBetaService _inner;

        public RestrictedBetaService(IBetaService inner) => _inner = inner;

        public IBetaServiceWithRawResponse WithRawResponse =>
            new RestrictedBetaServiceWithRawResponse(_inner.WithRawResponse);

        public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier) =>
            new RestrictedBetaService(_inner.WithOptions(modifier));

        public Beta::IMessageService Messages => _inner.Messages;

        public Beta::IModelService Models =>
            throw new NotSupportedException(
                "The Beta.Models resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IFileService Files =>
            throw new NotSupportedException(
                "The Beta.Files resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::ISkillService Skills =>
            throw new NotSupportedException(
                "The Beta.Skills resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IAgentService Agents =>
            throw new NotSupportedException(
                "The Beta.Agents resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IEnvironmentService Environments =>
            throw new NotSupportedException(
                "The Beta.Environments resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::ISessionService Sessions =>
            throw new NotSupportedException(
                "The Beta.Sessions resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IVaultService Vaults =>
            throw new NotSupportedException(
                "The Beta.Vaults resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );
    }

    private sealed class RestrictedBetaServiceWithRawResponse : IBetaServiceWithRawResponse
    {
        private readonly IBetaServiceWithRawResponse _inner;

        public RestrictedBetaServiceWithRawResponse(IBetaServiceWithRawResponse inner) =>
            _inner = inner;

        public IBetaServiceWithRawResponse WithOptions(
            Func<ClientOptions, ClientOptions> modifier
        ) => new RestrictedBetaServiceWithRawResponse(_inner.WithOptions(modifier));

        public Beta::IMessageServiceWithRawResponse Messages => _inner.Messages;

        public Beta::IModelServiceWithRawResponse Models =>
            throw new NotSupportedException(
                "The Beta.Models resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IFileServiceWithRawResponse Files =>
            throw new NotSupportedException(
                "The Beta.Files resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::ISkillServiceWithRawResponse Skills =>
            throw new NotSupportedException(
                "The Beta.Skills resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IAgentServiceWithRawResponse Agents =>
            throw new NotSupportedException(
                "The Beta.Agents resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IEnvironmentServiceWithRawResponse Environments =>
            throw new NotSupportedException(
                "The Beta.Environments resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::ISessionServiceWithRawResponse Sessions =>
            throw new NotSupportedException(
                "The Beta.Sessions resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );

        public Beta::IVaultServiceWithRawResponse Vaults =>
            throw new NotSupportedException(
                "The Beta.Vaults resource is not supported on Bedrock Mantle. "
                    + "Only Messages and Beta.Messages are available."
            );
    }

    #endregion
}

internal class AnthropicBedrockMantleClientWithRawResponse : AnthropicClientWithRawResponse
{
    private readonly MantleAwsClientOptions _awsOptions;

    public AnthropicBedrockMantleClientWithRawResponse(
        MantleAwsClientOptions awsOptions,
        ClientOptions options
    )
        : base(options)
    {
        _awsOptions = awsOptions;
    }

    /// <inheritdoc />
    public override IAnthropicClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AnthropicBedrockMantleClientWithRawResponse(_awsOptions, modifier(_options));
    }

    /// <inheritdoc />
    protected override ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    ) =>
        MantleAwsBeforeSendHelper.ApplyBeforeSend(
            _awsOptions,
            request,
            requestMessage,
            cancellationToken
        );
}
