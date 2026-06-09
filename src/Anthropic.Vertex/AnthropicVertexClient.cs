using Anthropic.Core;

namespace Anthropic.Vertex;

/// <summary>
/// Provides methods for invoking the vertex hosted Anthropic api.
/// </summary>
public class AnthropicVertexClient : AnthropicClient
{
    /// <inheritdoc/>
    protected override bool ShouldAutoResolveCredentials => false;

    private readonly IAnthropicVertexCredentials _vertexCredentials;

    /// <summary>
    /// Creates a new Instance of the <see cref="AnthropicVertexClient"/>.
    /// </summary>
    /// <param name="vertexCredentials">The credential Provider used to authenticate with the AWS Bedrock service.</param>
    public AnthropicVertexClient(IAnthropicVertexCredentials vertexCredentials)
        : base()
    {
        _vertexCredentials = vertexCredentials;
        BaseUrl = ComputeBaseUrl(vertexCredentials);
        BackendAdaptationHandler = () => new VertexAdaptationHandler(vertexCredentials);
    }

    private AnthropicVertexClient(
        IAnthropicVertexCredentials vertexCredentials,
        ClientOptions clientOptions
    )
        : base(clientOptions)
    {
        _vertexCredentials = vertexCredentials;
        BaseUrl = ComputeBaseUrl(vertexCredentials);
        // The options normally carry the backend adaptation handler from the original
        // construction; restore it if a WithOptions modifier returned fresh options.
        BackendAdaptationHandler ??= () => new VertexAdaptationHandler(vertexCredentials);
    }

    private static string ComputeBaseUrl(IAnthropicVertexCredentials vertexCredentials) =>
        vertexCredentials.Region switch
        {
            "global" or null => "https://aiplatform.googleapis.com",
            "us" => "https://aiplatform.us.rep.googleapis.com",
            "eu" => "https://aiplatform.eu.rep.googleapis.com",
            _ => $"https://{vertexCredentials.Region}-aiplatform.googleapis.com",
        };

    /// <inheritdoc />
    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicVertexClient(_vertexCredentials, modifier(this._options));
    }
}
