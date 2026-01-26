using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaContainerUploadBlock, BetaContainerUploadBlockFromRaw>)
)]
public sealed record class BetaContainerUploadBlock : JsonModel
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

    public BetaContainerUploadBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

    public BetaContainerUploadBlock(BetaContainerUploadBlock betaContainerUploadBlock)
        : base(betaContainerUploadBlock) { }

    public BetaContainerUploadBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("container_upload");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerUploadBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaContainerUploadBlockFromRaw.FromRawUnchecked"/>
    public static BetaContainerUploadBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaContainerUploadBlock(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaContainerUploadBlockFromRaw : IFromRawJson<BetaContainerUploadBlock>
{
    /// <inheritdoc/>
    public BetaContainerUploadBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContainerUploadBlock.FromRawUnchecked(rawData);
}
