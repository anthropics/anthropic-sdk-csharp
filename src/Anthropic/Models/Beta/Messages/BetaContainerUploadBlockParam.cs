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
    typeof(ModelConverter<BetaContainerUploadBlockParam, BetaContainerUploadBlockParamFromRaw>)
)]
public sealed record class BetaContainerUploadBlockParam : ModelBase
{
    public required string FileID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
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

    public BetaContainerUploadBlockParam(
        BetaContainerUploadBlockParam betaContainerUploadBlockParam
    )
        : base(betaContainerUploadBlockParam) { }

    public BetaContainerUploadBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"container_upload\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainerUploadBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaContainerUploadBlockParamFromRaw : IFromRaw<BetaContainerUploadBlockParam>
{
    /// <inheritdoc/>
    public BetaContainerUploadBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaContainerUploadBlockParam.FromRawUnchecked(rawData);
}
