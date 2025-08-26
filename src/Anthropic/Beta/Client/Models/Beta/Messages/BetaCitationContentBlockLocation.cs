using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationContentBlockLocation>))]
public sealed record class BetaCitationContentBlockLocation
    : ModelBase,
        IFromRaw<BetaCitationContentBlockLocation>
{
    public required string CitedText
    {
        get
        {
            if (!this.Properties.TryGetValue("cited_text", out JsonElement element))
                throw new ArgumentOutOfRangeException("cited_text", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("cited_text");
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
                throw new ArgumentOutOfRangeException(
                    "document_index",
                    "Missing required argument"
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
                throw new ArgumentOutOfRangeException(
                    "end_block_index",
                    "Missing required argument"
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

    public required string? FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["file_id"] = JsonSerializer.SerializeToElement(
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
                throw new ArgumentOutOfRangeException(
                    "start_block_index",
                    "Missing required argument"
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
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndBlockIndex;
        _ = this.FileID;
        _ = this.StartBlockIndex;
    }

    public BetaCitationContentBlockLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationContentBlockLocation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCitationContentBlockLocation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
