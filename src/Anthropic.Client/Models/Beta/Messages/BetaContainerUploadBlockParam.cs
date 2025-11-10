using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

/// <summary>
/// A content block that represents a file to be uploaded to the container Files
/// uploaded via this block will be available in the container's input directory.
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
            if (!this._properties.TryGetValue("file_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'file_id' cannot be null",
                    new ArgumentOutOfRangeException("file_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'file_id' cannot be null",
                    new ArgumentNullException("file_id")
                );
        }
        init
        {
            this._properties["file_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FileID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"container_upload\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaContainerUploadBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"container_upload\"");
    }

    public BetaContainerUploadBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"container_upload\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerUploadBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaContainerUploadBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaContainerUploadBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}
