using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

/// <summary>
/// The organization's External Storage that `external_storage_id` names.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaExternalStorageMemberParam,
        BetaExternalStorageMemberParamFromRaw
    >)
)]
public sealed record class BetaExternalStorageMemberParam : JsonModel
{
    /// <summary>
    /// The External Storage ID, which starts with `estrg_`. Through Claude Platform
    /// on AWS, storage whose `provider_config.type` is `aws` has its bucket ARN
    /// as its ID instead: `arn:&lt;partition&gt;:s3:::&lt;bucket_name&gt;`, where
    /// `&lt;partition&gt;` is the partition of the bucket's region.
    /// </summary>
    public required string ExternalStorageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("external_storage_id");
        }
        init { this._rawData.Set("external_storage_id", value); }
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
        _ = this.ExternalStorageID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("external")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaExternalStorageMemberParam()
    {
        this.Type = JsonSerializer.SerializeToElement("external");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaExternalStorageMemberParam(
        BetaExternalStorageMemberParam betaExternalStorageMemberParam
    )
        : base(betaExternalStorageMemberParam) { }
#pragma warning restore CS8618

    public BetaExternalStorageMemberParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaExternalStorageMemberParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaExternalStorageMemberParamFromRaw.FromRawUnchecked"/>
    public static BetaExternalStorageMemberParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaExternalStorageMemberParam(string externalStorageID)
        : this()
    {
        this.ExternalStorageID = externalStorageID;
    }
}

class BetaExternalStorageMemberParamFromRaw : IFromRawJson<BetaExternalStorageMemberParam>
{
    /// <inheritdoc/>
    public BetaExternalStorageMemberParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaExternalStorageMemberParam.FromRawUnchecked(rawData);
}
