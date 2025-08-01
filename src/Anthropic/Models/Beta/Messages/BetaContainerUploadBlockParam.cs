using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A content block that represents a file to be uploaded to the container Files uploaded
/// via this block will be available in the container's input directory.
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContainerUploadBlockParam>))]
public sealed record class BetaContainerUploadBlockParam
    : ModelBase,
        IFromRaw<BetaContainerUploadBlockParam>
{
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("file_id", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "file_id",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("file_id");
        }
        set { this.Properties["file_id"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set { this.Properties["cache_control"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.FileID;
        this.CacheControl?.Validate();
    }

    public BetaContainerUploadBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"container_upload\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerUploadBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContainerUploadBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaContainerUploadBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}
