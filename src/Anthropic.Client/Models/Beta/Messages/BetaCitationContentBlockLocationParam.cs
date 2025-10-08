using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationContentBlockLocationParam>))]
public sealed record class BetaCitationContentBlockLocationParam
    : ModelBase,
        IFromRaw<BetaCitationContentBlockLocationParam>
{
    public required string CitedText
    {
        get
        {
            if (!this.Properties.TryGetValue("cited_text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cited_text' cannot be null",
                    new ArgumentOutOfRangeException("cited_text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'cited_text' cannot be null",
                    new ArgumentNullException("cited_text")
                );
        }
        set
        {
            this.Properties["cited_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long DocumentIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("document_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'document_index' cannot be null",
                    new ArgumentOutOfRangeException("document_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["document_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? DocumentTitle
    {
        get
        {
            if (!this.Properties.TryGetValue("document_title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["document_title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long EndBlockIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("end_block_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'end_block_index' cannot be null",
                    new ArgumentOutOfRangeException("end_block_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end_block_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long StartBlockIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("start_block_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'start_block_index' cannot be null",
                    new ArgumentOutOfRangeException(
                        "start_block_index",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start_block_index"] = JsonSerializer.SerializeToElement(
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
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndBlockIndex;
        _ = this.StartBlockIndex;
    }

    public BetaCitationContentBlockLocationParam()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationContentBlockLocationParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationContentBlockLocationParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
