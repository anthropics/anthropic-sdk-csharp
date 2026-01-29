using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A content block that represents a file to be uploaded to the container Files
/// uploaded via this block will be available in the container's input directory.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaContainerUploadBlockParam, BetaContainerUploadBlockParamFromRaw>)
)]
public sealed record class BetaContainerUploadBlockParam : JsonModel
{
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("container_upload")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaContainerUploadBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaContainerUploadBlockParam(
        BetaContainerUploadBlockParam betaContainerUploadBlockParam
    )
        : base(betaContainerUploadBlockParam) { }
#pragma warning restore CS8618

    public BetaContainerUploadBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerUploadBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContainerUploadBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaContainerUploadBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaContainerUploadBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaContainerUploadBlockParamFromRaw : IFromRawJson<BetaContainerUploadBlockParam>
{
    /// <inheritdoc/>
    public BetaContainerUploadBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContainerUploadBlockParam.FromRawUnchecked(rawData);
}
