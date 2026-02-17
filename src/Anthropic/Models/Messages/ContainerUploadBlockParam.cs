using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A content block that represents a file to be uploaded to the container Files
/// uploaded via this block will be available in the container's input directory.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ContainerUploadBlockParam, ContainerUploadBlockParamFromRaw>)
)]
public sealed record class ContainerUploadBlockParam : JsonModel
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
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
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

    public ContainerUploadBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContainerUploadBlockParam(ContainerUploadBlockParam containerUploadBlockParam)
        : base(containerUploadBlockParam) { }
#pragma warning restore CS8618

    public ContainerUploadBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContainerUploadBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContainerUploadBlockParamFromRaw.FromRawUnchecked"/>
    public static ContainerUploadBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContainerUploadBlockParam(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class ContainerUploadBlockParamFromRaw : IFromRawJson<ContainerUploadBlockParam>
{
    /// <inheritdoc/>
    public ContainerUploadBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContainerUploadBlockParam.FromRawUnchecked(rawData);
}
