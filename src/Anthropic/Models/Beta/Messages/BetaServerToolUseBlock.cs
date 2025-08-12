using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using BetaServerToolUseBlockProperties = Anthropic.Models.Beta.Messages.BetaServerToolUseBlockProperties;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaServerToolUseBlock>))]
public sealed record class BetaServerToolUseBlock
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaServerToolUseBlock>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public required JsonElement Input
    {
        get
        {
            if (!this.Properties.TryGetValue("input", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "input",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["input"] = JsonSerializer.SerializeToElement(value); }
    }

    public required BetaServerToolUseBlockProperties::Name Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "name",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaServerToolUseBlockProperties::Name>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("name");
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
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
        _ = this.ID;
        _ = this.Input;
        this.Name.Validate();
    }

    public BetaServerToolUseBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUseBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaServerToolUseBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
