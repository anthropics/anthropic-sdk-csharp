using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<InputJsonDelta, InputJsonDeltaFromRaw>))]
public sealed record class InputJsonDelta : JsonModel
{
    public required string PartialJson
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("partial_json");
        }
        init { this._rawData.Set("partial_json", value); }
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
        _ = this.PartialJson;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("input_json_delta")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public InputJsonDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("input_json_delta");
    }

    public InputJsonDelta(InputJsonDelta inputJsonDelta)
        : base(inputJsonDelta) { }

    public InputJsonDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("input_json_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputJsonDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputJsonDeltaFromRaw.FromRawUnchecked"/>
    public static InputJsonDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InputJsonDelta(string partialJson)
        : this()
    {
        this.PartialJson = partialJson;
    }
}

class InputJsonDeltaFromRaw : IFromRawJson<InputJsonDelta>
{
    /// <inheritdoc/>
    public InputJsonDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InputJsonDelta.FromRawUnchecked(rawData);
}
