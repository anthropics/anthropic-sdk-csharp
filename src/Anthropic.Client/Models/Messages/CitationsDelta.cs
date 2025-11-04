using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Messages.CitationsDeltaProperties;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationsDelta>))]
public sealed record class CitationsDelta : ModelBase, IFromRaw<CitationsDelta>
{
    public required Citation Citation
    {
        get
        {
            if (!this.Properties.TryGetValue("citation", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'citation' cannot be null",
                    new ArgumentOutOfRangeException("citation", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Citation>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'citation' cannot be null",
                    new ArgumentNullException("citation")
                );
        }
        set
        {
            this.Properties["citation"] = JsonSerializer.SerializeToElement(
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
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

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
        this.Citation.Validate();
        _ = this.Type;
    }

    public CitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsDelta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CitationsDelta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public CitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}
