using Anthropic.Core;

namespace Anthropic.Foundry;

/// <summary>
/// Provides methods for invoking the Azure hosted Anthropic api.
/// </summary>
public class AnthropicFoundryClient : AnthropicClient
{
    /// <inheritdoc/>
    protected override bool ShouldAutoResolveCredentials => false;

    private readonly IAnthropicFoundryCredentials _azureCredentials;

    /// <summary>
    /// Creates a new instance of the <see cref="AnthropicFoundryClient"/>.
    /// </summary>
    /// <param name="azureCredentials">The credential provider. Use the <see cref="DefaultAnthropicFoundryCredentials.FromEnv"/> to generate a set of credentials in supported environments or use another implementation for static assignment of credentials.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public AnthropicFoundryClient(IAnthropicFoundryCredentials azureCredentials)
    {
        _azureCredentials =
            azureCredentials ?? throw new ArgumentNullException(nameof(azureCredentials));
        BaseUrl = $"https://{azureCredentials.ResourceName}.services.ai.azure.com/anthropic";
        BackendAdaptationHandler = () => CreateAdaptationHandler(azureCredentials);
    }

    private AnthropicFoundryClient(
        IAnthropicFoundryCredentials azureCredentials,
        ClientOptions options
    )
        : base(options)
    {
        _azureCredentials =
            azureCredentials ?? throw new ArgumentNullException(nameof(azureCredentials));
        // The options normally carry the backend adaptation handler from the original
        // construction; restore it if a WithOptions modifier returned fresh options.
        BackendAdaptationHandler ??= () => CreateAdaptationHandler(azureCredentials);
    }

    /// <summary>
    /// Creates the innermost handler that applies the Foundry credentials, inside any
    /// user handlers, so user handlers observe the request without backend credentials.
    /// </summary>
    private static DelegatingHandler CreateAdaptationHandler(
        IAnthropicFoundryCredentials azureCredentials
    ) =>
        Handler.Create(
            (requestMessage, next, cancellationToken) =>
            {
                azureCredentials.Apply(requestMessage);
                return next(requestMessage, cancellationToken);
            }
        );

    [Obsolete("The {nameof(ApiKey)} property is not supported in this configuration.", true)]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
    public override string? ApiKey
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    {
        get =>
            throw new NotSupportedException(
                $"The {nameof(ApiKey)} property is not supported in this configuration."
            );
        init =>
            throw new NotSupportedException(
                $"The {nameof(ApiKey)} property is not supported in this configuration."
            );
    }

    public override IAnthropicClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AnthropicFoundryClient(_azureCredentials, modifier(_options));
    }
}
