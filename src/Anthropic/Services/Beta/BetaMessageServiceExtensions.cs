using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Services.Beta;

/// <summary>
/// Extension methods for the beta IMessageService that provide structured output support.
/// </summary>
public static class BetaMessageServiceExtensions
{
    /// <summary>
    /// Creates a message with a structured output schema pre-wired, returning a
    /// <see cref="BetaStructuredMessage{T}"/> whose <see cref="BetaStructuredMessage{T}.Content"/>
    /// entries expose strongly-typed <see cref="BetaStructuredContentBlock{T}.Parsed"/> on each
    /// text block.
    /// </summary>
    /// <typeparam name="T">The type to parse the response into. Must have a parameterless constructor.</typeparam>
    /// <param name="service">The beta message service.</param>
    /// <param name="parameters">The message creation parameters. OutputConfig will be set automatically.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="BetaStructuredMessage{T}"/> wrapping the response.</returns>
    public static async Task<BetaStructuredMessage<T>> Create<T>(
        this IMessageService service,
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    )
        where T : class, new()
    {
        var format = StructuredOutput.CreateBetaJsonFormat<T>();
        parameters = SetOutputConfig(parameters, format);
        var message = await service.Create(parameters, cancellationToken).ConfigureAwait(false);
        return new BetaStructuredMessage<T>(message);
    }

    static MessageCreateParams SetOutputConfig(
        MessageCreateParams parameters,
        BetaJsonOutputFormat format
    )
    {
        var outputConfig = new BetaOutputConfig { Format = format };

        var rawBodyData = parameters.RawBodyData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        rawBodyData["output_config"] = JsonSerializer.SerializeToElement(
            outputConfig,
            ModelBase.SerializerOptions
        );

        return MessageCreateParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );
    }
}
