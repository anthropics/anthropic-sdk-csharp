using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContainerUploadBlock, ContainerUploadBlockFromRaw>))]
public sealed record class ContainerUploadBlock : JsonModel
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
    }

    public ContainerUploadBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContainerUploadBlock(ContainerUploadBlock containerUploadBlock)
        : base(containerUploadBlock) { }
#pragma warning restore CS8618

    public ContainerUploadBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContainerUploadBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContainerUploadBlockFromRaw.FromRawUnchecked"/>
    public static ContainerUploadBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContainerUploadBlock(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class ContainerUploadBlockFromRaw : IFromRawJson<ContainerUploadBlock>
{
    /// <inheritdoc/>
    public ContainerUploadBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ContainerUploadBlock.FromRawUnchecked(rawData);
}
