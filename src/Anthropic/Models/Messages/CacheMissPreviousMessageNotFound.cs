using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        CacheMissPreviousMessageNotFound,
        CacheMissPreviousMessageNotFoundFromRaw
    >)
)]
public sealed record class CacheMissPreviousMessageNotFound : JsonModel
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

    public CacheMissPreviousMessageNotFound()
    {
        this.Type = JsonSerializer.SerializeToElement("previous_message_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CacheMissPreviousMessageNotFound(
        CacheMissPreviousMessageNotFound cacheMissPreviousMessageNotFound
    )
        : base(cacheMissPreviousMessageNotFound) { }
#pragma warning restore CS8618

    public CacheMissPreviousMessageNotFound(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("previous_message_not_found");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheMissPreviousMessageNotFound(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CacheMissPreviousMessageNotFoundFromRaw.FromRawUnchecked"/>
    public static CacheMissPreviousMessageNotFound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CacheMissPreviousMessageNotFoundFromRaw : IFromRawJson<CacheMissPreviousMessageNotFound>
{
    /// <inheritdoc/>
    public CacheMissPreviousMessageNotFound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CacheMissPreviousMessageNotFound.FromRawUnchecked(rawData);
}
