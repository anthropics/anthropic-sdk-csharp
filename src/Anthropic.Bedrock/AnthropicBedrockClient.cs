using Anthropic.Core;

namespace Anthropic.Bedrock;

/// <summary>
/// Provides an Anthropic client implementation for AWS Bedrock integration.
/// </summary>
public sealed class AnthropicBedrockClient : AnthropicClient
{
    /// <inheritdoc/>
    protected override bool ShouldAutoResolveCredentials => false;

    private const string ServiceName = "bedrock-runtime";

    private readonly IAnthropicBedrockCredentials _bedrockCredentials;

    /// <summary>
    /// Creates a new Instance of the <see cref="AnthropicBedrockClient"/>.
    /// </summary>
    /// <param name="bedrockCredentials">The credential Provider used to authenticate with the AWS Bedrock service.</param>
    public AnthropicBedrockClient(IAnthropicBedrockCredentials bedrockCredentials)
        : base()
    {
        _bedrockCredentials = bedrockCredentials;
        BaseUrl = $"https://{ServiceName}.{_bedrockCredentials.Region}.amazonaws.com";
        BackendAdaptationHandler = () => new BedrockAdaptationHandler(bedrockCredentials);
    }

    private AnthropicBedrockClient(
        IAnthropicBedrockCredentials bedrockCredentials,
        ClientOptions clientOptions
    )
        : base(clientOptions)
    {
        _bedrockCredentials = bedrockCredentials;
        // The options normally carry the backend adaptation handler from the original
        // construction; restore it if a WithOptions modifier returned fresh options.
        BackendAdaptationHandler ??= () => new BedrockAdaptationHandler(bedrockCredentials);
    }

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicBedrockClient(_bedrockCredentials, modifier(this._options));
    }
}
