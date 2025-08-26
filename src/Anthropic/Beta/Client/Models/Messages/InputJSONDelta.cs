using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<InputJSONDelta>))]
public sealed record class InputJSONDelta : ModelBase, IFromRaw<InputJSONDelta>
{
    public required string PartialJSON
    {
        get
        {
            if (!this.Properties.TryGetValue("partial_json", out JsonElement element))
                throw new ArgumentOutOfRangeException("partial_json", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("partial_json");
        }
        set
        {
            this.Properties["partial_json"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PartialJSON;
    }

    public InputJSONDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputJSONDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InputJSONDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public InputJSONDelta(string partialJSON)
        : this()
    {
        this.PartialJSON = partialJSON;
    }
}
