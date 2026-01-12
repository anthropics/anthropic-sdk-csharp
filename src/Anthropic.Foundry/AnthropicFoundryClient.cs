using Anthropic.Core;

namespace Anthropic.Foundry;

/// <summary>
/// Provides methods for invoking the Azure hosted Anthropic api.
/// </summary>
public class AnthropicFoundryClient : AnthropicClient
{
    private readonly IAnthropicFoundryCredentials _azureCredentials;

    /// <summary>
    /// Creates a new instance of the <see cref="AnthropicFoundryClient"/>.
    /// </summary>
    /// <param name="azureCredentials">The credential provider. Use the <see cref="IAnthropicFoundryCredentials.FromEnv"/> to generate a set of credentials in supported environments or use another implementation for static assignment of credentials.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public AnthropicFoundryClient(IAnthropicFoundryCredentials azureCredentials)
    {
        _azureCredentials =
            azureCredentials ?? throw new ArgumentNullException(nameof(azureCredentials));
        BaseUrl = $"https://{azureCredentials.ResourceName}.services.ai.azure.com/anthropic";
    }

    private AnthropicFoundryClient(
        IAnthropicFoundryCredentials azureCredentials,
        ClientOptions options
    )
        : base(options)
    {
        _azureCredentials =
            azureCredentials ?? throw new ArgumentNullException(nameof(azureCredentials));
    }

    [Obsolete("The {nameof(APIKey)} property is not supported in this configuration.", true)]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    public override string? APIKey
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    {
        get =>
            throw new NotSupportedException(
                $"The {nameof(APIKey)} property is not supported in this configuration."
            );
        init =>
            throw new NotSupportedException(
                $"The {nameof(APIKey)} property is not supported in this configuration."
            );
    }

    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicFoundryClient(_azureCredentials, modifier(_options));
    }

    protected override ValueTask BeforeSend<T>(
        HttpRequest<T> request,
        HttpRequestMessage requestMessage,
        CancellationToken cancellationToken
    )
    {
        _azureCredentials.Apply(requestMessage);

        return default;
    }
}
