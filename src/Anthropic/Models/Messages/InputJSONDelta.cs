using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<InputJSONDelta>))]
public sealed record class InputJSONDelta
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<InputJSONDelta>
{
    public required string PartialJSON
    {
        get
        {
            if (!this.Properties.TryGetValue("partial_json", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "partial_json",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("partial_json");
        }
        set { this.Properties["partial_json"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
