using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaJSONOutputFormat, BetaJSONOutputFormatFromRaw>))]
public sealed record class BetaJSONOutputFormat : ModelBase
{
    /// <summary>
    /// The JSON schema of the format
    /// </summary>
    public required Dictionary<string, JsonElement> Schema
    {
        get
        {
            if (!this._rawData.TryGetValue("schema", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'schema' cannot be null",
                    new ArgumentOutOfRangeException("schema", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'schema' cannot be null",
                    new ArgumentNullException("schema")
                );
        }
        init
        {
            this._rawData["schema"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Schema;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"json_schema\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaJSONOutputFormat()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"json_schema\"");
    }

    public BetaJSONOutputFormat(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"json_schema\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaJSONOutputFormat(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaJSONOutputFormat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaJSONOutputFormatFromRaw : IFromRaw<BetaJSONOutputFormat>
{
    public BetaJSONOutputFormat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaJSONOutputFormat.FromRawUnchecked(rawData);
}
