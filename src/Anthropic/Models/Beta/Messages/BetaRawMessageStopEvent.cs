using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRawMessageStopEvent, BetaRawMessageStopEventFromRaw>))]
public sealed record class BetaRawMessageStopEvent : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"message_stop\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawMessageStopEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");
    }

    public BetaRawMessageStopEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_stop\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageStopEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawMessageStopEventFromRaw.FromRawUnchecked"/>
    public static BetaRawMessageStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRawMessageStopEventFromRaw : IFromRaw<BetaRawMessageStopEvent>
{
    /// <inheritdoc/>
    public BetaRawMessageStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawMessageStopEvent.FromRawUnchecked(rawData);
}
