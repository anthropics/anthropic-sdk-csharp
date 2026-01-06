using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<InputJSONDelta, InputJSONDeltaFromRaw>))]
public sealed record class InputJSONDelta : JsonModel
{
    public required string PartialJSON
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "partial_json"); }
        init { JsonModel.Set(this._rawData, "partial_json", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PartialJSON;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public InputJSONDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

    public InputJSONDelta(InputJSONDelta inputJSONDelta)
        : base(inputJSONDelta) { }

    public InputJSONDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputJSONDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputJSONDeltaFromRaw.FromRawUnchecked"/>
    public static InputJSONDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InputJSONDelta(string partialJSON)
        : this()
    {
        this.PartialJSON = partialJSON;
    }
}

class InputJSONDeltaFromRaw : IFromRawJson<InputJSONDelta>
{
    /// <inheritdoc/>
    public InputJSONDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputJSONDelta.FromRawUnchecked(rawData);
}
