using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaCacheMissPreviousMessageNotFound,
        BetaCacheMissPreviousMessageNotFoundFromRaw
    >)
)]
public sealed record class BetaCacheMissPreviousMessageNotFound : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("previous_message_not_found")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCacheMissPreviousMessageNotFound()
    {
        this.Type = JsonSerializer.SerializeToElement("previous_message_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCacheMissPreviousMessageNotFound(
        BetaCacheMissPreviousMessageNotFound betaCacheMissPreviousMessageNotFound
    )
        : base(betaCacheMissPreviousMessageNotFound) { }
#pragma warning restore CS8618

    public BetaCacheMissPreviousMessageNotFound(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("previous_message_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCacheMissPreviousMessageNotFound(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCacheMissPreviousMessageNotFoundFromRaw.FromRawUnchecked"/>
    public static BetaCacheMissPreviousMessageNotFound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCacheMissPreviousMessageNotFoundFromRaw
    : IFromRawJson<BetaCacheMissPreviousMessageNotFound>
{
    /// <inheritdoc/>
    public BetaCacheMissPreviousMessageNotFound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCacheMissPreviousMessageNotFound.FromRawUnchecked(rawData);
}
