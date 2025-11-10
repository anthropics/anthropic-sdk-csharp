using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaInputJSONDelta>))]
public sealed record class BetaInputJSONDelta : ModelBase, IFromRaw<BetaInputJSONDelta>
{
    public required string PartialJSON
    {
        get
        {
            if (!this._properties.TryGetValue("partial_json", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'partial_json' cannot be null",
                    new ArgumentOutOfRangeException("partial_json", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'partial_json' cannot be null",
                    new ArgumentNullException("partial_json")
                );
        }
        init
        {
            this._properties["partial_json"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public BetaInputJSONDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

    public BetaInputJSONDelta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInputJSONDelta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaInputJSONDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaInputJSONDelta(string partialJSON)
        : this()
    {
        this.PartialJSON = partialJSON;
    }
}
