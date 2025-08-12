using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using BetaContentBlockSourceProperties = Anthropic.Models.Beta.Messages.BetaContentBlockSourceProperties;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaContentBlockSource>))]
public sealed record class BetaContentBlockSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaContentBlockSource>
{
    public required BetaContentBlockSourceProperties::Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaContentBlockSourceProperties::Content>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("content");
        }
        set { this.Properties["content"] = JsonSerializer.SerializeToElement(value); }
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
        this.Content.Validate();
    }

    public BetaContentBlockSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContentBlockSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContentBlockSource FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaContentBlockSource(BetaContentBlockSourceProperties::Content content)
        : this()
    {
        this.Content = content;
    }
}
