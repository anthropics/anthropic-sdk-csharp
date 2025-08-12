using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using System = System;

namespace Anthropic.Models.Beta.Messages.BetaToolProperties;

/// <summary>
/// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
///
/// This defines the shape of the `input` that your tool accepts and that the model
/// will produce.
/// </summary>
[JsonConverter(typeof(Anthropic::ModelConverter<InputSchema>))]
public sealed record class InputSchema : Anthropic::ModelBase, Anthropic::IFromRaw<InputSchema>
{
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement? Properties1
    {
        get
        {
            if (!this.Properties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["properties"] = JsonSerializer.SerializeToElement(value); }
    }

    public List<string>? Required
    {
        get
        {
            if (!this.Properties.TryGetValue("required", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["required"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.Properties1;
        foreach (var item in this.Required ?? [])
        {
            _ = item;
        }
    }

    public InputSchema()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"object\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputSchema(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InputSchema FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
