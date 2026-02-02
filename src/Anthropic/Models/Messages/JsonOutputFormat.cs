using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<JsonOutputFormat, JsonOutputFormatFromRaw>))]
public sealed record class JsonOutputFormat : JsonModel
{
    /// <summary>
    /// The JSON schema of the format
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Schema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("schema");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "schema",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

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
        _ = this.Schema;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("json_schema")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public JsonOutputFormat()
    {
        this.Type = JsonSerializer.SerializeToElement("json_schema");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JsonOutputFormat(JsonOutputFormat jsonOutputFormat)
        : base(jsonOutputFormat) { }
#pragma warning restore CS8618

    public JsonOutputFormat(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("json_schema");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JsonOutputFormat(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JsonOutputFormatFromRaw.FromRawUnchecked"/>
    public static JsonOutputFormat FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JsonOutputFormatFromRaw : IFromRawJson<JsonOutputFormat>
{
    /// <inheritdoc/>
    public JsonOutputFormat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JsonOutputFormat.FromRawUnchecked(rawData);
}
