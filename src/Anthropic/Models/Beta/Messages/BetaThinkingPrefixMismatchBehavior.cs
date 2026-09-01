using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// What happens when a thinking block in `messages` fails the conversation check:
/// it was created in a different conversation, or the messages before it have changed
/// since. `"error"` (the default) fails the request with a 400 error. `"drop_block"`
/// removes the failing blocks and the request proceeds; the model no longer sees
/// the dropped reasoning.
/// </summary>
[JsonConverter(typeof(BetaThinkingPrefixMismatchBehaviorConverter))]
public enum BetaThinkingPrefixMismatchBehavior
{
    Error,
    DropBlock,
}

sealed class BetaThinkingPrefixMismatchBehaviorConverter
    : JsonConverter<BetaThinkingPrefixMismatchBehavior>
{
    public override BetaThinkingPrefixMismatchBehavior Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "error" => BetaThinkingPrefixMismatchBehavior.Error,
            "drop_block" => BetaThinkingPrefixMismatchBehavior.DropBlock,
            _ => (BetaThinkingPrefixMismatchBehavior)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaThinkingPrefixMismatchBehavior value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaThinkingPrefixMismatchBehavior.Error => "error",
                BetaThinkingPrefixMismatchBehavior.DropBlock => "drop_block",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
