using Anthropic.Core;

namespace Anthropic.Vertex;

/// <summary>
/// Provides methods for invoking the vertex hosted Anthropic api.
/// </summary>
public class AnthropicVertexClient : AnthropicClient
{
    private readonly IAnthropicVertexCredentials _vertexCredentials;

    private readonly Lazy<IAnthropicClientWithRawResponse> _withRawResponse;

    /// <summary>
    /// Creates a new Instance of the <see cref="AnthropicBedrockClient"/>.
    /// </summary>
    /// <param name="vertexCredentials">The credential Provider used to authenticate with the AWS Bedrock service.</param>
    public AnthropicVertexClient(IAnthropicVertexCredentials vertexCredentials)
        : base()
    {
        _vertexCredentials = vertexCredentials;
        BaseUrl =
            $"https://{(_vertexCredentials.Region is "global" or null ? "" : _vertexCredentials.Region + "-")}aiplatform.googleapis.com";
        _withRawResponse = new(() =>
            new AnthropicVertexClientWithRawResponse(_vertexCredentials, _options)
        );
    }

    private AnthropicVertexClient(
        IAnthropicVertexCredentials vertexCredentials,
        ClientOptions clientOptions
    )
        : base(clientOptions)
    {
        _vertexCredentials = vertexCredentials;
        BaseUrl =
            $"https://{(_vertexCredentials.Region is "global" or null ? "" : _vertexCredentials.Region + "-")}aiplatform.googleapis.com";
        _withRawResponse = new(() =>
            new AnthropicVertexClientWithRawResponse(_vertexCredentials, _options)
        );
    }

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicVertexClient(_vertexCredentials, modifier(this._options));
    }

    /// <inheritdoc/>
    public override IAnthropicClientWithRawResponse WithRawResponse => _withRawResponse.Value;
}
