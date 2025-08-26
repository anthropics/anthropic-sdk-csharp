using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContainerUploadBlock>))]
public sealed record class BetaContainerUploadBlock : ModelBase, IFromRaw<BetaContainerUploadBlock>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("file_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("file_id");
        }
        set
        {
            this.Properties["file_id"] = JsonSerializer.SerializeToElement(
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
        _ = this.FileID;
    }

    public BetaContainerUploadBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"container_upload\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerUploadBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContainerUploadBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaContainerUploadBlock(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}
