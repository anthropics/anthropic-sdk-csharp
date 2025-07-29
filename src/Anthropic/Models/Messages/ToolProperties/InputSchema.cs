using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.ToolProperties;

/// <summary>
/// [JSON schema](https://json-schema.org/draft/2020-12) for this tool's input.
///
/// This defines the shape of the `input` that your tool accepts and that the model
/// will produce.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<InputSchema>))]
public sealed record class InputSchema : Anthropic::ModelBase, Anthropic::IFromRaw<InputSchema>
{
    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement? Properties1
    {
        get
        {
            if (!this.Properties.TryGetValue("properties", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Json::JsonElement?>(element);
        }
        set { this.Properties["properties"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Generic::List<string>? Required
    {
        get
        {
            if (!this.Properties.TryGetValue("required", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<Generic::List<string>?>(element);
        }
        set { this.Properties["required"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"object\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    InputSchema(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InputSchema FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
