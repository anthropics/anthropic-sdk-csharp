using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaJSONOutputFormat, BetaJSONOutputFormatFromRaw>))]
public sealed record class BetaJSONOutputFormat : JsonModel
{
    /// <summary>
    /// The JSON schema of the format
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Schema
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "schema"
            );
        }
        init { JsonModel.Set(this._rawData, "schema", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
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

    public BetaJSONOutputFormat(BetaJSONOutputFormat betaJSONOutputFormat)
        : base(betaJSONOutputFormat) { }

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

    /// <inheritdoc cref="BetaJSONOutputFormatFromRaw.FromRawUnchecked"/>
    public static BetaJSONOutputFormat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaJSONOutputFormatFromRaw : IFromRawJson<BetaJSONOutputFormat>
{
    /// <inheritdoc/>
    public BetaJSONOutputFormat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaJSONOutputFormat.FromRawUnchecked(rawData);
}
